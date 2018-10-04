using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone.Personnel.Tools;

namespace Capstone.Personnel.Actions
{
    public partial class uCollege : UserControl
    {
        public uCollege()
        {
            InitializeComponent();
        }

        private static uCollege _instance = null;
        public static uCollege Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new uCollege();
                }
                return _instance;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (collegeCode.Text.Trim().Length < 2 || collegeDescription.Text.Trim().Length < 8)
                {
                    MessageBox.Show("Please valid your input");
                }
                else
                {
                    SqlUtils.ExecuteInsert("insert into college(college_code,college_desc) values(@code,@desc)", new string[] { "@code", "@desc" }, new string[] { collegeCode.Text.Trim(), collegeDescription.Text.Trim() });
                    ReloadData();
                    MessageBox.Show("Added Successfully");
                    collegeDescription.Text = "";
                    collegeCode.Text = "";
                    collegeCode.Focus();
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Cannot Add,Item cannot be duplicated !");
            }

        }

        public void ReloadData()
        {
            bunifuDropdown1.Clear();
            bunifuDropdown1.AddItem("Select college code");
            bunifuDropdown1.selectedIndex = 0;
            SqlDataReader rd = SqlUtils.ExecuteQueryReader("select college_code from college",false);
            while (rd.Read())
            {
                bunifuDropdown1.AddItem(rd.GetString(0));
            }
            rd.Close();
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            SqlDataReader rd = SqlUtils.ExecuteQueryReader("select college_desc from college where college_code='" + bunifuDropdown1.selectedValue + "'", false);
            while (rd.Read())
            {
                updateDesc.Text = rd.GetString(0);
            }
            rd.Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (updateDesc.Text.Trim().Length < 8)
            {
                MessageBox.Show("College Description must be greater than 8 characters");
            }
            else
            {
                SqlUtils.ExecuteInsert("update college set college_desc=@desc where college_code=@code",new string[] {"@desc","@code"},new string[] {updateDesc.Text.Trim(),bunifuDropdown1.selectedValue});
                ReloadData();
                updateDesc.Text = "";
                MessageBox.Show("Updated Successfully!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (bunifuDropdown1.selectedIndex == 0)
                {
                    MessageBox.Show("Please select a valid item");
                }
                else
                {

                    var res = MessageBox.Show("Are you sure you want to delete, this cannot be undone ?", "Attention", MessageBoxButtons.OKCancel);
                    if (res.Equals(DialogResult.OK))
                    {
                        SqlUtils.ExecuteQuery("delete from college where college_code='" + bunifuDropdown1.selectedValue + "'", false);
                        updateDesc.Text = "";
                        ReloadData();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You cannot delete this while their is a registered attendee here, if so you can delete it under update attendee section of this dashboard.");
            }
        }
    }
}
