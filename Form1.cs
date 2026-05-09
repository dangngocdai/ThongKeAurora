using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace XuatHoaDonAurora
{
    public partial class Form1 : Form
    {
        private List<Product> productList;
        private List<Discount> discountList;
        List<Product> productsTotal = new List<Product>();
        List<Discount> discountTotal = new List<Discount>();

        TypeBank bankType = TypeBank.VPBank_DangNgocVien;

        public Form1()
        {
            InitializeComponent();
            InitializeProducts();
            TinhTongTien();
            OnTick();
            DisplayBtnBank();

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            SetupListBox();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void PopulateDgvItemsWithProductTotals()
        {
            if (productsTotal == null) return;

            // Ensure columns exist (keep existing column names used elsewhere)
            if (dgvItems.Columns.Count == 0)
            {
                dgvItems.Columns.Add("ItemName", "Tên hàng");
                dgvItems.Columns.Add("Quantity", "Số lượng");
                dgvItems.Columns.Add("Price", "Giá");
                dgvItems.Columns.Add("Total", "Thành tiền");
            }

            // Prevent UI flicker
            dgvItems.SuspendLayout();
            dgvItems.Rows.Clear();

            if( productsTotal.Count > 0)
            foreach (var p in productsTotal)
            {
                dgvItems.Rows.Add(p.Name, p.Quantity, p.Price, p.Quantity * p.Price);
            }

            dgvItems.ResumeLayout();

            // Recalculate grand total / UI
            TinhTongTien();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string itemName = txtItemName.Text;
            int quantity = int.Parse(txtQuantity.Text);
            decimal price = decimal.Parse(txtPrice.Text);
            TypeProduct type = (TypeProduct)comboBox_TypeProduct.SelectedItem;

            if(!CheckProductInListProduct(itemName, type, price,out Product pd))
            {
                MessageBox.Show("Sản phẩm không tồn tại trong danh sách.");
                AddProductInProductTotal(itemName, quantity, type, price);
            }
            else
            {
                AddProductInProductTotal(pd.Name, quantity, pd.Type, pd.Price);
            }
            

            //txtItemName.Clear();
            //txtQuantity.Text = "1";
            //txtPrice.Text ="0";

            PopulateDgvItemsWithProductTotals();
        }

        bool CheckProductInListProduct(string name,TypeProduct type,decimal price, out Product pd)
        {
            pd = productList.FirstOrDefault(p => p.Name == name && p.Type == type && p.Price == price);
            return pd != null;
        }

        void AddProductInProductTotal(string name, int quantity,TypeProduct type, decimal price)
        {
            Product existingProduct = productsTotal.FirstOrDefault(p => p.Name == name && p.Price == price);
            if (existingProduct != null)
            {
                existingProduct.Quantity += quantity; // Increment quantity if product already exists
            }
            else
            {
                productsTotal.Add(new Product(name, type, quantity, price)); // Add new product
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            //if (dgvItems.SelectedRows.Count > 0 && dgvItems.SelectedRows[0].Index< dgvItems.Rows.Count)
            //{
            //    int index = dgvItems.SelectedRows[0].Index;
            //    dgvItems.Rows.RemoveAt(index);
            //    productsTotal.RemoveAt(index);
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn sản phẩm để xóa.");
            //}
            string itemName = txtItemName.Text;
            int quantity = int.Parse(txtQuantity.Text);
            decimal price = decimal.Parse(txtPrice.Text);
            TypeProduct type = (TypeProduct)comboBox_TypeProduct.SelectedItem;
            Product existingProduct = productsTotal.FirstOrDefault(p => p.Name == itemName && p.Type == type && p.Price == price);
            if (existingProduct != null)
            {
                if(existingProduct.Quantity > quantity)
                {
                    existingProduct.Quantity -= quantity; // Decrement quantity if product exists and quantity is sufficient
                }
                else
                    productsTotal.Remove(existingProduct);
            }
            else
            {
                MessageBox.Show("Sản phẩm không tồn tại trong danh sách.");
            }
            PopulateDgvItemsWithProductTotals();
        }
        private DataSet GetInvoiceData()
        {
            DataSet dataSet = new DataSet();
            dataSet.Tables["InvoiceTable"].Clear();
            dataSet.Tables["DiscountTable"].Clear();

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (!row.IsNewRow)
                {
                    dataSet.Tables["InvoiceTable"].Rows.Add(
                        row.Cells[0].Value.ToString(),
                        int.Parse(row.Cells[1].Value.ToString()),
                        decimal.Parse(row.Cells[2].Value.ToString()),
                        decimal.Parse(row.Cells[3].Value.ToString())
                    );
                }
            }
            foreach (DataGridViewRow row in dgvDiscounds.Rows)
            {
                if (!row.IsNewRow)
                {
                    dataSet.Tables["DiscountTable"].Rows.Add(
                        row.Cells[0].Value.ToString(),
                        $"- {(decimal.Parse(row.Cells[1].Value.ToString())).ToString("N0")}"
                    );
                }
            }
            return dataSet;
        }
        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {

            DataSet data = GetInvoiceData();
            Form2 form2 = new Form2(data, txtFinalMoney.Text,new DataAuroraSave() { BankType = bankType, Products = productsTotal, Discounts = discountTotal });
            form2.ShowDialog();


        }

        void TinhTongTien()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }
            txtTotal.Text = total.ToString("N0")+" ₫";

            PopulateDgvItemsWithDiscountsTotal();
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu hàng được click không phải là hàng tiêu đề hoặc hàng mới
            if (e.RowIndex >= 0 && e.RowIndex < dgvItems.Rows.Count)
            {
                Product product = productsTotal[e.RowIndex];

                // Lấy giá trị từ các cột
                txtItemName.Text = product.Name;
                txtQuantity.Text = product.Quantity.ToString();
                txtPrice.Text = product.Price.ToString();
                comboBox_TypeProduct.SelectedItem = product.Type;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự không phải là số và không phải phím điều khiển
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập ký tự
            }
        }
        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu hàng được sửa không phải là hàng mới
            if (e.RowIndex >= 0 && e.RowIndex < dgvItems.Rows.Count)
            {
                DataGridViewRow row = dgvItems.Rows[e.RowIndex];

                // Kiểm tra nếu cột được sửa là "Số lượng" hoặc "Giá"
                if (e.ColumnIndex == row.Cells["Quantity"].ColumnIndex || e.ColumnIndex == row.Cells["Price"].ColumnIndex)
                {
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value ?? 0);

                    // Tính lại "Thành tiền"
                    row.Cells["Total"].Value = quantity * price;

                    // Cập nhật tổng tiền
                    TinhTongTien();
                }
            }
        }
        private void txtItemName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPhanTram.Clear();
            OnTick();
        }
        void OnTick()
        {

            if (checkPhanTram.Checked)
            {
                txtPhanTram.Enabled = true;
                txtPriceGiam.Enabled = false;
            }
            else
            {
                txtPhanTram.Enabled = false;
                txtPriceGiam.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string itemName = txtTenMa.Text;
            decimal price = decimal.Parse(txtPriceGiam.Text);

            if (checkPhanTram.Checked)
            {
                discountTotal.Add(new Discount(itemName, decimal.Parse(txtPhanTram.Text), checkPhanTram.Checked)); // Add new discount
            }
            else {
                discountTotal.Add(new Discount(itemName, price, checkPhanTram.Checked)); // Add new discount
            }

            TinhTongTien();
        }

        private void txtPhanTram_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPhanTram.Text, out decimal phanTram))
            {
                // Giả sử tổng tiền là giá trị trong txtTotal (bỏ ký tự "₫" và định dạng)
                decimal tongTien = decimal.Parse(txtTotal.Text.Replace("₫", "").Replace(",", "").Trim());

                // Tính giá trị giảm giá
                decimal giamGia = tongTien * (phanTram / 100);

                // Đặt giá trị cho txtPriceGiam
                txtPriceGiam.Text = giamGia.ToString("N0");
            }
            else
            {
                // Nếu không nhập đúng số, đặt giá trị mặc định
                txtPriceGiam.Text = "0";
            }
        }

        private void btnDeleteMa_Click(object sender, EventArgs e)
        {
            if (dgvDiscounds.SelectedRows.Count > 0 )
            {
                discountTotal.RemoveAt(dgvDiscounds.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng để xóa.");
            }
            TinhTongTien();
        }

        private void dgvDiscounds_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu hàng được sửa không phải là hàng mới
            if (e.RowIndex >= 0 && e.RowIndex < dgvDiscounds.Rows.Count)
            {
                DataGridViewRow row = dgvDiscounds.Rows[e.RowIndex];

                // Kiểm tra nếu cột được sửa là "Số lượng" hoặc "Giá"
                if (e.ColumnIndex == row.Cells["TotalDiscount"].ColumnIndex)
                {
                    // Cập nhật tổng tiền
                    TinhTongTien();
                }
            }
        }

        private void dgvDiscounds_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            TinhTongTien();
        }

        private void dgvDiscounds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDiscounds.Rows.Count)
            {
                DataGridViewRow row = dgvDiscounds.Rows[e.RowIndex];

                // Lấy giá trị từ các cột
                txtTenMa.Text = row.Cells["NameDiscount"].Value?.ToString();
                txtPriceGiam.Text = row.Cells["TotalDiscount"].Value?.ToString();
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        #region Sản Phẩm

        string filePath = Path.GetFullPath(@"C:\Datas\DataAurora.json");

        private void InitializeProducts()
        {
            


            productList = new List<Product>
            {
                new Product("Gọng kính khuyễn mại",TypeProduct.EyeglassFrame,13, 0),
                new Product("Gọng kính ", TypeProduct.EyeglassFrame, 10, 150000),
                new Product("Tròng 1.56 Bevis", TypeProduct.Lenses, 20, 180000),
                new Product("Tròng 1.56 Bevis UV", TypeProduct.Lenses, 20, 230000),
                new Product("Tròng 1.61", TypeProduct.Lenses, 20, 150000),
                new Product("Tròng 1.67", TypeProduct.Lenses, 20, 150000),
                new Product("Tròng 1.74", TypeProduct.Lenses, 20, 150000),

            };

            discountList = new List<Discount>
            {
                new Discount("Không giảm giá", 0), // No discount
                new Discount("Mã giảm 5%", 5, true), // 5% discount
                new Discount("Mã giảm 10%", 10,true), // 10% discount
                new Discount("Mã giảm 15%", 15,true), // 15% discount
                new Discount("Mã giảm 20%", 20,true),  // 20% discount
                new Discount("Mã giảm 20k", 20000),  // 20000 VND discount
                new Discount("Mã giảm 10k", 10000)  // 10000 VND discount
            };
            DataAurora data = new DataAurora
            {
                Products = productList,
                Discounts = discountList
            };
            // Serialize to JSON and save to file
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
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(filePath, json, Encoding.UTF8);

            }

            string fileContent = File.ReadAllText(filePath, Encoding.UTF8);
            DataAurora data2 = !string.IsNullOrWhiteSpace(fileContent)
                ? Newtonsoft.Json.JsonConvert.DeserializeObject<DataAurora>(fileContent)
                : new DataAurora();

            if (data2 != null)
            {
                productList = data2.Products ?? new List<Product>();
                discountList = data2.Discounts ?? new List<Discount>();
            }

            CreateProductListUI();
        }

        // Creates the ListBox and toggle button at runtime
        private void CreateProductListUI()
        {
            listBox_SP.DataSource = productList;
            listBox_SP.DisplayMember = "Name";
            comboBox_TypeProduct.DataSource = Enum.GetValues(typeof(TypeProduct));

            listBox_Discount.DataSource = discountList;
            listBox_Discount.DisplayMember = "Name";
        }

        // When user double-clicks product -> insert into invoice input
        private void LstProducts_DoubleClick(object sender, EventArgs e)
        {
            SelectCurrentProduct();
        }

        private void LstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: preview selected product
            var p = listBox_SP.SelectedItem as Product;
            if (p != null)
            {
                txtItemName.Text = p.Name;
                txtPrice.Text = p.Price.ToString();
                comboBox_TypeProduct.SelectedItem = p.Type;
                txtQuantity.Text = "1";
            }
        }

        private void SelectCurrentProduct()
        {
            var p = listBox_SP.SelectedItem as Product;
            if (p == null) return;

            txtItemName.Text = p.Name;
            txtPrice.Text = p.Price.ToString(); // store plain numeric string for parsing
            comboBox_TypeProduct.SelectedItem = p.Type;
            txtQuantity.Text = "1";
            AddProductInProductTotal(p.Name,  1, p.Type, p.Price);

            //txtItemName.Clear();
            //txtQuantity.Text = "1";
            //txtPrice.Text ="0";

            PopulateDgvItemsWithProductTotals();
        }
        #endregion

        private void btnDeleteAllItem_Click(object sender, EventArgs e)
        {
            productsTotal.Clear();
            PopulateDgvItemsWithProductTotals();
        }

        #region Discount
        private void LstDiscount_DoubleClick(object sender, EventArgs e)
        {
            SelectCurrentDiscount();
        }

        private void LstDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: preview selected product
            var p = listBox_Discount.SelectedItem as Discount;
            DisplayDiscountInput(p);
        }

        private void SelectCurrentDiscount()
        {
            var d = listBox_Discount.SelectedItem as Discount;
            if (d == null) return;

            DisplayDiscountInput(d);
            AddDiscountInDiscoutTotal(d);


            PopulateDgvItemsWithDiscountsTotal();
        }

        void AddDiscountInDiscoutTotal(string name, bool isPercent, decimal amount)
        {
                discountTotal.Add(new Discount(name, amount, isPercent)); // Add new product
        }
        void AddDiscountInDiscoutTotal(Discount discount)
        {
            discountTotal.Add(discount); // Add new product
        }
        private void PopulateDgvItemsWithDiscountsTotal()
        {
            if (discountTotal == null) return;

            // Ensure columns exist (keep existing column names used elsewhere)
            if (dgvDiscounds.Columns.Count == 0)
            {
                dgvDiscounds.Columns.Add("NameDiscount", "Name");
                dgvDiscounds.Columns.Add("TotalDiscount", "Tổng");
            }
            // Prevent UI flicker
            dgvDiscounds.SuspendLayout();
            dgvDiscounds.Rows.Clear();
            decimal tongTien = decimal.Parse(txtTotal.Text.Replace("₫", "").Replace(",", "").Trim());

            // Tính giá trị giảm giá
            decimal total = tongTien;
            if (discountTotal.Count > 0)
                foreach (var p in discountTotal)
                {
                    if(p.IsPercent)
                    {
                        decimal giamGia = tongTien * (p.Amount / 100);
                        dgvDiscounds.Rows.Add(p.Name, $"{giamGia:N0}");
                        total -= giamGia;
                    }
                    else
                    {
                        dgvDiscounds.Rows.Add(p.Name, $"{p.Amount:N0}");
                        total -= p.Amount;
                    }
                        
                }

            dgvDiscounds.ResumeLayout();

            txtFinalMoney.Text = total.ToString("N0") + " ₫";

        }

        void DisplayDiscountInput(Discount discount)
        {
            txtTenMa.Text = discount.Name;
            if (discount.IsPercent)
            {
                checkPhanTram.Checked = true;
                txtPhanTram.Text = discount.Amount.ToString();
            }
            else
            {
                checkPhanTram.Checked = false;
                txtPriceGiam.Text = discount.Amount.ToString();
                txtPhanTram.Clear();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CreateVoucher form = new CreateVoucher(new Discount(txtTenMa.Text, txtPhanTram.Text=="" ? 0 : decimal.Parse(txtPhanTram.Text), checkPhanTram.Checked));
            form.ShowDialog();
        }
        #endregion


        #region fullscreen
        // full-screen toggle helpers
        private bool isFullScreen = false;
        private FormBorderStyle previousBorderStyle;
        private FormWindowState previousWindowState;
        private Rectangle previousBounds;
        private bool previousTopMost;

        private void ToggleFullScreen()
        {
            if (!isFullScreen)
            {
                previousBorderStyle = this.FormBorderStyle;
                previousWindowState = this.WindowState;
                previousBounds = this.Bounds;
                previousTopMost = this.TopMost;

                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Normal; // ensure Bounds applies
                this.Bounds = Screen.FromControl(this).Bounds;
                this.TopMost = true;
                isFullScreen = true;
            }
            else
            {
                this.TopMost = previousTopMost;
                this.FormBorderStyle = previousBorderStyle;
                this.WindowState = previousWindowState;
                this.Bounds = previousBounds;
                isFullScreen = false;
            }
        }

// Example: enable F11 to toggle full screen. Add these lines after InitializeComponent().
       

        private void Form1_KeyDown(object sender, KeyEventArgs e)
                {
                    if (e.KeyCode == Keys.F11)
                    {
                        ToggleFullScreen();
                        e.Handled = true;
                    }
                }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            discountTotal.Clear();
            PopulateDgvItemsWithDiscountsTotal();
        }

        #region BtnBank
        void DisplayBtnBank()
        {
            switch (bankType)
            {
                case TypeBank.TPBank_NguyenNgocTrien:
                    //bt_TPBank.BackColor = Color.Green;
                    //bt_Vietcombank.BackColor = Color.Silver;
                    //bt_VPBank.BackColor = Color.Silver;
                    txt_Aurora.ForeColor = Color.Black;
                    break;
                //case TypeBank.Vietcombank_PhamThiHue:
                //    //bt_Vietcombank.BackColor  = Color.Green;
                //    //bt_TPBank.BackColor = Color.Silver;
                //    //bt_VPBank.BackColor = Color.Silver;
                //    break;
                case TypeBank.VPBank_DangNgocVien:
                    txt_Aurora.ForeColor = Color.FromArgb(62, 192, 198);
                    break;
                default:
                    
                    break;
            }
        }
        #endregion

        private void bt_VPBank_Click(object sender, EventArgs e)
        {
            bankType = TypeBank.VPBank_DangNgocVien;
            DisplayBtnBank();
        }

        private void bt_TPBank_Click(object sender, EventArgs e)
        {
            bankType = TypeBank.TPBank_NguyenNgocTrien;
            DisplayBtnBank();
        }

        #region Custom Listbox
        void SetupListBox()
        {
            // Use OwnerDrawVariable if you want different heights; OwnerDrawFixed if all equal
            listBox_SP.DrawMode = DrawMode.OwnerDrawFixed;
            listBox_SP.ItemHeight = 40;
            listBox_SP.DrawItem += ListBox_SP_DrawItem;
        }

        private void ListBox_SP_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            Graphics g = e.Graphics;

            var item = (Product)listBox_SP.Items[e.Index];

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
                string meta = $"      {item.Price.ToString("N0")}₫";
                using (var b2 = new Font(FontFamily.GenericSansSerif, 9f, FontStyle.Regular))
                    g.DrawString(meta, b2, metaBrush, metaRect);
            }

            // Focus rectangle when keyboard-focus
            e.DrawFocusRectangle();
        }
        #endregion

        private void txt_Aurora_DoubleClick(object sender, EventArgs e)
        {
            if(bankType == TypeBank.VPBank_DangNgocVien)
            {
                bankType = TypeBank.TPBank_NguyenNgocTrien;
            }
            else
            {
                bankType = TypeBank.VPBank_DangNgocVien;
            }
            DisplayBtnBank();
        }

        
    }
}
