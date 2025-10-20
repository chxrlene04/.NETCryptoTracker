namespace WinFormsApp
{
    partial class TransactionsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitialiseComponent()
        {
            panelTopNav = new Panel();
            btnTrending = new Button();
            btnTransactions = new Button();
            btnCoinDetails = new Button();
            btnDashboard = new Button();
            btnAddTransaction = new Button();
            btnEditSelected = new Button();
            btnDeleteSelected = new Button();
            btnSaveToFile = new Button();
            dgvTransactions = new DataGridView();
            grpAddEdit = new GroupBox();
            TransactionTypeLbl = new Label();
            cmbTransactionType = new ComboBox();
            CryptocurrencyLbl = new Label();
            cmbCoin = new ComboBox();
            DateLbl = new Label();
            dtpDate = new DateTimePicker();
            AmountLbl = new Label();
            txtAmount = new TextBox();
            PricePerCoinLbl = new Label();
            txtPrice = new TextBox();
            TotalValueTextLbl = new Label();
            lblTotalValue = new Label();
            btnClear = new Button();
            btnSave = new Button();
            panelTopNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            grpAddEdit.SuspendLayout();
            SuspendLayout();
            // 
            // panelTopNav
            // 
            panelTopNav.BackColor = Color.FromArgb(45, 45, 48);
            panelTopNav.Controls.Add(btnTrending);
            panelTopNav.Controls.Add(btnTransactions);
            panelTopNav.Controls.Add(btnCoinDetails);
            panelTopNav.Controls.Add(btnDashboard);
            panelTopNav.Dock = DockStyle.Top;
            panelTopNav.Location = new Point(0, 0);
            panelTopNav.Name = "panelTopNav";
            panelTopNav.Size = new Size(1000, 60);
            panelTopNav.TabIndex = 1;
            // 
            // btnTrending
            // 
            btnTrending.FlatStyle = FlatStyle.Flat;
            btnTrending.Font = new Font("Segoe UI", 10F);
            btnTrending.ForeColor = Color.White;
            btnTrending.Location = new Point(719, 12);
            btnTrending.Name = "btnTrending";
            btnTrending.Size = new Size(200, 40);
            btnTrending.TabIndex = 3;
            btnTrending.Text = "Trending";
            btnTrending.UseVisualStyleBackColor = true;
            // 
            // btnTransactions
            // 
            btnTransactions.FlatStyle = FlatStyle.Flat;
            btnTransactions.Font = new Font("Segoe UI", 10F);
            btnTransactions.ForeColor = Color.White;
            btnTransactions.Location = new Point(509, 12);
            btnTransactions.Name = "btnTransactions";
            btnTransactions.Size = new Size(200, 40);
            btnTransactions.TabIndex = 2;
            btnTransactions.Text = "Transactions";
            btnTransactions.UseVisualStyleBackColor = true;
            // 
            // btnCoinDetails
            // 
            btnCoinDetails.FlatStyle = FlatStyle.Flat;
            btnCoinDetails.Font = new Font("Segoe UI", 10F);
            btnCoinDetails.ForeColor = Color.White;
            btnCoinDetails.Location = new Point(299, 12);
            btnCoinDetails.Name = "btnCoinDetails";
            btnCoinDetails.Size = new Size(200, 40);
            btnCoinDetails.TabIndex = 1;
            btnCoinDetails.Text = "Coin Details";
            btnCoinDetails.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10F);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(89, 12);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(200, 40);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = true;



            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTransaction.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddTransaction.ForeColor = System.Drawing.Color.White;
            this.btnAddTransaction.Location = new System.Drawing.Point(20, 80);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(140, 35);
            this.btnAddTransaction.TabIndex = 1;
            this.btnAddTransaction.Text = "Add Transaction";
            this.btnAddTransaction.UseVisualStyleBackColor = false;
            // 
            // btnEditSelected
            // 
            this.btnEditSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditSelected.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEditSelected.Location = new System.Drawing.Point(170, 80);
            this.btnEditSelected.Name = "btnEditSelected";
            this.btnEditSelected.Size = new System.Drawing.Size(130, 35);
            this.btnEditSelected.TabIndex = 2;
            this.btnEditSelected.Text = "Edit Selected";
            this.btnEditSelected.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSelected.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDeleteSelected.Location = new System.Drawing.Point(310, 80);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(130, 35);
            this.btnDeleteSelected.TabIndex = 3;
            this.btnDeleteSelected.Text = "Delete Selected";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveToFile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSaveToFile.Location = new System.Drawing.Point(450, 80);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(120, 35);
            this.btnSaveToFile.TabIndex = 4;
            this.btnSaveToFile.Text = "Save to File";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Location = new System.Drawing.Point(20, 130);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.Size = new System.Drawing.Size(960, 200);
            this.dgvTransactions.TabIndex = 6;
            // 
            // grpAddEdit
            // 
            this.grpAddEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            grpAddEdit.Controls.Add(btnSave);
            grpAddEdit.Controls.Add(btnClear);
            grpAddEdit.Controls.Add(lblTotalValue);
            grpAddEdit.Controls.Add(TotalValueTextLbl);
            grpAddEdit.Controls.Add(txtPrice);
            grpAddEdit.Controls.Add(PricePerCoinLbl);
            grpAddEdit.Controls.Add(txtAmount);
            grpAddEdit.Controls.Add(AmountLbl);
            grpAddEdit.Controls.Add(dtpDate);
            grpAddEdit.Controls.Add(DateLbl);
            grpAddEdit.Controls.Add(cmbCoin);
            grpAddEdit.Controls.Add(CryptocurrencyLbl);
            grpAddEdit.Controls.Add(cmbTransactionType);
            grpAddEdit.Controls.Add(TransactionTypeLbl);
            this.grpAddEdit.Location = new System.Drawing.Point(20, 350);
            grpAddEdit.Name = "grpAddEdit";
            this.grpAddEdit.Size = new System.Drawing.Size(960, 220);
            grpAddEdit.TabIndex = 7;
            grpAddEdit.TabStop = false;
            grpAddEdit.Text = "Add/Edit Transactions";
            this.grpAddEdit.Font = new System.Drawing.Font("Segoe UI", 10F);

            // 
            // TransactionTypeLbl
            // 
            TransactionTypeLbl.AutoSize = true;
            TransactionTypeLbl.Location = new System.Drawing.Point(20, 53);
            TransactionTypeLbl.Name = "TransactionTypeLbl";
            TransactionTypeLbl.Size = new System.Drawing.Size(118, 19);
            TransactionTypeLbl.TabIndex = 0;
            TransactionTypeLbl.Text = "Transaction Type";
            // 
            // cmbTransactionType
            // 
            this.cmbTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransactionType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTransactionType.FormattingEnabled = true;
            this.cmbTransactionType.Location = new System.Drawing.Point(140, 50);
            this.cmbTransactionType.Name = "cmbTransactionType";
            this.cmbTransactionType.Size = new System.Drawing.Size(200, 25);
            this.cmbTransactionType.TabIndex = 6;
            // 
            // CryptocurrencyLbl
            // 
            CryptocurrencyLbl.AutoSize = true;
            CryptocurrencyLbl.Location = new System.Drawing.Point(20, 93);
            CryptocurrencyLbl.Name = "CryptocurrencyLbl";
            CryptocurrencyLbl.Size = new System.Drawing.Size(114, 19);
            CryptocurrencyLbl.TabIndex = 1;
            CryptocurrencyLbl.Text = "Cryptocurrency";
            // 
            // cmbCoin
            // 
            this.cmbCoin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCoin.FormattingEnabled = true;
            this.cmbCoin.Location = new System.Drawing.Point(140, 90);
            this.cmbCoin.Name = "cmbCoin";
            this.cmbCoin.Size = new System.Drawing.Size(200, 25);
            this.cmbCoin.TabIndex = 7;
            // 
            // DateLbl
            // 
            DateLbl.AutoSize = true;
            DateLbl.Location = new System.Drawing.Point(20, 133);
            DateLbl.Name = "DateLbl";
            DateLbl.Size = new System.Drawing.Size(42, 19);
            DateLbl.TabIndex = 2;
            DateLbl.Text = "Date ";

            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(140, 130);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 25);
            this.dtpDate.TabIndex = 8;
            // 
            // AmountLbl
            // 
            AmountLbl.AutoSize = true;
            AmountLbl.Location = new System.Drawing.Point(400, 53);
            AmountLbl.Name = "AmountLbl";
            AmountLbl.Size = new System.Drawing.Size(66, 19);
            AmountLbl.TabIndex = 3;
            AmountLbl.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAmount.Location = new System.Drawing.Point(520, 50);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(200, 25);
            this.txtAmount.TabIndex = 9;
            // 
            // PricePerCoinLbl
            // 
            PricePerCoinLbl.AutoSize = true;
            PricePerCoinLbl.Location = new System.Drawing.Point(400, 93);
            PricePerCoinLbl.Name = "PricePerCoinLbl";
            PricePerCoinLbl.Size = new System.Drawing.Size(104, 19);
            PricePerCoinLbl.TabIndex = 4;
            PricePerCoinLbl.Text = "Price per Coin";
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrice.Location = new System.Drawing.Point(520, 90);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 25);
            this.txtPrice.TabIndex = 10;
            // 
            // TotalValueTextLbl
            // 
            TotalValueTextLbl.AutoSize = true;
            TotalValueTextLbl.Location = new System.Drawing.Point(400, 133);
            TotalValueTextLbl.Name = "TotalValueTextLbl";
            TotalValueTextLbl.Size = new System.Drawing.Size(85, 19);
            TotalValueTextLbl.TabIndex = 5;
            TotalValueTextLbl.Text = "Total Value";

            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTotalValue.Location = new System.Drawing.Point(520, 130);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(54, 21);
            this.lblTotalValue.TabIndex = 11;
            this.lblTotalValue.Text = "$0.00";
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(250, 170);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 35);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(140, 170);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // TransactionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(grpAddEdit);
            Controls.Add(dgvTransactions);
            Controls.Add(btnSaveToFile);
            Controls.Add(btnDeleteSelected);
            Controls.Add(btnEditSelected);
            Controls.Add(btnAddTransaction);
            Controls.Add(panelTopNav);
            Name = "TransactionsForm";
            Text = "Crypto Tracker - Transactions";
            panelTopNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            grpAddEdit.ResumeLayout(false);
            grpAddEdit.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTopNav;
        private Button btnTrending;
        private Button btnTransactions;
        private Button btnCoinDetails;
        private Button btnDashboard;
        private Button btnAddTransaction;
        private Button btnEditSelected;
        private Button btnDeleteSelected;
        private Button btnSaveToFile;
        private DataGridView dgvTransactions;
        private GroupBox grpAddEdit;
        private Label DateLbl;
        private ComboBox cmbCoin;
        private Label CryptocurrencyLbl;
        private ComboBox cmbTransactionType;
        private Label TransactionTypeLbl;
        private DateTimePicker dtpDate;
        private Label TotalValueTextLbl;
        private TextBox txtPrice;
        private Label PricePerCoinLbl;
        private TextBox txtAmount;
        private Label AmountLbl;
        private Label lblTotalValue;
        private Button btnSave;
        private Button btnClear;
    }
}