using System;
using System.Windows.Forms;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.Services;

namespace MunicipalServicesApp.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ApplyRoleAccess();
        }

        private void ApplyRoleAccess()
        {
            if (UserStore.CurrentUser != null && UserStore.CurrentUser.Role == "Resident")
            {
                btnDashboard.Visible = false;
            }
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            var reportIssuesForm = new ReportIssuesForm();
            reportIssuesForm.Show();
            this.Hide();
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            var eventsForm = new EventsForm();
            eventsForm.ShowDialog();
        }

        private void btnServiceStatus_Click(object sender, EventArgs e)
        {
            var serviceStatusForm = new ServiceStatusForm();
            serviceStatusForm.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (UserStore.CurrentUser != null && UserStore.CurrentUser.Role == "Employee")
            {
                var dashboardForm = new DashboardForm();
                dashboardForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Only employees can access the Dashboard.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
