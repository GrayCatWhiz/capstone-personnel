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
    public partial class uAttendance : UserControl
    {
        public uAttendance()
        {
            InitializeComponent();
        }

        private static uAttendance _instance = null;
        public static uAttendance Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uAttendance();
                return _instance;
            }
        }


        public void Init()
        {
            Filters.SelectedIndex = 0;
            AttendeeView.Rows.Clear();
            SqlDataReader rd = SqlUtils.ExecuteQueryReader("select attendee_id,attendee_fullname,attendee_yrsec,attendee_present,college_code from attendee where eventid="+UserInfo.EventId,false);
            while (rd.Read())
            {
                var data =  rd.GetValue(0);
                var data1 =  rd.GetValue(1);
                var data2 =  rd.GetValue(2);
                var data3 =  rd.GetValue(3);
                var data4 = rd.GetValue(4);

                AttendeeView.Rows.Add();
                AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[0].Value = data;
                AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[1].Value = data1;
                AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[2].Value = data2;
                AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[3].Value = data3;
                AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[4].Value = data4; 
            }
            
        }
        // Search for...
        private void bunifuMaterialTextbox1_KeyUp(object sender, KeyEventArgs e)
        {
            string keyword = bunifuMaterialTextbox1.Text.ToLower();
            AttendeeView.Rows.Clear();
            if (keyword.Trim().Length > 0)
            {
                var pattern = new Regex(bunifuMaterialTextbox1.Text);
                SqlDataReader rd = SqlUtils.ExecuteQueryReader("select attendee_id,attendee_fullname,attendee_yrsec,attendee_present,college_code from attendee where eventid="+UserInfo.EventId, false);
                while (rd.Read())
                {
                    if (Filters.SelectedIndex == 0 && pattern.IsMatch((string)rd["attendee_fullname"].ToString().ToLower())) // Name - 0 YearSec - 1 Code -2
                    {
                        AttendeeView.Rows.Add();
                        AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[0].Value = rd["attendee_id"];
                        AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[1].Value = rd["attendee_fullname"];
                        AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[2].Value = rd["attendee_yrsec"];
                        AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[3].Value = rd["attendee_present"];
                        AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[4].Value = rd["college_code"];
                    }
                    else if (Filters.SelectedIndex == 1 && pattern.IsMatch((string)rd["college_code"].ToString().ToLower())) // Name - 0 YearSec - 1 Code -2
                    {
                        AttendeeView.Rows.Add();
                        AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[0].Value = rd["attendee_id"];
                        AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[1].Value = rd["attendee_fullname"];
                        AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[2].Value = rd["attendee_yrsec"];
                        AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[3].Value = rd["attendee_present"];
                        AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[4].Value = rd["college_code"];
                    }
                    else if (Filters.SelectedIndex == 2 && pattern.IsMatch((string)rd["attendee_yrsec"].ToString().ToLower())) // Name - 0 YearSec - 1 Code -2
                    {
                        AttendeeView.Rows.Add();
                        AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[0].Value = rd["attendee_id"];
                        AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[1].Value = rd["attendee_fullname"];
                        AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[2].Value = rd["attendee_yrsec"];
                        AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[3].Value = rd["attendee_present"];
                        AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[4].Value = rd["college_code"];
                    }


                }
            }
            else
            {
                SqlDataReader rd = SqlUtils.ExecuteQueryReader("select attendee_id,attendee_fullname,attendee_yrsec,attendee_present,college_code from attendee where eventid="+UserInfo.EventId, false);
                while (rd.Read())
                {
                    var data = rd.GetValue(0);
                    var data1 = rd.GetValue(1);
                    var data2 = rd.GetValue(2);
                    var data3 = rd.GetValue(3);
                    var data4 = rd.GetValue(4);

                    AttendeeView.Rows.Add();
                    AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[0].Value = data;
                    AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[1].Value = data1;
                    AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[2].Value = data2;
                    AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[3].Value = data3;
                    AttendeeView.Rows[AttendeeView.Rows.Count - 1].Cells[4].Value = data4;
                }
            }
        }
    }
}
