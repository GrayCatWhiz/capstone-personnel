using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using ZXing.Rendering;
using ZXing.Presentation;
using Capstone.Personnel.Tools;
using Capstone.Personnel.Actions;
using Capstone.Personnel.Utilities;
using System.Drawing.Printing;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.Threading;
using Capstone.Personnel.Properties;

namespace Capstone.Personnel.Actions
{
    public partial class uGenerate : UserControl
    {
        string eventname = UserInfo.EventName;
        string attendee;
        string UId = "";

        public uGenerate()
        {
            InitializeComponent();
        }
        
        public uGenerate(string AttendeeName)
            : this()
        {
            attendee = AttendeeName;
        }

        public void Serialize(string attendeeId)
        {
            UId = attendeeId;
            var qrCreator = new QrHelper(150,150,3,UserInfo.EventId.ToString() + "/" + attendeeId);
            Bitmap qr = qrCreator.GetQRCode();
            var Ticket = new Bitmap(QR.Width,QR.Height);
            var graphics = Graphics.FromImage(Ticket); // Ticket
            graphics.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(QR.Width - 1, QR.Height - 1))); // Outline
            graphics.DrawImage(Resources.bulsu_colored, new Rectangle(new Point(8, 8), new Size(70, 70)));
            graphics.DrawString("Bulacan State University", new Font("Times New Roman", 11F), Brushes.Black, new Point(90, 20)); // Authority Name
            graphics.DrawString("Malolos Bulacan, Philippines", new Font("Times New Roman", 11F), Brushes.Black, new Point(90, 35)); // Authority Address
            graphics.DrawImage(qr, new PointF(75, 65)); // QR
            graphics.DrawString(UserInfo.EventName, new Font("Times New Roman", 11F, FontStyle.Regular), new SolidBrush(Color.DarkSlateGray), new Point(75, 220)); // Event Name
            graphics.DrawString("Ticket No: " + attendeeId, new Font("Times New Roman", 11F, FontStyle.Regular), Brushes.Black, new Point(20, 240)); // Ticket No
            graphics.DrawString(attendee, new Font("Times New Roman", 11F, FontStyle.Regular), Brushes.Black, new Point(20, 255)); // Owner Name
            graphics.DrawString(UserInfo.EventLocation, new Font("Times New Roman", 11F, FontStyle.Regular), Brushes.Black, new Point(20, 270)); // Event Location
            QR.Image = Ticket;
        }

        private void Redirect()
        {
            uRegister.Instance = null;
            panel1.Controls.Add(uRegister.Instance);
            uRegister.Instance.Dock = DockStyle.Fill;
            uRegister.Instance.Init();
            uRegister.Instance.BringToFront();
        }
        // Print Function
        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            var printThread = new Thread(new ThreadStart(printAction));
            printThread.Start();
        }

        private void printAction()
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument qrPicture = new PrintDocument();

            printDialog.Document = qrPicture;
            qrPicture.PrintPage += QrPicture_PrintPage;

            var printResult = printDialog.ShowDialog();
            if (printResult == DialogResult.OK)
            {
                qrPicture.Print();
                Redirect();
            }
        }

        private void QrPicture_PrintPage(object sender, PrintPageEventArgs e) // Print Info Delegates
        {
            Bitmap printedQR = new Bitmap(QR.Width, QR.Height);
            QR.DrawToBitmap(printedQR, new Rectangle( 0, 0, QR.Width, QR.Height));
            e.Graphics.DrawImage(printedQR,0,0);
        }

        // Send to Mobile Function
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            var qrCreator = new QrHelper(150, 150, 3, UserInfo.EventId.ToString() + "/" + UId);
            Bitmap qr = qrCreator.GetQRCode();
            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "temp")))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "temp"));
            }
            qr.Save(Path.Combine(Directory.GetCurrentDirectory(), "temp/generated.jpg"));

            new BluetoothDeviceChooser().Show();
            //}
            //Redirect();
        }
    }
}
