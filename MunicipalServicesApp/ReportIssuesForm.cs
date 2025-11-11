using System;
using System.Windows.Forms;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.Services;

namespace MunicipalServicesApp.Forms
{
    public partial class ReportIssuesForm : Form
    {
        public ReportIssuesForm()
        {
            InitializeComponent();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtAttachment.Text = ofd.FileName;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                errorProvider1.SetError(txtLocation, "Location is required.");
                valid = false;
            }
            if (cmbCategory.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbCategory, "Select a category.");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                errorProvider1.SetError(rtbDescription, "Description is required.");
                valid = false;
            }

            if (!valid) return;

            // Create ServiceRequest
            var id = $"REQ{DateTime.Now.Ticks % 1000000:D6}";
            var request = new ServiceRequest(
                id,
                $"{cmbCategory.SelectedItem} Issue - {txtLocation.Text}",
                "Pending",
                DateTime.Now
            );

            ServiceRequestRepository.Add(request);

            var issue = new Issue
            {
                Location = txtLocation.Text,
                Category = cmbCategory.SelectedItem.ToString(),
                Description = rtbDescription.Text,
                AttachmentPath = txtAttachment.Text,
                SubmittedAt = DateTime.Now.ToString("g")
            };
            IssueRepository.Add(issue);

            progressBar.Value = 100;
            MessageBox.Show("Issue submitted successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();
            txtAttachment.Clear();
            progressBar.Value = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }
    }
}
