namespace SupermarketManagment
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelSlide = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelSubSettings = new System.Windows.Forms.Panel();
            this.btnStore = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.panelSubRecord = new System.Windows.Forms.Panel();
            this.btnPOSRecord = new System.Windows.Forms.Button();
            this.btnSaleHistory = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.panelSubStock = new System.Windows.Forms.Panel();
            this.btnStockAdjustment = new System.Windows.Forms.Button();
            this.btnStockEntry = new System.Windows.Forms.Button();
            this.btnInStock = new System.Windows.Forms.Button();
            this.panelSubProduct = new System.Windows.Forms.Panel();
            this.btnBrand = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnProductList = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelSlide.SuspendLayout();
            this.panelSubSettings.SuspendLayout();
            this.panelSubRecord.SuspendLayout();
            this.panelSubStock.SuspendLayout();
            this.panelSubProduct.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSlide
            // 
            this.panelSlide.AutoScroll = true;
            this.panelSlide.Controls.Add(this.btnLogout);
            this.panelSlide.Controls.Add(this.panelSubSettings);
            this.panelSlide.Controls.Add(this.btnSettings);
            this.panelSlide.Controls.Add(this.panelSubRecord);
            this.panelSlide.Controls.Add(this.btnRecord);
            this.panelSlide.Controls.Add(this.btnSupplier);
            this.panelSlide.Controls.Add(this.panelSubStock);
            this.panelSlide.Controls.Add(this.btnInStock);
            this.panelSlide.Controls.Add(this.panelSubProduct);
            this.panelSlide.Controls.Add(this.btnProduct);
            this.panelSlide.Controls.Add(this.btnDashboard);
            this.panelSlide.Controls.Add(this.panelLogo);
            this.panelSlide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSlide.Location = new System.Drawing.Point(0, 0);
            this.panelSlide.Name = "panelSlide";
            this.panelSlide.Size = new System.Drawing.Size(200, 571);
            this.panelSlide.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 845);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(183, 45);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelSubSettings
            // 
            this.panelSubSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(200)))));
            this.panelSubSettings.Controls.Add(this.btnStore);
            this.panelSubSettings.Controls.Add(this.btnUser);
            this.panelSubSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubSettings.Location = new System.Drawing.Point(0, 755);
            this.panelSubSettings.Name = "panelSubSettings";
            this.panelSubSettings.Size = new System.Drawing.Size(183, 90);
            this.panelSubSettings.TabIndex = 9;
            // 
            // btnStore
            // 
            this.btnStore.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStore.FlatAppearance.BorderSize = 0;
            this.btnStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStore.ForeColor = System.Drawing.Color.White;
            this.btnStore.Location = new System.Drawing.Point(0, 45);
            this.btnStore.Name = "btnStore";
            this.btnStore.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnStore.Size = new System.Drawing.Size(183, 45);
            this.btnStore.TabIndex = 6;
            this.btnStore.Text = "Store";
            this.btnStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // btnUser
            // 
            this.btnUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Location = new System.Drawing.Point(0, 0);
            this.btnUser.Name = "btnUser";
            this.btnUser.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnUser.Size = new System.Drawing.Size(183, 45);
            this.btnUser.TabIndex = 5;
            this.btnUser.Text = "User";
            this.btnUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(0, 710);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(183, 45);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // panelSubRecord
            // 
            this.panelSubRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(200)))));
            this.panelSubRecord.Controls.Add(this.btnPOSRecord);
            this.panelSubRecord.Controls.Add(this.btnSaleHistory);
            this.panelSubRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubRecord.Location = new System.Drawing.Point(0, 620);
            this.panelSubRecord.Name = "panelSubRecord";
            this.panelSubRecord.Size = new System.Drawing.Size(183, 90);
            this.panelSubRecord.TabIndex = 7;
            // 
            // btnPOSRecord
            // 
            this.btnPOSRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPOSRecord.FlatAppearance.BorderSize = 0;
            this.btnPOSRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPOSRecord.ForeColor = System.Drawing.Color.White;
            this.btnPOSRecord.Location = new System.Drawing.Point(0, 45);
            this.btnPOSRecord.Name = "btnPOSRecord";
            this.btnPOSRecord.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnPOSRecord.Size = new System.Drawing.Size(183, 45);
            this.btnPOSRecord.TabIndex = 6;
            this.btnPOSRecord.Text = "POS Record";
            this.btnPOSRecord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPOSRecord.UseVisualStyleBackColor = true;
            this.btnPOSRecord.Click += new System.EventHandler(this.btnPOSRecord_Click);
            // 
            // btnSaleHistory
            // 
            this.btnSaleHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSaleHistory.FlatAppearance.BorderSize = 0;
            this.btnSaleHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaleHistory.ForeColor = System.Drawing.Color.White;
            this.btnSaleHistory.Location = new System.Drawing.Point(0, 0);
            this.btnSaleHistory.Name = "btnSaleHistory";
            this.btnSaleHistory.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSaleHistory.Size = new System.Drawing.Size(183, 45);
            this.btnSaleHistory.TabIndex = 5;
            this.btnSaleHistory.Text = "Sale History";
            this.btnSaleHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaleHistory.UseVisualStyleBackColor = true;
            this.btnSaleHistory.Click += new System.EventHandler(this.btnSaleHistory_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRecord.FlatAppearance.BorderSize = 0;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.ForeColor = System.Drawing.Color.White;
            this.btnRecord.Location = new System.Drawing.Point(0, 575);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnRecord.Size = new System.Drawing.Size(183, 45);
            this.btnRecord.TabIndex = 6;
            this.btnRecord.Text = "Record";
            this.btnRecord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.ForeColor = System.Drawing.Color.White;
            this.btnSupplier.Location = new System.Drawing.Point(0, 530);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSupplier.Size = new System.Drawing.Size(183, 45);
            this.btnSupplier.TabIndex = 5;
            this.btnSupplier.Text = "Supplier";
            this.btnSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // panelSubStock
            // 
            this.panelSubStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(200)))));
            this.panelSubStock.Controls.Add(this.btnStockAdjustment);
            this.panelSubStock.Controls.Add(this.btnStockEntry);
            this.panelSubStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubStock.Location = new System.Drawing.Point(0, 440);
            this.panelSubStock.Name = "panelSubStock";
            this.panelSubStock.Size = new System.Drawing.Size(183, 90);
            this.panelSubStock.TabIndex = 0;
            // 
            // btnStockAdjustment
            // 
            this.btnStockAdjustment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockAdjustment.FlatAppearance.BorderSize = 0;
            this.btnStockAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockAdjustment.ForeColor = System.Drawing.Color.White;
            this.btnStockAdjustment.Location = new System.Drawing.Point(0, 45);
            this.btnStockAdjustment.Name = "btnStockAdjustment";
            this.btnStockAdjustment.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnStockAdjustment.Size = new System.Drawing.Size(183, 45);
            this.btnStockAdjustment.TabIndex = 6;
            this.btnStockAdjustment.Text = "Stock Adjustment";
            this.btnStockAdjustment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockAdjustment.UseVisualStyleBackColor = true;
            this.btnStockAdjustment.Click += new System.EventHandler(this.btnStockAdjustment_Click);
            // 
            // btnStockEntry
            // 
            this.btnStockEntry.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockEntry.FlatAppearance.BorderSize = 0;
            this.btnStockEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockEntry.ForeColor = System.Drawing.Color.White;
            this.btnStockEntry.Location = new System.Drawing.Point(0, 0);
            this.btnStockEntry.Name = "btnStockEntry";
            this.btnStockEntry.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnStockEntry.Size = new System.Drawing.Size(183, 45);
            this.btnStockEntry.TabIndex = 5;
            this.btnStockEntry.Text = "Stock Entry";
            this.btnStockEntry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockEntry.UseVisualStyleBackColor = true;
            this.btnStockEntry.Click += new System.EventHandler(this.btnStockEntry_Click);
            // 
            // btnInStock
            // 
            this.btnInStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInStock.FlatAppearance.BorderSize = 0;
            this.btnInStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInStock.ForeColor = System.Drawing.Color.White;
            this.btnInStock.Location = new System.Drawing.Point(0, 395);
            this.btnInStock.Name = "btnInStock";
            this.btnInStock.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnInStock.Size = new System.Drawing.Size(183, 45);
            this.btnInStock.TabIndex = 4;
            this.btnInStock.Text = "In stock";
            this.btnInStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInStock.UseVisualStyleBackColor = true;
            this.btnInStock.Click += new System.EventHandler(this.btnInStock_Click);
            // 
            // panelSubProduct
            // 
            this.panelSubProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(200)))));
            this.panelSubProduct.Controls.Add(this.btnBrand);
            this.panelSubProduct.Controls.Add(this.btnCategory);
            this.panelSubProduct.Controls.Add(this.btnProductList);
            this.panelSubProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubProduct.Location = new System.Drawing.Point(0, 260);
            this.panelSubProduct.Name = "panelSubProduct";
            this.panelSubProduct.Size = new System.Drawing.Size(183, 135);
            this.panelSubProduct.TabIndex = 3;
            // 
            // btnBrand
            // 
            this.btnBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBrand.FlatAppearance.BorderSize = 0;
            this.btnBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrand.ForeColor = System.Drawing.Color.White;
            this.btnBrand.Location = new System.Drawing.Point(0, 90);
            this.btnBrand.Name = "btnBrand";
            this.btnBrand.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnBrand.Size = new System.Drawing.Size(183, 45);
            this.btnBrand.TabIndex = 5;
            this.btnBrand.Text = "Brand";
            this.btnBrand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrand.UseVisualStyleBackColor = true;
            this.btnBrand.Click += new System.EventHandler(this.btnBrand_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.ForeColor = System.Drawing.Color.White;
            this.btnCategory.Location = new System.Drawing.Point(0, 45);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnCategory.Size = new System.Drawing.Size(183, 45);
            this.btnCategory.TabIndex = 4;
            this.btnCategory.Text = "Category";
            this.btnCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnProductList
            // 
            this.btnProductList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductList.FlatAppearance.BorderSize = 0;
            this.btnProductList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductList.ForeColor = System.Drawing.Color.White;
            this.btnProductList.Location = new System.Drawing.Point(0, 0);
            this.btnProductList.Name = "btnProductList";
            this.btnProductList.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnProductList.Size = new System.Drawing.Size(183, 45);
            this.btnProductList.TabIndex = 3;
            this.btnProductList.Text = "Product List";
            this.btnProductList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductList.UseVisualStyleBackColor = true;
            this.btnProductList.Click += new System.EventHandler(this.btnProductList_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Location = new System.Drawing.Point(0, 215);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnProduct.Size = new System.Drawing.Size(183, 45);
            this.btnProduct.TabIndex = 2;
            this.btnProduct.Text = "Product";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 170);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(183, 45);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "DashBoard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.lblName);
            this.panelLogo.Controls.Add(this.lblUsername);
            this.panelLogo.Controls.Add(this.lblRole);
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(183, 170);
            this.panelLogo.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(3, 90);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(25, 20);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Ln";
            this.lblName.Visible = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(42, 115);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(85, 20);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "UserName";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(33, 135);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(104, 20);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "Administrator";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(46, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(200, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(984, 40);
            this.panelTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(283, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(333, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TitleName";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(200, 40);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(984, 531);
            this.panelMain.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(1184, 571);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelSlide);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supermarket24";
            this.panelSlide.ResumeLayout(false);
            this.panelSubSettings.ResumeLayout(false);
            this.panelSubRecord.ResumeLayout(false);
            this.panelSubStock.ResumeLayout(false);
            this.panelSubProduct.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSlide;
        private System.Windows.Forms.Panel panelSubProduct;
        private System.Windows.Forms.Button btnBrand;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnProductList;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelSubStock;
        private System.Windows.Forms.Button btnStockAdjustment;
        private System.Windows.Forms.Button btnStockEntry;
        private System.Windows.Forms.Button btnInStock;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Panel panelSubRecord;
        private System.Windows.Forms.Button btnPOSRecord;
        private System.Windows.Forms.Button btnSaleHistory;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelSubSettings;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
    }
}

