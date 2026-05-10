using Microsoft.Reporting.WinForms;
using QRCoder;
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

namespace XuatHoaDonAurora
{
    public partial class CreateVoucher : Form
    {
        string linkZalo = "https://zaloapp.com/qr/p/15etoavobxir";
        string linkFanpage = "https://fb.com/kinhmat.aurora.page";
        //string linkTiktok = "https://";

        decimal giaTriGiam = 0;

        List<Discount> discountList;
        public CreateVoucher(Discount discount, List<Discount> discountList)
        {
            InitializeComponent();
            this.discountList = discountList;
            InitializeDiscountList();
            DisplaySelectedDiscount(discount);

        }

        private void CreateVoucher_Load(object sender, EventArgs e)
        {
            this.reportView_Voucher.LocalReport.ReportEmbeddedResource = "XuatHoaDonAurora.MauVoucher.rdlc";
            var pg = new System.Drawing.Printing.PageSettings();
            pg.Landscape = true;
            pg.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.reportView_Voucher.SetPageSettings(pg);

            SetParameter();
        }
        void SetParameter()
        {
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("txt_GiaTri", checkPhanTram.Checked ? $"{giaTriGiam}%" : $"{giaTriGiam}K");
            parameters[1] = new ReportParameter("imgQR_FB", Convert.ToBase64String(GenerateQRCode(linkFanpage)));
            parameters[2] = new ReportParameter("imgQR_Zalo", Convert.ToBase64String(GenerateQRCode(linkZalo)));
            reportView_Voucher.LocalReport.SetParameters(parameters);

            this.reportView_Voucher.RefreshReport();
        }
        private void btn_In_Click(object sender, EventArgs e)
        {
            if (reportView_Voucher.PrintDialog() == DialogResult.OK)
            {
                // Sau khi in hóa 
            }
        }

        private void checkPhanTram_CheckedChanged(object sender, EventArgs e)
        {
            OnTick();
        }
        void OnTick()
        {
            if (checkPhanTram.Checked)
            {
                txt_DonVi.Text = "%";
                txt_TitleGiatri.Text = "Giá % giảm:";
            }
            else
            {
                txt_DonVi.Text = "K";
                txt_TitleGiatri.Text = "Giá trị giảm:";
            }
            SetParameter();
        }

        private void txtPhanTram_TextChanged(object sender, EventArgs e)
        {
            giaTriGiam = txtPhanTram.Text == "" ? 0 : decimal.Parse(txtPhanTram.Text);
            SetParameter();
        }
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự không phải là số và không phải phím điều khiển
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập ký tự
            }
        }

        void InitializeDiscountList()
        {
            listBox_Discount.DataSource = discountList;
            listBox_Discount.DisplayMember = "Name";
            SetupListBox();
        }

        #region Custom Listbox
        void SetupListBox()
        {
            // Use OwnerDrawVariable if you want different heights; OwnerDrawFixed if all equal
            listBox_Discount.DrawMode = DrawMode.OwnerDrawFixed;
            listBox_Discount.ItemHeight = 40;
            listBox_Discount.DrawItem += ListBox_Discount_DrawItem;
        }

        private void ListBox_Discount_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            Graphics g = e.Graphics;

            var item = (Discount)listBox_Discount.Items[e.Index];

            // Colors
            bool selected = (e.State & DrawItemState.Selected) != 0;
            Color back = selected ? Color.FromArgb(0, 120, 215) : (e.Index % 2 == 0 ? Color.White : Color.FromArgb(240, 240, 240));
            Color fore = selected ? Color.White : Color.Black;

            using (var backBrush = new SolidBrush(back))
                g.FillRectangle(backBrush, e.Bounds);



            // Text area
            int textLeft = 8;
            RectangleF nameRect = new RectangleF(textLeft, e.Bounds.Top + 3, e.Bounds.Width - textLeft - 8, 22);
            RectangleF metaRect = new RectangleF(textLeft, e.Bounds.Top + 23, e.Bounds.Width - textLeft - 8, 20);

            using (var nameBrush = new SolidBrush(fore))
            using (var metaBrush = new SolidBrush(Color.FromArgb(150, fore)))
            {
                // Product name (bold)
                using (var b = new Font(FontFamily.GenericSansSerif, 12f, FontStyle.Bold))
                    g.DrawString(item.Name, b, nameBrush, nameRect);

                // Quantity and price (smaller)
                string meta = $"      {(item.IsPercent ? item.Amount.ToString("N0") + "%" : (item.Amount).ToString("N0") + "₫")}";
                using (var b2 = new Font(FontFamily.GenericSansSerif, 9f, FontStyle.Regular))
                    g.DrawString(meta, b2, metaBrush, metaRect);
            }

            // Focus rectangle when keyboard-focus
            e.DrawFocusRectangle();
        }
        #endregion

        void DisplaySelectedDiscount(Discount discount)
        {
            txtTenMa.Text = discount.Name;
            checkPhanTram.Checked = discount.IsPercent;
            if(discount.IsPercent)
            {
                txtPhanTram.Text = discount.Amount.ToString();
            }
            else
            {
                txtPhanTram.Text = (discount.Amount/1000).ToString();
            }
            

        }

        private void listBox_Discount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Discount.SelectedItem is Discount selected)
            {
                DisplaySelectedDiscount(selected);
            }
        }

        private byte[] GenerateQRCode(string content)
        {
            // Tạo mã QR
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(5);
            // Chuyển đổi Bitmap sang mảng byte
            using (MemoryStream ms = new MemoryStream())
            {
                qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
