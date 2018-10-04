using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone.Personnel.Tools;
using Capstone.Personnel.Utilities;

namespace Capstone.Personnel
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public void SetOpenEventLists()
        {
           var reader = SqlUtils.ExecuteQueryReader("SELECT event_name FROM custom_event WHERE event_open=1",false);
            OpenEventLists.AddItem("Select Your Assigned Event");
            OpenEventLists.selectedIndex = 0;
            while (reader.Read())
            {
                OpenEventLists.AddItem((string) reader.GetValue(0));
            }
            reader.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var reader = SqlUtils.ExecuteQueryReader("select count (*) from personnel",false);
            
            if (!reader.HasRows)
            {
                MessageBox.Show("There is no personnel accounts, contact your local administrator");
            }
            else
            {
                if (username.Text.Trim().Length <= 0 || passwd.Text.Trim().Length <= 0 || OpenEventLists.selectedIndex == 0)
                {
                    MessageBox.Show("Please fill-up or select necessary fields to proceed!");
                }
                else if (VerifyUser(username.Text.Trim(),passwd.Text.Trim(),OpenEventLists.selectedValue))
                {
                    var dashboard = new PersonnelDashboard();
                    var rd = SqlUtils.ExecuteQueryReader("select last_name, given_name,userid as 'Fullname' from personnel where username='"+username.Text +"'",false);
                    while (rd.Read())
                    {
                        UserInfo.Givenname = rd.GetString(1);
                        UserInfo.Lastname = rd.GetString(0);
                        UserInfo.UserId = rd.GetValue(2).ToString();
                    }

                    var tempCost = 0;
                    var location = "";
                    var rd0 = SqlUtils.ExecuteQueryReader("select event_cost,event_location from custom_event where eventid=" + UserInfo.EventId, false);
                    while (rd0.Read())
                    {
                        tempCost = Convert.ToInt32(rd0["event_cost"]);
                        location = rd0["event_location"].ToString();
                    }
                    rd.Close();

                    UserInfo.Username = username.Text;
                    UserInfo.Fullname = UserInfo.Lastname + ", " + UserInfo.Givenname;
                    UserInfo.EventName = OpenEventLists.selectedValue;
                    UserInfo.EventCost = tempCost;
                    UserInfo.EventLocation = location;

                    dashboard.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Wrong username or password");
                }

            }
        }

        private bool VerifyUser(string username, string password, string assignedEvent)
        {
            UserInfo.EventId = 0;
            var findEventId = SqlUtils.ExecuteQueryReader("SELECT eventid from custom_event where event_name='"+assignedEvent+"'",false);
            while (findEventId.Read())
            {
                UserInfo.EventId = findEventId.GetInt32(0);
            }
            findEventId.Close();
            bool userFound = false;
            var findUser = SqlUtils.ExecuteQueryReader("SELECT username from personnel where username='"+username+"' and passwd='"+password+"' and eventid="+UserInfo.EventId.ToString(),false);
            while (findUser.Read())
            {
                userFound = true;
            }

            return userFound;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please contact your local adminstrator to create your new account.","Notification",MessageBoxButtons.OK);
        }

        private void passwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                loginBtn_Click(null,EventArgs.Empty);
            }
        }
    }
}
