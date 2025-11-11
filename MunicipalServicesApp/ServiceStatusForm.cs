using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.Services;
using MunicipalServicesApp.DataStructures;

namespace MunicipalServicesApp.Forms
{
    public partial class ServiceStatusForm : Form
    {
        private BinarySearchTree bst = new BinarySearchTree();
        private AVLTree avl = new AVLTree();
        private MinHeap heap = new MinHeap();
        private Graph graph = new Graph();

        private bool isEmployee = false;

        public ServiceStatusForm()
        {
            InitializeComponent();
            DetermineUserRole();
            BuildStructures();
            DisplayPriorityView();
            SetupUIBasedOnRole();
        }

        // Determine if current user is Employee or Resident
        private void DetermineUserRole()
        {
            if (UserStore.CurrentUser != null)
                isEmployee = UserStore.CurrentUser.Role == "Employee";
        }

        // Build BST, AVL, Heap, and Graph from repository data
        private void BuildStructures()
        {
            bst = new BinarySearchTree();
            avl = new AVLTree();
            heap = new MinHeap();
            graph = new Graph();

            var all = ServiceRequestRepository.GetAll();
            foreach (var r in all)
            {
                bst.Insert(r);
                avl.Insert(r);
                heap.Insert(r);
            }

            // Build simple graph dependencies
            for (int i = 0; i < all.Count - 1; i++)
                graph.AddEdge(all[i].Id, all[i + 1].Id);
        }

        // Display all requests sorted by heap (older first)
        private void DisplayPriorityView()
        {
            dgvServiceStatus.Rows.Clear();
            var sorted = heap.GetAllSortedByPriority();
            foreach (var r in sorted)
            {
                dgvServiceStatus.Rows.Add(r.Id, r.Title, r.Status, r.DateSubmitted.ToString("yyyy-MM-dd"));
            }
        }

        private void SetupUIBasedOnRole()
        {
            // Show or hide controls based on role
            lblUpdateStatus.Visible = isEmployee;
            cmbUpdateStatus.Visible = isEmployee;
            btnUpdateStatus.Visible = isEmployee;

            if (isEmployee)
            {
                cmbUpdateStatus.Items.Clear();
                cmbUpdateStatus.Items.AddRange(new string[]
                {
                    "Pending", "In Progress", "Resolved", "Closed"
                });
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BuildStructures();
            DisplayPriorityView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtSearchId.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Enter a Request ID to search.", "Input required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var found = bst.Search(id);
            if (found != null)
            {
                MessageBox.Show($"Found request:\n\nID: {found.Id}\nTitle: {found.Title}\nStatus: {found.Status}\nDate: {found.DateSubmitted:g}",
                    "Request Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Request with ID '{id}' not found.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnShowDeps_Click(object sender, EventArgs e)
        {
            string id = txtSearchId.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Enter a Request ID to view dependencies.", "Input required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var traversal = graph.DfsTraverse(id);
            if (traversal == null || traversal.Count == 0)
            {
                MessageBox.Show("No dependencies found for this request.", "Dependencies", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show($"Dependency traversal starting from {id}:\n\n{string.Join(" -> ", traversal)}",
                "Dependencies (DFS)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnShowResolved_Click(object sender, EventArgs e)
        {
            dgvServiceStatus.Rows.Clear();
            var resolved = ServiceRequestRepository.GetByStatus("Resolved");
            foreach (var r in resolved)
            {
                dgvServiceStatus.Rows.Add(r.Id, r.Title, r.Status, r.DateSubmitted.ToString("yyyy-MM-dd"));
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (!isEmployee)
            {
                MessageBox.Show("Only employees can update request statuses.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvServiceStatus.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a service request to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedId = dgvServiceStatus.SelectedRows[0].Cells[0].Value.ToString();
            string newStatus = cmbUpdateStatus.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(newStatus))
            {
                MessageBox.Show("Please select a new status from the dropdown.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Find and update in repository
            var all = ServiceRequestRepository.GetAll();
            var req = all.Find(r => r.Id == selectedId);
            if (req != null)
            {
                req.Status = newStatus;
                MessageBox.Show($"Status for {selectedId} updated to '{newStatus}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BuildStructures();
                DisplayPriorityView();
            }
            else
            {
                MessageBox.Show("Could not find the request to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var m = new MainForm();
            m.Show();
            this.Close();
        }
    }
}
