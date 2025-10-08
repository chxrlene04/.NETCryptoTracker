namespace WinFormsApp
{
    partial class CoinDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelTopNav = new Panel();
            btnTrending = new Button();
            btnTransactions = new Button();
            btnCoinDetails = new Button();
            btnDashboard = new Button();
            btnAddToPortfolio = new Button();
            selectCryptoLabel = new Label();
            chooseCoinLabel = new Label();
            cmbCoins = new ComboBox();
            currentInfoLabel = new Label();
            priceLabel = new Label();
            lblPrice = new Label();
            hrChangeLbl = new Label();
            lblChange24h = new Label();
            marketCapLabel = new Label();
            lblMarketCap = new Label();
            volumeLabel = new Label();
            lblVolume = new Label();
            priceHistoryLabel = new Label();
            dgvPriceHistory = new DataGridView();
            panelTopNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPriceHistory).BeginInit();
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
            panelTopNav.TabIndex = 0;
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
            // btnAddToPortfolio
            // 
            btnAddToPortfolio.BackColor = Color.DodgerBlue;
            btnAddToPortfolio.FlatStyle = FlatStyle.Flat;
            btnAddToPortfolio.Font = new Font("Segoe UI", 10F);
            btnAddToPortfolio.ForeColor = Color.White;
            btnAddToPortfolio.Location = new Point(20, 80);
            btnAddToPortfolio.Name = "btnAddToPortfolio";
            btnAddToPortfolio.Size = new Size(172, 35);
            btnAddToPortfolio.TabIndex = 4;
            btnAddToPortfolio.Text = "Add to Portfolio";
            btnAddToPortfolio.UseVisualStyleBackColor = false;
            // 
            // selectCryptoLabel
            // 
            selectCryptoLabel.AutoSize = true;
            selectCryptoLabel.Font = new Font("Segoe UI", 12F);
            selectCryptoLabel.Location = new Point(20, 130);
            selectCryptoLabel.Name = "selectCryptoLabel";
            selectCryptoLabel.Size = new Size(162, 21);
            selectCryptoLabel.TabIndex = 5;
            selectCryptoLabel.Text = "Select Cryptocurrency";
            // 
            // chooseCoinLabel
            // 
            chooseCoinLabel.AutoSize = true;
            chooseCoinLabel.Font = new Font("Segoe UI", 9F);
            chooseCoinLabel.Location = new Point(20, 160);
            chooseCoinLabel.Name = "chooseCoinLabel";
            chooseCoinLabel.Size = new Size(78, 15);
            chooseCoinLabel.TabIndex = 6;
            chooseCoinLabel.Text = "Choose Coin:";
            // 
            // cmbCoins
            // 
            cmbCoins.FormattingEnabled = true;
            cmbCoins.Location = new Point(104, 157);
            cmbCoins.Name = "cmbCoins";
            cmbCoins.Size = new Size(150, 23);
            cmbCoins.TabIndex = 7;
            // 
            // currentInfoLabel
            // 
            currentInfoLabel.AutoSize = true;
            currentInfoLabel.Font = new Font("Segoe UI", 12F);
            currentInfoLabel.Location = new Point(20, 200);
            currentInfoLabel.Name = "currentInfoLabel";
            currentInfoLabel.Size = new Size(94, 21);
            currentInfoLabel.TabIndex = 8;
            currentInfoLabel.Text = "Current Info";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Font = new Font("Segoe UI", 9F);
            priceLabel.Location = new Point(20, 235);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(36, 15);
            priceLabel.TabIndex = 9;
            priceLabel.Text = "Price:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblPrice.Location = new Point(20, 250);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(39, 30);
            lblPrice.TabIndex = 10;
            lblPrice.Text = "$0";
            // 
            // hrChangeLbl
            // 
            hrChangeLbl.AutoSize = true;
            hrChangeLbl.Font = new Font("Segoe UI", 9F);
            hrChangeLbl.Location = new Point(180, 235);
            hrChangeLbl.Name = "hrChangeLbl";
            hrChangeLbl.Size = new Size(73, 15);
            hrChangeLbl.TabIndex = 11;
            hrChangeLbl.Text = "24h Change:";
            // 
            // lblChange24h
            // 
            lblChange24h.AutoSize = true;
            lblChange24h.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblChange24h.ForeColor = Color.Green;
            lblChange24h.Location = new Point(180, 250);
            lblChange24h.Name = "lblChange24h";
            lblChange24h.Size = new Size(45, 30);
            lblChange24h.TabIndex = 12;
            lblChange24h.Text = "0%";
            // 
            // marketCapLabel
            // 
            marketCapLabel.AutoSize = true;
            marketCapLabel.Font = new Font("Segoe UI", 9F);
            marketCapLabel.Location = new Point(350, 235);
            marketCapLabel.Name = "marketCapLabel";
            marketCapLabel.Size = new Size(71, 15);
            marketCapLabel.TabIndex = 13;
            marketCapLabel.Text = "Market Cap:";
            // 
            // lblMarketCap
            // 
            lblMarketCap.AutoSize = true;
            lblMarketCap.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblMarketCap.Location = new Point(350, 250);
            lblMarketCap.Name = "lblMarketCap";
            lblMarketCap.Size = new Size(39, 30);
            lblMarketCap.TabIndex = 14;
            lblMarketCap.Text = "$0";
            // 
            // volumeLabel
            // 
            volumeLabel.AutoSize = true;
            volumeLabel.Font = new Font("Segoe UI", 9F);
            volumeLabel.Location = new Point(720, 235);
            volumeLabel.Name = "volumeLabel";
            volumeLabel.Size = new Size(50, 15);
            volumeLabel.TabIndex = 15;
            volumeLabel.Text = "Volume:";
            // 
            // lblVolume
            // 
            lblVolume.AutoSize = true;
            lblVolume.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblVolume.Location = new Point(720, 250);
            lblVolume.Name = "lblVolume";
            lblVolume.Size = new Size(39, 30);
            lblVolume.TabIndex = 16;
            lblVolume.Text = "$0";
            // 
            // priceHistoryLabel
            // 
            priceHistoryLabel.AutoSize = true;
            priceHistoryLabel.Font = new Font("Segoe UI", 12F);
            priceHistoryLabel.Location = new Point(20, 320);
            priceHistoryLabel.Name = "priceHistoryLabel";
            priceHistoryLabel.Size = new Size(144, 21);
            priceHistoryLabel.TabIndex = 17;
            priceHistoryLabel.Text = "7-Day Price History";
            // 
            // dgvPriceHistory
            // 
            dgvPriceHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPriceHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPriceHistory.Location = new Point(20, 360);
            dgvPriceHistory.Name = "dgvPriceHistory";
            dgvPriceHistory.Size = new Size(960, 210);
            dgvPriceHistory.TabIndex = 18;
            // 
            // CoinDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(dgvPriceHistory);
            Controls.Add(priceHistoryLabel);
            Controls.Add(lblVolume);
            Controls.Add(volumeLabel);
            Controls.Add(lblMarketCap);
            Controls.Add(marketCapLabel);
            Controls.Add(lblChange24h);
            Controls.Add(hrChangeLbl);
            Controls.Add(lblPrice);
            Controls.Add(priceLabel);
            Controls.Add(currentInfoLabel);
            Controls.Add(cmbCoins);
            Controls.Add(chooseCoinLabel);
            Controls.Add(selectCryptoLabel);
            Controls.Add(btnAddToPortfolio);
            Controls.Add(panelTopNav);
            Name = "CoinDetailsForm";
            Text = "Crypto Tracker - Coin Details";
            panelTopNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPriceHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTopNav;
        private Button btnTrending;
        private Button btnTransactions;
        private Button btnCoinDetails;
        private Button btnDashboard;
        private Button btnAddToPortfolio;
        private Label selectCryptoLabel;
        private Label chooseCoinLabel;
        private ComboBox cmbCoins;
        private Label currentInfoLabel;
        private Label priceLabel;
        private Label lblPrice;
        private Label hrChangeLbl;
        private Label lblChange24h;
        private Label marketCapLabel;
        private Label lblMarketCap;
        private Label volumeLabel;
        private Label lblVolume;
        private Label priceHistoryLabel;
        private DataGridView dgvPriceHistory;
    }
}
