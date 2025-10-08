namespace WinFormsApp
{
    partial class DashboardForm
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
            btnRefresh = new Button();
            btnViewTransactions = new Button();
            btnAddCoin = new Button();
            lblTotalValue = new Label();
            lblTotalInvested = new Label();
            lblProfitLoss = new Label();
            lblAssets = new Label();
            dgvPortfolio = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panelTopNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPortfolio).BeginInit();
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
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.DodgerBlue;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(20, 80);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 35);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnViewTransactions
            // 
            btnViewTransactions.FlatStyle = FlatStyle.Flat;
            btnViewTransactions.Font = new Font("Segoe UI", 10F);
            btnViewTransactions.Location = new Point(150, 80);
            btnViewTransactions.Name = "btnViewTransactions";
            btnViewTransactions.Size = new Size(160, 35);
            btnViewTransactions.TabIndex = 2;
            btnViewTransactions.Text = "View Transactions";
            btnViewTransactions.UseVisualStyleBackColor = true;
            // 
            // btnAddCoin
            // 
            btnAddCoin.FlatStyle = FlatStyle.Flat;
            btnAddCoin.Font = new Font("Segoe UI", 10F);
            btnAddCoin.Location = new Point(320, 80);
            btnAddCoin.Name = "btnAddCoin";
            btnAddCoin.Size = new Size(120, 35);
            btnAddCoin.TabIndex = 3;
            btnAddCoin.Text = "Add Coin";
            btnAddCoin.UseVisualStyleBackColor = true;
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalValue.Location = new Point(20, 150);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(39, 30);
            lblTotalValue.TabIndex = 5;
            lblTotalValue.Text = "$0";
            // 
            // lblTotalInvested
            // 
            lblTotalInvested.AutoSize = true;
            lblTotalInvested.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalInvested.Location = new Point(250, 150);
            lblTotalInvested.Name = "lblTotalInvested";
            lblTotalInvested.Size = new Size(39, 30);
            lblTotalInvested.TabIndex = 7;
            lblTotalInvested.Text = "$0";
            // 
            // lblProfitLoss
            // 
            lblProfitLoss.AutoSize = true;
            lblProfitLoss.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblProfitLoss.ForeColor = Color.Green;
            lblProfitLoss.Location = new Point(480, 150);
            lblProfitLoss.Name = "lblProfitLoss";
            lblProfitLoss.Size = new Size(39, 30);
            lblProfitLoss.TabIndex = 9;
            lblProfitLoss.Text = "$0";
            // 
            // lblAssets
            // 
            lblAssets.AutoSize = true;
            lblAssets.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAssets.Location = new Point(710, 150);
            lblAssets.Name = "lblAssets";
            lblAssets.Size = new Size(26, 30);
            lblAssets.TabIndex = 11;
            lblAssets.Text = "0";
            // 
            // dgvPortfolio
            // 
            dgvPortfolio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPortfolio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPortfolio.Location = new Point(20, 200);
            dgvPortfolio.Name = "dgvPortfolio";
            dgvPortfolio.Size = new Size(960, 350);
            dgvPortfolio.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(20, 135);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 4;
            label1.Text = "Total Value:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(250, 135);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 6;
            label2.Text = "Total Invested:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(480, 135);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 8;
            label3.Text = "Profit/Loss:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(710, 135);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 10;
            label4.Text = "Assets:";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(dgvPortfolio);
            Controls.Add(lblAssets);
            Controls.Add(label4);
            Controls.Add(lblProfitLoss);
            Controls.Add(label3);
            Controls.Add(lblTotalInvested);
            Controls.Add(label2);
            Controls.Add(lblTotalValue);
            Controls.Add(label1);
            Controls.Add(btnAddCoin);
            Controls.Add(btnViewTransactions);
            Controls.Add(btnRefresh);
            Controls.Add(panelTopNav);
            Name = "DashboardForm";
            Text = "Crypto Tracker - Dashboard";
            panelTopNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPortfolio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTopNav;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnCoinDetails;
        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.Button btnTrending;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnViewTransactions;
        private System.Windows.Forms.Button btnAddCoin;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblTotalInvested;
        private System.Windows.Forms.Label lblProfitLoss;
        private System.Windows.Forms.Label lblAssets;
        private System.Windows.Forms.DataGridView dgvPortfolio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}