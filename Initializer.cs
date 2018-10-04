using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone.Personnel.Tools;
using Newtonsoft.Json;

namespace Capstone.Personnel
{
    public partial class Initializer : Form
    {
        public Initializer()
        { 
            InitializeComponent();
            
            
        }
        // Load Config Button
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            fd.Filter = "Config File(*.json)|*.json";
            DialogResult dr = fd.ShowDialog();
            if (dr.Equals(DialogResult.OK))
            {
               File.Copy(Path.GetFullPath(fd.FileName),Path.Combine(Directory.GetCurrentDirectory(),"configs/config.json"));
                MessageBox.Show("Configuration File Import Successfully,Re-run the application to take effect.");
                Close();
            }
        }

        private void Initializer_Activated(object sender, EventArgs e)
        {
            
            string configFile = Path.Combine(Directory.GetCurrentDirectory(), "configs/config.json");
            if (Windows.existPath() == false)
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"/configs");
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"/temp");
            }
            else
            {
                CollegeDefault();
                Login login = new Login();
                login.SetOpenEventLists();
                login.Show();
                Hide();
            }
           
        }

        private void CollegeDefault() // Insert College Default
        {
            bool found = false;
            string[] collegeCode = new string[] { "CICT","COE","CON","COED","N/A" };
            string[] collegeDesc = new string[] { "College of Informations and Communications Technology","College of Engineering","College of Nursing","College of Education","Non-Student" };

            for (int i = 0; i < collegeCode.Length; i++)
            {
                found = false; // reset
                var reader = SqlUtils.ExecuteQueryReader("SELECT college_code FROM college WHERE college_code='"+collegeCode[i]+"'", false);
                while (reader.Read())
                {
                    found = true;
                }
                if (found.Equals(false))
                {
                    SqlUtils.ExecuteQuery("INSERT INTO college(college_code,college_desc) values('" + collegeCode[i] + "','" + collegeDesc[i] + "')", false);
                }
                

            }
        }
    }
}
