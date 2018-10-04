namespace Capstone.Personnel
{
    partial class UserProfile
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
            this.uname = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.Username = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FirstName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.LastName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.ChangePasswordBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ChangeLastName = new System.Windows.Forms.Label();
            this.ChangeFirstName = new System.Windows.Forms.Label();
            this.ChangeUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uname
            // 
            this.uname.BorderColorFocused = System.Drawing.Color.Blue;
            this.uname.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uname.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.uname.BorderThickness = 2;
            this.uname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uname.Enabled = false;
            this.uname.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uname.isPassword = false;
            this.uname.Location = new System.Drawing.Point(172, 86);
            this.uname.Margin = new System.Windows.Forms.Padding(4);
            this.uname.Name = "uname";
            this.uname.Size = new System.Drawing.Size(291, 38);
            this.uname.TabIndex = 0;
            this.uname.Text = "User Name";
            this.uname.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(96, 95);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(65, 15);
            this.Username.TabIndex = 1;
            this.Username.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "First Name";
            // 
            // FirstName
            // 
            this.FirstName.BorderColorFocused = System.Drawing.Color.Blue;
            this.FirstName.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FirstName.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.FirstName.BorderThickness = 2;
            this.FirstName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FirstName.Enabled = false;
            this.FirstName.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FirstName.isPassword = false;
            this.FirstName.Location = new System.Drawing.Point(172, 142);
            this.FirstName.Margin = new System.Windows.Forms.Padding(4);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(291, 38);
            this.FirstName.TabIndex = 2;
            this.FirstName.Text = "First Name";
            this.FirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(96, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Last Name";
            // 
            // LastName
            // 
            this.LastName.BorderColorFocused = System.Drawing.Color.Blue;
            this.LastName.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LastName.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.LastName.BorderThickness = 2;
            this.LastName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LastName.Enabled = false;
            this.LastName.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LastName.isPassword = false;
            this.LastName.Location = new System.Drawing.Point(172, 198);
            this.LastName.Margin = new System.Windows.Forms.Padding(4);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(291, 38);
            this.LastName.TabIndex = 4;
            this.LastName.Text = "Last Name";
            this.LastName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ChangePasswordBtn
            // 
            this.ChangePasswordBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ChangePasswordBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ChangePasswordBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ChangePasswordBtn.BorderRadius = 0;
            this.ChangePasswordBtn.ButtonText = "Change Password";
            this.ChangePasswordBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangePasswordBtn.DisabledColor = System.Drawing.Color.Gray;
            this.ChangePasswordBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.ChangePasswordBtn.Iconimage = null;
            this.ChangePasswordBtn.Iconimage_right = null;
            this.ChangePasswordBtn.Iconimage_right_Selected = null;
            this.ChangePasswordBtn.Iconimage_Selected = null;
            this.ChangePasswordBtn.IconMarginLeft = 0;
            this.ChangePasswordBtn.IconMarginRight = 0;
            this.ChangePasswordBtn.IconRightVisible = true;
            this.ChangePasswordBtn.IconRightZoom = 0D;
            this.ChangePasswordBtn.IconVisible = true;
            this.ChangePasswordBtn.IconZoom = 90D;
            this.ChangePasswordBtn.IsTab = false;
            this.ChangePasswordBtn.Location = new System.Drawing.Point(99, 259);
            this.ChangePasswordBtn.Name = "ChangePasswordBtn";
            this.ChangePasswordBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ChangePasswordBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.ChangePasswordBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.ChangePasswordBtn.selected = false;
            this.ChangePasswordBtn.Size = new System.Drawing.Size(421, 37);
            this.ChangePasswordBtn.TabIndex = 6;
            this.ChangePasswordBtn.Text = "Change Password";
            this.ChangePasswordBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChangePasswordBtn.Textcolor = System.Drawing.Color.White;
            this.ChangePasswordBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePasswordBtn.Click += new System.EventHandler(this.ChangePasswordBtn_Click);
            // 
            // ChangeLastName
            // 
            this.ChangeLastName.AutoSize = true;
            this.ChangeLastName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangeLastName.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ChangeLastName.Location = new System.Drawing.Point(470, 210);
            this.ChangeLastName.Name = "ChangeLastName";
            this.ChangeLastName.Size = new System.Drawing.Size(50, 15);
            this.ChangeLastName.TabIndex = 9;
            this.ChangeLastName.Text = "Change";
            this.ChangeLastName.Click += new System.EventHandler(this.ChangeLastName_Click);
            // 
            // ChangeFirstName
            // 
            this.ChangeFirstName.AutoSize = true;
            this.ChangeFirstName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangeFirstName.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ChangeFirstName.Location = new System.Drawing.Point(470, 152);
            this.ChangeFirstName.Name = "ChangeFirstName";
            this.ChangeFirstName.Size = new System.Drawing.Size(50, 15);
            this.ChangeFirstName.TabIndex = 8;
            this.ChangeFirstName.Text = "Change";
            this.ChangeFirstName.Click += new System.EventHandler(this.ChangeFirstName_Click);
            // 
            // ChangeUsername
            // 
            this.ChangeUsername.AutoSize = true;
            this.ChangeUsername.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangeUsername.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ChangeUsername.Location = new System.Drawing.Point(470, 95);
            this.ChangeUsername.Name = "ChangeUsername";
            this.ChangeUsername.Size = new System.Drawing.Size(50, 15);
            this.ChangeUsername.TabIndex = 7;
            this.ChangeUsername.Text = "Change";
            this.ChangeUsername.Click += new System.EventHandler(this.ChangeUsername_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.label1.Location = new System.Drawing.Point(151, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "You can change your basic personal information instantly";
            // 
            // UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChangeLastName);
            this.Controls.Add(this.ChangeFirstName);
            this.Controls.Add(this.ChangeUsername);
            this.Controls.Add(this.ChangePasswordBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.uname);
            this.Name = "UserProfile";
            this.Size = new System.Drawing.Size(604, 341);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuMetroTextbox uname;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuMetroTextbox FirstName;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuMetroTextbox LastName;
        private Bunifu.Framework.UI.BunifuFlatButton ChangePasswordBtn;
        private System.Windows.Forms.Label ChangeLastName;
        private System.Windows.Forms.Label ChangeFirstName;
        private System.Windows.Forms.Label ChangeUsername;
        private System.Windows.Forms.Label label1;
    }
}
