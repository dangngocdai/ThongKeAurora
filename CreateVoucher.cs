using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XuatHoaDonAurora
{
    public partial class CreateVoucher : Form
    {
        public CreateVoucher(Discount discount)
        {
            InitializeComponent();
        }

        private void CreateVoucher_Load(object sender, EventArgs e)
        {
            this.reportView_Voucher.LocalReport.ReportEmbeddedResource = "XuatHoaDonAurora.MauVoucher.rdlc";
            var pg = new System.Drawing.Printing.PageSettings();
            pg.Landscape = true;
            pg.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.reportView_Voucher.SetPageSettings(pg);

            this.reportView_Voucher.RefreshReport();
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            reportView_Voucher.PrintDialog();
        }
    }
}
