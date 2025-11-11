using System;
using System.Linq;
using System.Windows.Forms;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.Services;

namespace MunicipalServicesApp.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            ApplyDesign();

            // Only allow employees
            if (UserStore.CurrentUser.Role != "Employee")
            {
                MessageBox.Show("Access denied. Only employees can view the dashboard.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            LoadIssues();
        }

        private void ApplyDesign()
        {
            this.BackgroundImage = Properties.Resources.gov;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Text = "Employee Dashboard - Reported Issues";
        }

        private void LoadIssues()
        {
            var issues = IssueRepository.GetAll();
            dgvIssues.DataSource = null;

            if (issues.Count == 0)
            {
                MessageBox.Show("No issues reported yet.", "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvIssues.DataSource = issues;

            if (dgvIssues.Columns["AttachmentPath"] != null)
                dgvIssues.Columns["AttachmentPath"].Visible = false;
            if (dgvIssues.Columns["Description"] != null)
                dgvIssues.Columns["Description"].Visible = false;

            dgvIssues.AutoResizeColumns();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadIssues();
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            if (dgvIssues.CurrentRow == null) return;

            var issue = (Issue)dgvIssues.CurrentRow.DataBoundItem;
            issue.Status = "Resolved";

            IssueRepository.Update(issue);
            dgvIssues.Refresh();

            MessageBox.Show($"Issue '{issue.Category} @ {issue.Location}' marked as resolved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}
