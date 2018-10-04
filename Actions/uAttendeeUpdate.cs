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
using Capstone.Personnel.Utilities;
using System.Text.RegularExpressions;

namespace Capstone.Personnel.Actions
{
    public partial class uAttendeeUpdate : UserControl
    {
        private int AttendeeToUpdate; // Person who are going to update xD
        List<string> NameLists;
        List<int> IdLists;
        List<string> Mixed; // Format of attendee_number:attendee_name
        string UniversalAttendeeId = "";
        public uAttendeeUpdate()
        {
            InitializeComponent();
            NameLists = new List<string>();
            IdLists = new List<int>();
            Mixed = new List<string>();
        }

        public static uAttendeeUpdate getInstance()
        {
            return new uAttendeeUpdate();
        }

        

        public void Init()
        {
            college.Items.Clear();
            college.Items.Add("Please Select College Code");
            college.SelectedIndex = 0;
            var rdx = SqlUtils.ExecuteQueryReader("select college_code from college", false);
            while (rdx.Read())
            {
                college.Items.Add(rdx.GetString(0));
            }

            AttendeeNames.Clear();
            AttendeeNames.AddItem("Select Name of Attendee");
            AttendeeNames.selectedIndex = 0;
            var rdy = SqlUtils.ExecuteQueryReader("select attendee_id,attendee_fullname from attendee where eventid="+UserInfo.EventId, false);
            while (rdy.Read())
            {
                //AttendeeNames.AddItem((string)rdy["attendee_fullname"]);
                NameLists.Add((string)rdy["attendee_fullname"]);
                IdLists.Add((int)rdy["attendee_id"]);
            }
            int idCounter = 0;
            foreach (var name in NameLists)
            {
                var data = IdLists[idCounter].ToString() + ':' + name;
                AttendeeNames.AddItem(data);
                Mixed.Add(data);
                idCounter += 1;
            }

            

        }
        // Update Button
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (fullname.Text.Trim().Length > 6)
            {
                string attendeeName = AttendeeNames.selectedValue.Trim();
                int id = attendeeName.IndexOf(':');
                int attendee = Convert.ToInt32(attendeeName.Substring(0, id));
                try
                {
                    SqlUtils.ExecuteInsert("update attendee set attendee_fullname=@full,attendee_yrsec=@yrsec,college_code=@code where attendee_id=@aid", new string[] { "@full", "@yrsec", "@code", "@aid" }, new string[] { fullname.Text.Trim(), bunifuCheckbox1.Checked.Equals(false) ? "Non-Student" : yearsec.Text.Trim(), bunifuCheckbox1.Checked.Equals(false) ? "N/A":college.Items[college.SelectedIndex].ToString(), attendee.ToString()});

                    uGenerate Generator = new uGenerate(fullname.Text);
                    Controls.Add(Generator);
                    Generator.Serialize(UniversalAttendeeId);
                    Generator.Dock = DockStyle.Fill;
                    Generator.BringToFront();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            college.Visible = bunifuCheckbox1.Checked;
            yearsec.Visible = bunifuCheckbox1.Checked;
            label3.Visible = bunifuCheckbox1.Checked;
            label4.Visible = bunifuCheckbox1.Checked;
        }
        //int UpdateId = 0; // Fix tommorrow Implement to all Universe
        // Fix Update info via on key up searchbar
        private void SearchBar_KeyUp(object sender, KeyEventArgs e)
        {
            var pattern = new Regex(SearchBar.Text.ToLower());
            AttendeeNames.Clear();
            AttendeeNames.AddItem("Select Name of Attendee");
            if (SearchBar.Text.Trim().Length > 0)
            {
                int result = 0;
                
                foreach (string mix in Mixed)
                {
                    if (pattern.IsMatch(mix.ToLower()))
                    {
                        AttendeeNames.AddItem(mix);
                        //NameLists.IndexOf(name);
                        //AttendeeNames.AddItem(name);
                        result += 1;
                    }
                }
                if (result <= 0)
                {
                    AttendeeNames.Clear();
                    AttendeeNames.AddItem("No Result Found");
                }

                AttendeeNames.selectedIndex = 0;

            }
            else
            {
                AttendeeNames.selectedIndex = 0;
                int z = 0;
                foreach (var mix in Mixed)
                {
                    AttendeeNames.AddItem(mix);

                    z += 1;
                }
            }
        }

        private void AttendeeNames_onItemSelected(object sender, EventArgs e)
        {
            if (AttendeeNames.selectedIndex != 0)
            {
                string attendeeName = AttendeeNames.selectedValue.Trim();
                int id = attendeeName.IndexOf(':');
                int attendee = Convert.ToInt32(attendeeName.Substring(0,id));
                string yearSec = "";
                string collegeCode = "";
                var reader = SqlUtils.ExecuteQueryReader("select attendee_yrsec,college_code from attendee where attendee_id="+attendee,false);
                while (reader.Read())
                {
                    yearSec = (string) reader["attendee_yrsec"];
                    collegeCode = (string)reader["college_code"];
                }
                reader.Close();

                // Process
                fullname.Text = attendeeName.Substring(id + 1,attendeeName.Length - (id + 1));
                yearsec.Text = yearSec;
                if (collegeCode == "N/A")
                    bunifuCheckbox1.Checked = false;
                else
                    bunifuCheckbox1.Checked = true;
                bunifuCheckbox1_OnChange(null,null);
                int selectedCollege = college.Items.IndexOf(collegeCode);
                college.SelectedIndex = selectedCollege;

                UniversalAttendeeId = attendee.ToString();
            }
            else
            {
                fullname.ResetText();
                yearsec.ResetText();
                college.SelectedIndex = 0;
            }
        }

        private void RemoveLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AttendeeNames.selectedIndex != 0)
            {
                var result = MessageBox.Show("This cannot be undone, remove it permanently to the attendees ?", "Alert", MessageBoxButtons.OKCancel);
                if (result.Equals(DialogResult.OK))
                {
                    SqlUtils.ExecuteQuery("delete from attendee where attendee_id=" + UniversalAttendeeId, false);
                    AttendeeNames.RemoveAt(AttendeeNames.selectedIndex);
                    AttendeeNames.selectedIndex = 0;
                }
            }
            
        }

        private void college_SelectedValueChanged(object sender, EventArgs e)
        {
            if (college.Items[college.SelectedIndex].ToString() == "N/A")
                yearsec.Text = "Non-Student";
            else
                yearsec.Text = "";
        }

    }
}
