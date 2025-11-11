using System.Windows.Forms;

namespace MunicipalServicesApp.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvIssues;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnResolve;
        private System.Windows.Forms.Label lblTitle;
        private ComboBox cmbStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbStatus = new ComboBox();
            this.cmbStatus.Location = new System.Drawing.Point(220, 345);
            this.cmbStatus.Size = new System.Drawing.Size(150, 30);
            this.cmbStatus.Items.AddRange(new object[] { "Pending", "In Progress", "Resolved" });
            this.Controls.Add(this.cmbStatus);
            this.dgvIssues = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnResolve = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssues)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(200, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 21);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Reported Issues Dashboard";

            // dgvIssues
            this.dgvIssues.AllowUserToAddRows = false;
            this.dgvIssues.AllowUserToDeleteRows = false;
            this.dgvIssues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIssues.BackgroundColor = System.Drawing.Color.White;
            this.dgvIssues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssues.Location = new System.Drawing.Point(12, 50);
            this.dgvIssues.MultiSelect = false;
            this.dgvIssues.Name = "dgvIssues";
            this.dgvIssues.ReadOnly = true;
            this.dgvIssues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIssues.Size = new System.Drawing.Size(560, 280);
            this.dgvIssues.TabIndex = 0;

            // btnBack
            this.btnBack.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnBack.Location = new System.Drawing.Point(12, 345);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(90, 30);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "← Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // btnResolve
            this.btnResolve.BackColor = System.Drawing.Color.PaleGreen;
            this.btnResolve.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnResolve.Location = new System.Drawing.Point(482, 345);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(90, 30);
            this.btnResolve.TabIndex = 2;
            this.btnResolve.Text = "Resolve ✔";
            this.btnResolve.UseVisualStyleBackColor = false;
            this.btnResolve.Click += new System.EventHandler(this.btnResolve_Click);

            // DashboardForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(584, 391);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnResolve);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvIssues);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
