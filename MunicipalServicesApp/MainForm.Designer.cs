using System;
using System.Windows.Forms;

namespace MunicipalServicesApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel headerPanel;
        private PictureBox picLogo;
        private Label lblTitle;
        private Label lblSubtitle;
        private FlowLayoutPanel menuPanel;
        private Button btnReportIssues;
        private Button btnEvents;
        private Button btnServiceStatus;
        private Button btnDashboard;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.headerPanel = new Panel();
            this.picLogo = new PictureBox();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.menuPanel = new FlowLayoutPanel();
            this.btnReportIssues = new Button();
            this.btnEvents = new Button();
            this.btnServiceStatus = new Button();
            this.btnDashboard = new Button();

            // Header Panel
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(10, 90, 138);
            this.headerPanel.Controls.Add(this.picLogo);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.lblSubtitle);
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Height = 100;

            // Logo
            this.picLogo.Image = Properties.Resources.Bayview_flag; 
            this.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.picLogo.Location = new System.Drawing.Point(20, 15);
            this.picLogo.Size = new System.Drawing.Size(70, 70);

            // Title
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(100, 15);
            this.lblTitle.Size = new System.Drawing.Size(500, 35);
            this.lblTitle.Text = "Bayview Metropolitan Municipality";

            // Subtitle
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSubtitle.Location = new System.Drawing.Point(102, 55);
            this.lblSubtitle.Size = new System.Drawing.Size(400, 25);
            this.lblSubtitle.Text = "Digital Citizen Services Portal";

            // Menu Panel
            this.menuPanel.FlowDirection = FlowDirection.TopDown;
            this.menuPanel.WrapContents = false;
            this.menuPanel.Padding = new Padding(20);
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(180, 255, 255, 255);
            this.menuPanel.Size = new System.Drawing.Size(340, 300);
            this.menuPanel.Location = new System.Drawing.Point((600 - 340) / 2, (400 - 300) / 2);
            this.menuPanel.Anchor = AnchorStyles.None;

            // Buttons
            SetupButton(btnReportIssues, "Report Issues", new EventHandler(this.btnReportIssues_Click));
            SetupButton(btnEvents, "Local Events & Announcements", new EventHandler(this.btnEvents_Click));
            SetupButton(btnServiceStatus, "Service Request Status", new EventHandler(this.btnServiceStatus_Click));
            SetupButton(btnDashboard, "Dashboard", new EventHandler(this.btnDashboard_Click));

            // Add buttons to panel
            this.menuPanel.Controls.AddRange(new Control[] {
                btnReportIssues,
                btnEvents,
                btnServiceStatus,
                btnDashboard
            });

            // Main Form
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.headerPanel);
            this.BackgroundImage = Properties.Resources.gov;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Main Menu";

            // Role-based visibility
            ApplyRoleSettings();
        }

        private void SetupButton(Button btn, string text, EventHandler clickEvent)
        {
            btn.Text = text;
            btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btn.BackColor = System.Drawing.Color.WhiteSmoke;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            btn.FlatAppearance.BorderSize = 2;
            btn.Margin = new Padding(10);
            btn.Size = new System.Drawing.Size(300, 50);
            btn.Click += clickEvent;
        }

        private void ApplyRoleSettings()
        {
            if (UserStore.CurrentUser == null) return;

            if (UserStore.CurrentUser.Role == "Resident")
            {
                btnReportIssues.Visible = true;
                btnDashboard.Visible = false;
            }
            else if (UserStore.CurrentUser.Role == "Employee")
            {
                btnReportIssues.Visible = false;
                btnDashboard.Visible = true;
            }
        }
    }
}
