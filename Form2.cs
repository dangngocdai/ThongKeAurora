using Microsoft.Reporting.WinForms;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace XuatHoaDonAurora
{
    public partial class Form2 : Form
    {
        private DataSet invoiceData;
        string filePath = Path.GetFullPath(@"C:\Datas\Index.txt");
        string finalMoney;
        string maHD,todayDate,time;
        DataAuroraSave dataAuroraSave;

        public Form2(DataSet data, string finalMoney, DataAuroraSave dataAuroraSave)
        {
            InitializeComponent();
            this.invoiceData = data;
            this.finalMoney = finalMoney;
            this.dataAuroraSave = dataAuroraSave;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "XuatHoaDonAurora.HoaDon.rdlc";
            //this.reportViewer1.SetPageSettings(new System.Drawing.Printing.PageSettings(0,0,0,0));
            ReportDataSource rds = new ReportDataSource("InvoiceDataSet", invoiceData.Tables["InvoiceTable"]);
            ReportDataSource rds1 = new ReportDataSource("DiscountDataSet", invoiceData.Tables["DiscountTable"]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            maHD = $"A{GetIndexHD().ToString("D4")}";
            todayDate = DateTime.Now.ToString("dd/MM/yy");
            time = DateTime.Now.ToString("HH:mm");
            // Add today's date as a parameter

            byte[] qrCodeBytes = GenerateQRCode(decimal.Parse(finalMoney.Replace("₫", "").Replace(",", "").Trim()), maHD, dataAuroraSave.BankType);

            ReportParameter[] parameters = new ReportParameter[8];
            parameters[0] = new ReportParameter("TodayDate", todayDate);
            parameters[1] = new ReportParameter("Time", time);
            parameters[2] = new ReportParameter("MaHD", maHD);
            parameters[3] = new ReportParameter("TotalMoney", $"{GetTotalMoney().ToString("N0")}₫");
            parameters[4] = new ReportParameter("FinalMoney", finalMoney);
            parameters[5] = new ReportParameter("QRCodeImage", Convert.ToBase64String(qrCodeBytes));

            switch(dataAuroraSave.BankType)
            {
                //case TypeBank.Vietcombank_PhamThiHue:
                //    parameters[6] = new ReportParameter("IdBank", "KINHMATAURORA");
                //    parameters[7] = new ReportParameter("UserBank", "PHAM THI HUE");
                //    break;
                case TypeBank.TPBank_NguyenNgocTrien:
                    parameters[6] = new ReportParameter("IdBank", "88830101998");
                    parameters[7] = new ReportParameter("UserBank", "NGUYEN NGOC TRIEN");
                    txt_IdBank.Text = "88830101998";
                    txt_UserBank.Text = "NGUYEN NGOC TRIEN";
                    break;
                case TypeBank.VPBank_DangNgocVien:
                    parameters[6] = new ReportParameter("IdBank", "0985909968");
                    parameters[7] = new ReportParameter("UserBank", "DANG NGOC VIEN");
                    txt_IdBank.Text = "0985909968";
                    txt_UserBank.Text = "DANG NGOC VIEN";
                    break;
            }

            reportViewer1.LocalReport.SetParameters(parameters);

            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            pg.Margins.Top = 0;
            pg.Margins.Bottom = 0;
            pg.Margins.Left = 0;
            pg.Margins.Right = 0;
            reportViewer1.SetPageSettings(pg);

            this.reportViewer1.RefreshReport();

            
            //GenerateQRCode(50000, "daidzai");
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(reportViewer1.PrintDialog() == DialogResult.OK)
            {
                GoogleSheetsManager.AddHoaDonInSheets(maHD, todayDate, time, finalMoney, dataAuroraSave.BankType, Newtonsoft.Json.JsonConvert.SerializeObject(dataAuroraSave, Newtonsoft.Json.Formatting.None));
                AddIndexHD();
                this.Close();
            }
        }

        private void Deserialize()
        {

            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(filePath))
            {
                using (File.Create(filePath))
                {
                }

            }

            using (Stream s = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                BinaryFormatter b = new BinaryFormatter();
                int data = s.Length > 0 ? (int)b.Deserialize(s) : 0;
                s.Seek(0, SeekOrigin.Begin);
                data += 1;
                MessageBox.Show(data.ToString());
                b.Serialize(s, data);
            }
        }
        int GetIndexHD()
        {
            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(filePath))
            {
                using (File.Create(filePath))
                {
                }

            }

            using (Stream s = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter b = new BinaryFormatter();
                int data = s.Length > 0 ? (int)b.Deserialize(s) : 0;
                s.Seek(0, SeekOrigin.Begin);
                return data;
            }
        }
        void AddIndexHD()
        {
            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(filePath))
            {
                using (File.Create(filePath))
                {
                }

            }

            using (Stream s = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                BinaryFormatter b = new BinaryFormatter();
                int data = s.Length > 0 ? (int)b.Deserialize(s) : 0;
                s.Seek(0, SeekOrigin.Begin);
                data += 1;
                b.Serialize(s, data);
            }
        }
        decimal GetTotalMoney()
        {
            decimal total = 0;
            foreach (DataRow row in invoiceData.Tables["InvoiceTable"].Rows)
            {
                total += Convert.ToDecimal(row["Total"]);
            }
            return total;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private byte[] GenerateQRCode(decimal amount, string content, TypeBank bankType)
        {

            // Tạo nội dung QR theo chuẩn ngân hàng
            string qrContent = VietQRContent.GenerateVietQRContent(amount, content, bankType);
            // Tạo mã QR
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrContent, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(5);

            // Hiển thị mã QR lên PictureBox
            picQRCode.Image = qrCodeImage;
            // Chuyển đổi Bitmap sang mảng byte
            using (MemoryStream ms = new MemoryStream())
            {
                qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
