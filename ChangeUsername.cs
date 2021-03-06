﻿using Capstone.Personnel.Tools;
using Capstone.Personnel.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone.Personnel
{
    public partial class ChangeUsername : Form
    {
        public ChangeUsername()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (newUsername.Text.Trim().Length <= 15 && newUsername.Text.Trim().Length >= 8)
            {
                if (newUsername.Text == UserInfo.Username)
                {
                    MessageBox.Show("You are about to use the same username.");
                }
                else // The real update
                {
                    // Check if it already exists
                    bool found = false;
                    var reader = SqlUtils.ExecuteQueryReader("Select username from personnel where username='" + newUsername.Text +"'", false);
                    while (reader.Read())
                    {
                        found = true;
                    }
                    if (found == true)
                        MessageBox.Show("Username is already in used. Please Use different one.");
                    else
                    {
                        SqlUtils.ExecuteQuery("update personnel set username='" + newUsername.Text + "' where userid=" + UserInfo.UserId,false);
                        UserInfo.Username = newUsername.Text.Trim();
                        MessageBox.Show("Username Updated Successfully");

                        //Refresh by using setter
                    }
                }
            }
            else
            {
                MessageBox.Show("Username must be atleast 8 characters and not long than 15.");
            }
            
        }
    }
}
