using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.QrCode;
using ZXing.Common;
using ZXing.Rendering;
using ZXing;
using Capstone.Personnel.Tools;
using Capstone.Personnel.Utilities;

namespace Capstone.Personnel.Actions
{
    public partial class uRegister : UserControl
    {
        public uRegister()
        {
            InitializeComponent();
        }
        private static uRegister _instance = null;
        public static uRegister Instance
        {
            get
            {
                if( _instance == null) {
                    _instance = new uRegister();
                }
                return _instance;
            }
            set
            {
                _instance = null;
            }
        }

        public void Init()
        {
            ReloadCollege();
            // make 2000 to money format of 2,000
            string money = UserInfo.EventCost.ToString();
            int c = 1;
            for (int i = money.Length - 1; i >= 0; i--)
            {
                if (c == 3 && (i - 1) >= 0)
                {
                    c = 0;
                    money = money.Insert(i,",");
                }
                c += 1;
            }
            EventCost.Text = money + " Pesos";
        }

        private string _collegeCode;

        private void ReloadCollege()
        {
           
            college.Clear();
            college.AddItem("Select College");
            college.selectedIndex = 0;


            SqlDataReader reader = SqlUtils.ExecuteQueryReader("select college_code from college where college_code != 'N/A'" , false);
            while (reader.Read())
            {
                college.AddItem(reader.GetString(0));
            }
            reader.Close();
        }   


        private void ResetField()
        {
            bunifuCheckbox1.Checked = false;
            fullname.Text = "";
            yearsec.Text = "";
            college.selectedIndex= 0;
          
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            if (!bunifuCheckbox1.Checked)
            {
                yearsec.Text = "Non-Student";
                _collegeCode = "N/A";
            }
            if (fullname.Text.Trim().Length < 6)
            {
                MessageBox.Show("Please validate your fields");
            }
            else
            {
                try
                {
                    // Check if event is open
                    SqlUtils.ExecuteInsert("insert into attendee(attendee_fullname,attendee_yrsec,college_code,eventid,attendee_present) values (@name,@yrsec,@code,@id,@present)", new string[] { "@name", "@yrsec", "@code", "@id","@present" }, new string[] { fullname.Text.Trim(), yearsec.Text.Trim(), bunifuCheckbox1.Checked == false ? "N/A" : college.selectedValue, UserInfo.EventId.ToString(), "0" });

                    var rd = SqlUtils.ExecuteQueryReader("select attendee_id from attendee order by attendee_id", false);
                    string Id = "";

                    while (rd.Read())
                    {
                        Id = Convert.ToString(rd["attendee_id"]);
                    }
                    // Update event 
                    int registered = 0;
                    var reader = SqlUtils.ExecuteQueryReader("select count(*) as registered from attendee where eventid=" + UserInfo.EventId, false);
                    while (reader.Read())
                    {
                        registered = (int)reader["registered"];
                    }
                    SqlUtils.ExecuteQuery("update custom_event set event_registered=" + registered + " where eventid=" + UserInfo.EventId, false);

                    var Generator = new uGenerate(fullname.Text);
                    RegisterPanel.Controls.Add(Generator);
                    Generator.Serialize(Id);
                    Generator.Dock = DockStyle.Fill;
                    Generator.BringToFront();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please add 'N/A' in college code and 'Non-Student' in description under Manage College Section of this dashboard. Otherwise addition will going to fail." + ex.Message, "Incomplete Setup: College");
                }
            }

        }

        private void bunifuCheckbox1_OnChange_1(object sender, EventArgs e)
        {
            yearsec.Visible = bunifuCheckbox1.Checked;
            college.Visible = bunifuCheckbox1.Checked;
            label3.Visible = bunifuCheckbox1.Checked;
            label4.Visible = bunifuCheckbox1.Checked;
        }

        private void college_onItemSelected(object sender, EventArgs e)
        {
            _collegeCode = college.selectedValue;
        }
    }
}
