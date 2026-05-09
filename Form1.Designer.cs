namespace XuatHoaDonAurora
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        // Trong Form1.Designer.cs
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnDeleteAllItem;
        private System.Windows.Forms.Button btnPrintInvoice;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnDeleteAllItem = new System.Windows.Forms.Button();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.comboBox_TypeProduct = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDiscounds = new System.Windows.Forms.DataGridView();
            this.NameDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteMa = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox_Discount = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkPhanTram = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTenMa = new System.Windows.Forms.TextBox();
            this.txtPhanTram = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPriceGiam = new System.Windows.Forms.TextBox();
            this.txtFinalMoney = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataSet1 = new XuatHoaDonAurora.DataSet();
            this.listBox_SP = new System.Windows.Forms.ListBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.txt_Aurora = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounds)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvItems, "dgvItems");
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.Quantity,
            this.Price,
            this.Total});
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle36;
            this.dgvItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvItems.EnableHeadersVisualStyles = false;
            this.dgvItems.Name = "dgvItems";
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.dgvItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle37;
            this.dgvItems.RowHeadersVisible = false;
            dataGridViewCellStyle38.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItems.RowsDefaultCellStyle = dataGridViewCellStyle38;
            this.dgvItems.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.ShowEditingIcon = false;
            this.dgvItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellClick);
            this.dgvItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellValueChanged);
            this.dgvItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvItems_EditingControlShowing);
            this.dgvItems.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvDiscounds_UserDeletedRow);
            // 
            // ItemName
            // 
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemName.DefaultCellStyle = dataGridViewCellStyle32;
            resources.ApplyResources(this.ItemName, "ItemName");
            this.ItemName.Name = "ItemName";
            // 
            // Quantity
            // 
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle33;
            this.Quantity.FillWeight = 50F;
            resources.ApplyResources(this.Quantity, "Quantity");
            this.Quantity.Name = "Quantity";
            // 
            // Price
            // 
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price.DefaultCellStyle = dataGridViewCellStyle34;
            resources.ApplyResources(this.Price, "Price");
            this.Price.Name = "Price";
            // 
            // Total
            // 
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total.DefaultCellStyle = dataGridViewCellStyle35;
            resources.ApplyResources(this.Total, "Total");
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // txtItemName
            // 
            resources.ApplyResources(this.txtItemName, "txtItemName");
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // txtQuantity
            // 
            resources.ApplyResources(this.txtQuantity, "txtQuantity");
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // txtPrice
            // 
            resources.ApplyResources(this.txtPrice, "txtPrice");
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.LightGreen;
            resources.ApplyResources(this.btnAddItem, "btnAddItem");
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDeleteAllItem
            // 
            this.btnDeleteAllItem.BackColor = System.Drawing.Color.DarkRed;
            resources.ApplyResources(this.btnDeleteAllItem, "btnDeleteAllItem");
            this.btnDeleteAllItem.Name = "btnDeleteAllItem";
            this.btnDeleteAllItem.UseVisualStyleBackColor = false;
            this.btnDeleteAllItem.Click += new System.EventHandler(this.btnDeleteAllItem_Click);
            // 
            // btnPrintInvoice
            // 
            resources.ApplyResources(this.btnPrintInvoice, "btnPrintInvoice");
            this.btnPrintInvoice.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.UseVisualStyleBackColor = false;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteItem);
            this.groupBox1.Controls.Add(this.comboBox_TypeProduct);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtItemName);
            this.groupBox1.Controls.Add(this.btnAddItem);
            this.groupBox1.Controls.Add(this.btnDeleteAllItem);
            this.groupBox1.Controls.Add(this.txtQuantity);
            this.groupBox1.Controls.Add(this.txtPrice);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnDeleteItem, "btnDeleteItem");
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.UseVisualStyleBackColor = false;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // comboBox_TypeProduct
            // 
            this.comboBox_TypeProduct.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox_TypeProduct, "comboBox_TypeProduct");
            this.comboBox_TypeProduct.Name = "comboBox_TypeProduct";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtTotal
            // 
            resources.ApplyResources(this.txtTotal, "txtTotal");
            this.txtTotal.Name = "txtTotal";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // dgvDiscounds
            // 
            this.dgvDiscounds.AllowUserToAddRows = false;
            resources.ApplyResources(this.dgvDiscounds, "dgvDiscounds");
            this.dgvDiscounds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiscounds.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDiscounds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDiscounds.ColumnHeadersVisible = false;
            this.dgvDiscounds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameDiscount,
            this.TotalDiscount});
            this.dgvDiscounds.EnableHeadersVisualStyles = false;
            this.dgvDiscounds.GridColor = System.Drawing.SystemColors.Control;
            this.dgvDiscounds.Name = "dgvDiscounds";
            this.dgvDiscounds.RowHeadersVisible = false;
            this.dgvDiscounds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiscounds.ShowEditingIcon = false;
            this.dgvDiscounds.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiscounds_CellClick);
            this.dgvDiscounds.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvDiscounds.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiscounds_CellValueChanged);
            this.dgvDiscounds.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvDiscounds_UserDeletedRow);
            // 
            // NameDiscount
            // 
            this.NameDiscount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameDiscount.DefaultCellStyle = dataGridViewCellStyle39;
            this.NameDiscount.FillWeight = 150F;
            resources.ApplyResources(this.NameDiscount, "NameDiscount");
            this.NameDiscount.Name = "NameDiscount";
            // 
            // TotalDiscount
            // 
            this.TotalDiscount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalDiscount.DefaultCellStyle = dataGridViewCellStyle40;
            resources.ApplyResources(this.TotalDiscount, "TotalDiscount");
            this.TotalDiscount.Name = "TotalDiscount";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteMa);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.listBox_Discount);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.checkPhanTram);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtTenMa);
            this.groupBox2.Controls.Add(this.txtPhanTram);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtPriceGiam);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnDeleteMa
            // 
            this.btnDeleteMa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnDeleteMa, "btnDeleteMa");
            this.btnDeleteMa.Name = "btnDeleteMa";
            this.btnDeleteMa.UseVisualStyleBackColor = false;
            this.btnDeleteMa.Click += new System.EventHandler(this.btnDeleteMa_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox_Discount
            // 
            this.listBox_Discount.FormattingEnabled = true;
            resources.ApplyResources(this.listBox_Discount, "listBox_Discount");
            this.listBox_Discount.Name = "listBox_Discount";
            this.listBox_Discount.SelectedIndexChanged += new System.EventHandler(this.LstDiscount_SelectedIndexChanged);
            this.listBox_Discount.DoubleClick += new System.EventHandler(this.LstDiscount_DoubleClick);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // checkPhanTram
            // 
            this.checkPhanTram.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.checkPhanTram, "checkPhanTram");
            this.checkPhanTram.Name = "checkPhanTram";
            this.checkPhanTram.UseVisualStyleBackColor = true;
            this.checkPhanTram.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtTenMa
            // 
            resources.ApplyResources(this.txtTenMa, "txtTenMa");
            this.txtTenMa.Name = "txtTenMa";
            // 
            // txtPhanTram
            // 
            resources.ApplyResources(this.txtPhanTram, "txtPhanTram");
            this.txtPhanTram.Name = "txtPhanTram";
            this.txtPhanTram.TextChanged += new System.EventHandler(this.txtPhanTram_TextChanged);
            this.txtPhanTram.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPriceGiam
            // 
            resources.ApplyResources(this.txtPriceGiam, "txtPriceGiam");
            this.txtPriceGiam.Name = "txtPriceGiam";
            this.txtPriceGiam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // txtFinalMoney
            // 
            resources.ApplyResources(this.txtFinalMoney, "txtFinalMoney");
            this.txtFinalMoney.Name = "txtFinalMoney";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listBox_SP
            // 
            resources.ApplyResources(this.listBox_SP, "listBox_SP");
            this.listBox_SP.FormattingEnabled = true;
            this.listBox_SP.Name = "listBox_SP";
            this.listBox_SP.SelectedIndexChanged += new System.EventHandler(this.LstProducts_SelectedIndexChanged);
            this.listBox_SP.DoubleClick += new System.EventHandler(this.LstProducts_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageList1, "imageList1");
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageList2, "imageList2");
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // txt_Aurora
            // 
            resources.ApplyResources(this.txt_Aurora, "txt_Aurora");
            this.txt_Aurora.Name = "txt_Aurora";
            this.txt_Aurora.DoubleClick += new System.EventHandler(this.txt_Aurora_DoubleClick);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.txt_Aurora);
            this.Controls.Add(this.listBox_SP);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtFinalMoney);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvDiscounds);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrintInvoice);
            this.Controls.Add(this.dgvItems);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounds)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private DataSet dataSet1;
        private System.Windows.Forms.DataGridView dgvDiscounds;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTenMa;
        private System.Windows.Forms.TextBox txtPhanTram;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPriceGiam;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDiscount;
        private System.Windows.Forms.CheckBox checkPhanTram;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtFinalMoney;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDeleteMa;
        private System.Windows.Forms.ListBox listBox_SP;
        private System.Windows.Forms.ComboBox comboBox_TypeProduct;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox_Discount;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label txt_Aurora;
    }
}

