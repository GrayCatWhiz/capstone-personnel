namespace Capstone.Personnel.Actions
{
    partial class uAttendance
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AttendeeView = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.bunifuMaterialTextbox1 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.Filters = new System.Windows.Forms.ComboBox();
            this.AttendeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearSec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Present = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.College = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.AttendeeView)).BeginInit();
            this.SuspendLayout();
            // 
            // AttendeeView
            // 
            this.AttendeeView.AllowUserToAddRows = false;
            this.AttendeeView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.AttendeeView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.AttendeeView.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.AttendeeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AttendeeView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AttendeeView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.AttendeeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AttendeeView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttendeeID,
            this.Fullname,
            this.YearSec,
            this.Present,
            this.College});
            this.AttendeeView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AttendeeView.DoubleBuffered = true;
            this.AttendeeView.EnableHeadersVisualStyles = false;
            this.AttendeeView.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.AttendeeView.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.AttendeeView.Location = new System.Drawing.Point(0, 48);
            this.AttendeeView.Name = "AttendeeView";
            this.AttendeeView.ReadOnly = true;
            this.AttendeeView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.AttendeeView.Size = new System.Drawing.Size(604, 293);
            this.AttendeeView.TabIndex = 0;
            // 
            // bunifuMaterialTextbox1
            // 
            this.bunifuMaterialTextbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuMaterialTextbox1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuMaterialTextbox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuMaterialTextbox1.HintForeColor = System.Drawing.Color.Empty;
            this.bunifuMaterialTextbox1.HintText = "Search for Attendee...";
            this.bunifuMaterialTextbox1.isPassword = false;
            this.bunifuMaterialTextbox1.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.bunifuMaterialTextbox1.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.bunifuMaterialTextbox1.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.bunifuMaterialTextbox1.LineThickness = 2;
            this.bunifuMaterialTextbox1.Location = new System.Drawing.Point(256, 13);
            this.bunifuMaterialTextbox1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuMaterialTextbox1.Name = "bunifuMaterialTextbox1";
            this.bunifuMaterialTextbox1.Size = new System.Drawing.Size(244, 27);
            this.bunifuMaterialTextbox1.TabIndex = 1;
            this.bunifuMaterialTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bunifuMaterialTextbox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bunifuMaterialTextbox1_KeyUp);
            // 
            // Filters
            // 
            this.Filters.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filters.FormattingEnabled = true;
            this.Filters.Items.AddRange(new object[] {
            "Attendee Name",
            "College Code",
            "Year & Section"});
            this.Filters.Location = new System.Drawing.Point(100, 17);
            this.Filters.Name = "Filters";
            this.Filters.Size = new System.Drawing.Size(150, 23);
            this.Filters.Sorted = true;
            this.Filters.TabIndex = 2;
            // 
            // AttendeeID
            // 
            this.AttendeeID.HeaderText = "#";
            this.AttendeeID.Name = "AttendeeID";
            this.AttendeeID.ReadOnly = true;
            // 
            // Fullname
            // 
            this.Fullname.HeaderText = "Full Name";
            this.Fullname.Name = "Fullname";
            this.Fullname.ReadOnly = true;
            // 
            // YearSec
            // 
            this.YearSec.HeaderText = "Year and Section";
            this.YearSec.Name = "YearSec";
            this.YearSec.ReadOnly = true;
            // 
            // Present
            // 
            this.Present.HeaderText = "Present";
            this.Present.Name = "Present";
            this.Present.ReadOnly = true;
            // 
            // College
            // 
            this.College.HeaderText = "College Code";
            this.College.Name = "College";
            this.College.ReadOnly = true;
            // 
            // uAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Filters);
            this.Controls.Add(this.bunifuMaterialTextbox1);
            this.Controls.Add(this.AttendeeView);
            this.Name = "uAttendance";
            this.Size = new System.Drawing.Size(604, 341);
            ((System.ComponentModel.ISupportInitialize)(this.AttendeeView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomDataGrid AttendeeView;
        private Bunifu.Framework.UI.BunifuMaterialTextbox bunifuMaterialTextbox1;
        private System.Windows.Forms.ComboBox Filters;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearSec;
        private System.Windows.Forms.DataGridViewTextBoxColumn Present;
        private System.Windows.Forms.DataGridViewTextBoxColumn College;
    }
}
