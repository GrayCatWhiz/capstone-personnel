using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone.Personnel.Actions;
using Capstone.Personnel.Tools;
using Capstone.Personnel.Utilities;

namespace Capstone.Personnel
{
    public partial class PersonnelDashboard : Form
    {
        public PersonnelDashboard()
        {
            InitializeComponent();
            Load += InitData;

        }

        private void InitData(object sender, EventArgs e)
        {
            EventInfo.Text = "You are currently assigned at " + UserInfo.EventName;
            Fullname.Text = UserInfo.Fullname;
            var phTime = DateTime.Now.Hour;

            if (phTime >= 6 && phTime <= 12)
                Greeter.Text = "HELLO, GOOD MORNING,";
            else if (phTime >= 12 && phTime <= 18)
                Greeter.Text = "HI, GOOD AFTERNOON";
            else
                Greeter.Text = "HMM, GOOD EVENING";
        }
    
        private string prompt = "Please register an attendee to proceed.";
        // Registeration Button
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Navigator.Text = "Attendee Registration";
            int count = 0;
            SqlDataReader rd = SqlUtils.ExecuteQueryReader("select count(*) from custom_event where event_open=1", false);
            while (rd.Read())
            {
                count = (Int32)rd.GetValue(0);
            }
            if (count < 1)
            {
                MessageBox.Show("Please contact your local administrator for adding/opening events for registration");
            }
            else
            {
                uRegister.Instance = null;
                MainPane.Controls.Add(uRegister.Instance);

                uRegister.Instance.Dock = DockStyle.Fill;
                uRegister.Instance.Init();
                uRegister.Instance.BringToFront();
            }

        }
        // College Add and update
        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Navigator.Text = "Manage College Informations";
            MainPane.Controls.Add(uCollege.Instance);
            uCollege.Instance.Dock = DockStyle.Fill;
            uCollege.Instance.ReloadData();
            uCollege.Instance.BringToFront();
        }

        // Attendance Checking
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Navigator.Text = "Start Checking Attendance";
            var rd = SqlUtils.ExecuteQueryReader("select count(*) from attendee",false);
            if (rd.HasRows.Equals(false))
            {
                MessageBox.Show(prompt);
            }
            else
            {
                var register = uOnRegister.getInstance();
                MainPane.Controls.Add(register);
                register.Dock = DockStyle.Fill;
                register.BringToFront();
            }

        }
        // View
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Navigator.Text = "View All Attendees";
            var rd = SqlUtils.ExecuteQueryReader("select count(*) from attendee", false);
            if (rd.HasRows.Equals(false))
            {
                MessageBox.Show(prompt);
            }
            else
            {
                MainPane.Controls.Add(uAttendance.Instance);
                uAttendance.Instance.Dock = DockStyle.Fill;
                uAttendance.Instance.Init();
                uAttendance.Instance.BringToFront();
            }

        }
        // update Attendee
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Navigator.Text = "Attendee Update Information";
            var rd = SqlUtils.ExecuteQueryReader("select count(*) from attendee", false);
            if (rd.HasRows.Equals(false))
                MessageBox.Show(prompt);
            else
            {
                var update = uAttendeeUpdate.getInstance();
                MainPane.Controls.Add(update);
                update.Init();
                update.Dock = DockStyle.Fill;
                update.BringToFront();

            }

        }
        // Change Password 
   
        private void LogoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var action = MessageBox.Show("Are you sure you want to logout ?","Attention",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (action.Equals(DialogResult.Yes))
            {
                Application.Exit();
            }
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            Navigator.Text = "User Profile";
            var userprofile = UserProfile.Instance();
            MainPane.Controls.Add(userprofile);
            userprofile.SetDetails();
            userprofile.Dock = DockStyle.Fill;
            userprofile.BringToFront();
        }
    }
}
