using System.Windows.Forms;

namespace MunicipalServicesApp.Forms
{
    partial class ServiceStatusForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvServiceStatus;
        private Button btnBack;
        private Button btnRefresh;
        private Button btnSearch;
        private Button btnShowDeps;
        private Button btnShowResolved;
        private Button btnUpdateStatus;
        private TextBox txtSearchId;
        private Label lblSearch;
        private Label lblUpdateStatus;
        private ComboBox cmbUpdateStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvServiceStatus = new DataGridView();
            this.btnBack = new Button();
            this.btnRefresh = new Button();
            this.txtSearchId = new TextBox();
            this.btnSearch = new Button();
            this.btnShowDeps = new Button();
            this.btnShowResolved = new Button();
            this.lblSearch = new Label();
            this.lblUpdateStatus = new Label();
            this.cmbUpdateStatus = new ComboBox();
            this.btnUpdateStatus = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceStatus)).BeginInit();
            this.SuspendLayout();

            // dgvServiceStatus
            this.dgvServiceStatus.Location = new System.Drawing.Point(12, 60);
            this.dgvServiceStatus.Name = "dgvServiceStatus";
            this.dgvServiceStatus.Size = new System.Drawing.Size(760, 280);
            this.dgvServiceStatus.ReadOnly = true;
            this.dgvServiceStatus.AllowUserToAddRows = false;
            this.dgvServiceStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiceStatus.Columns.Add("Id", "Request ID");
            this.dgvServiceStatus.Columns.Add("Title", "Title");
            this.dgvServiceStatus.Columns.Add("Status", "Status");
            this.dgvServiceStatus.Columns.Add("DateSubmitted", "Date Submitted");

            // lblSearch
            this.lblSearch.Location = new System.Drawing.Point(12, 18);
            this.lblSearch.Text = "Request ID:";
            this.lblSearch.AutoSize = true;

            // txtSearchId
            this.txtSearchId.Location = new System.Drawing.Point(90, 15);
            this.txtSearchId.Size = new System.Drawing.Size(150, 22);

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(250, 12);
            this.btnSearch.Size = new System.Drawing.Size(80, 28);
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnShowDeps
            this.btnShowDeps.Location = new System.Drawing.Point(340, 12);
            this.btnShowDeps.Size = new System.Drawing.Size(140, 28);
            this.btnShowDeps.Text = "Show Dependencies";
            this.btnShowDeps.Click += new System.EventHandler(this.btnShowDeps_Click);

            // btnShowResolved
            this.btnShowResolved.Location = new System.Drawing.Point(490, 12);
            this.btnShowResolved.Size = new System.Drawing.Size(180, 28);
            this.btnShowResolved.Text = "Show Recent Resolved";
            this.btnShowResolved.Click += new System.EventHandler(this.btnShowResolved_Click);

            // lblUpdateStatus
            this.lblUpdateStatus.Location = new System.Drawing.Point(12, 355);
            this.lblUpdateStatus.Text = "Update Status:";
            this.lblUpdateStatus.AutoSize = true;

            // cmbUpdateStatus
            this.cmbUpdateStatus.Location = new System.Drawing.Point(110, 352);
            this.cmbUpdateStatus.Size = new System.Drawing.Size(160, 24);
            this.cmbUpdateStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbUpdateStatus.Items.AddRange(new object[] {
                "Pending",
                "In Progress",
                "Resolved"
            });

            // btnUpdateStatus
            this.btnUpdateStatus.Location = new System.Drawing.Point(280, 350);
            this.btnUpdateStatus.Size = new System.Drawing.Size(120, 28);
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(12, 390);
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnBack
            this.btnBack.Location = new System.Drawing.Point(130, 390);
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // ServiceStatusForm
            this.ClientSize = new System.Drawing.Size(784, 431);
            this.Controls.Add(this.dgvServiceStatus);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearchId);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnShowDeps);
            this.Controls.Add(this.btnShowResolved);
            this.Controls.Add(this.lblUpdateStatus);
            this.Controls.Add(this.cmbUpdateStatus);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnBack);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Service Request Status";

            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
