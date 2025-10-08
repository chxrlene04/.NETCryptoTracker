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
            this.panelTopNav = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnCoinDetails = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnTrending = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnViewTransactions = new System.Windows.Forms.Button();
            this.btnAddCoin = new System.Windows.Forms.Button();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalInvested = new System.Windows.Forms.Label();
            this.lblProfitLoss = new System.Windows.Forms.Label();
            this.lblAssets = new System.Windows.Forms.Label();
            this.dgvPortfolio = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelTopNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPortfolio)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTopNav
            // 
            this.panelTopNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelTopNav.Controls.Add(this.btnTrending);
            this.panelTopNav.Controls.Add(this.btnTransactions);
            this.panelTopNav.Controls.Add(this.btnCoinDetails);
            this.panelTopNav.Controls.Add(this.btnDashboard);
            this.panelTopNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopNav.Location = new System.Drawing.Point(0, 0);
            this.panelTopNav.Name = "panelTopNav";
            this.panelTopNav.Size = new System.Drawing.Size(1000, 60);
            this.panelTopNav.TabIndex = 0;
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(20, 10);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(200, 40);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            // 
            // btnCoinDetails
            // 
            this.btnCoinDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCoinDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCoinDetails.ForeColor = System.Drawing.Color.White;
            this.btnCoinDetails.Location = new System.Drawing.Point(230, 10);
            this.btnCoinDetails.Name = "btnCoinDetails";
            this.btnCoinDetails.Size = new System.Drawing.Size(200, 40);
            this.btnCoinDetails.TabIndex = 1;
            this.btnCoinDetails.Text = "Coin Details";
            this.btnCoinDetails.UseVisualStyleBackColor = true;
            // 
            // btnTransactions
            // 
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTransactions.ForeColor = System.Drawing.Color.White;
            this.btnTransactions.Location = new System.Drawing.Point(440, 10);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(200, 40);
            this.btnTransactions.TabIndex = 2;
            this.btnTransactions.Text = "Transactions";
            this.btnTransactions.UseVisualStyleBackColor = true;
            // 
            // btnTrending
            // 
            this.btnTrending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrending.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTrending.ForeColor = System.Drawing.Color.White;
            this.btnTrending.Location = new System.Drawing.Point(650, 10);
            this.btnTrending.Name = "btnTrending";
            this.btnTrending.Size = new System.Drawing.Size(200, 40);
            this.btnTrending.TabIndex = 3;
            this.btnTrending.Text = "Trending";
            this.btnTrending.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(20, 80);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 35);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnViewTransactions
            // 
            this.btnViewTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewTransactions.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnViewTransactions.Location = new System.Drawing.Point(150, 80);
            this.btnViewTransactions.Name = "btnViewTransactions";
            this.btnViewTransactions.Size = new System.Drawing.Size(160, 35);
            this.btnViewTransactions.TabIndex = 2;
            this.btnViewTransactions.Text = "View Transactions";
            this.btnViewTransactions.UseVisualStyleBackColor = true;
            // 
            // btnAddCoin
            // 
            this.btnAddCoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCoin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddCoin.Location = new System.Drawing.Point(320, 80);
            this.btnAddCoin.Name = "btnAddCoin";
            this.btnAddCoin.Size = new System.Drawing.Size(120, 35);
            this.btnAddCoin.TabIndex = 3;
            this.btnAddCoin.Text = "Add Coin";
            this.btnAddCoin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(20, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Value:";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.Location = new System.Drawing.Point(20, 150);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(39, 30);
            this.lblTotalValue.TabIndex = 5;
            this.lblTotalValue.Text = "$0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(250, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total Invested:";
            // 
            // lblTotalInvested
            // 
            this.lblTotalInvested.AutoSize = true;
            this.lblTotalInvested.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalInvested.Location = new System.Drawing.Point(250, 150);
            this.lblTotalInvested.Name = "lblTotalInvested";
            this.lblTotalInvested.Size = new System.Drawing.Size(39, 30);
            this.lblTotalInvested.TabIndex = 7;
            this.lblTotalInvested.Text = "$0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(480, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Profit/Loss:";
            // 
            // lblProfitLoss
            // 
            this.lblProfitLoss.AutoSize = true;
            this.lblProfitLoss.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblProfitLoss.ForeColor = System.Drawing.Color.Green;
            this.lblProfitLoss.Location = new System.Drawing.Point(480, 150);
            this.lblProfitLoss.Name = "lblProfitLoss";
            this.lblProfitLoss.Size = new System.Drawing.Size(39, 30);
            this.lblProfitLoss.TabIndex = 9;
            this.lblProfitLoss.Text = "$0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(710, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Assets:";
            // 
            // lblAssets
            // 
            this.lblAssets.AutoSize = true;
            this.lblAssets.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAssets.Location = new System.Drawing.Point(710, 150);
            this.lblAssets.Name = "lblAssets";
            this.lblAssets.Size = new System.Drawing.Size(27, 30);
            this.lblAssets.TabIndex = 11;
            this.lblAssets.Text = "0";
            // 
            // dgvPortfolio
            // 
            this.dgvPortfolio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPortfolio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPortfolio.Location = new System.Drawing.Point(20, 200);
            this.dgvPortfolio.Name = "dgvPortfolio";
            this.dgvPortfolio.Size = new System.Drawing.Size(960, 350);
            this.dgvPortfolio.TabIndex = 12;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvPortfolio);
            this.Controls.Add(this.lblAssets);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblProfitLoss);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotalInvested);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddCoin);
            this.Controls.Add(this.btnViewTransactions);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panelTopNav);
            this.Name = "DashboardForm";
            this.Text = "Crypto Tracker - Dashboard";
            this.panelTopNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPortfolio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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