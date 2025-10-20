using WinFormsApp.Models;
using WinFormsApp.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class DashboardForm : Form
    {
        private readonly TransactionService _transactionService;
        private readonly CryptoService _cryptoService;
        private readonly PortfolioService _portfolioService;

        public DashboardForm()
        {
            InitialiseComponent();

            // Initialise services
            _transactionService = new TransactionService();
            _cryptoService = new CryptoService();
            _portfolioService = new PortfolioService(_transactionService, _cryptoService);

            // Load dummy data
            LoadDummyTransactions();

            // Setup DataGridView
            SetupDataGridView();

            // Wire up events
            WireUpEvents();

            // Highlight nav
            HighlightNav();

            // Load data asynchronously
            this.Load += DashboardForm_Load;
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            await RefreshDashboardAsync();
        }

        private void WireUpEvents()
        {
            btnRefresh.Click += async (s, e) => await BtnRefresh_Click_Async(s, e);
            btnViewTransactions.Click += BtnViewTransactions_Click;
            btnAddCoin.Click += BtnAddCoin_Click;

            btnDashboard.Click += (s, e) => HighlightButton(btnDashboard);
            btnCoinDetails.Click += BtnCoinDetails_Click;
            btnTransactions.Click += BtnTransactions_Click;
            btnTrending.Click += BtnTrending_Click;
        }

        private void SetupDataGridView()
        {
            dgvPortfolio.Columns.Clear();
            dgvPortfolio.AutoGenerateColumns = false;
            dgvPortfolio.AllowUserToAddRows = false;
            dgvPortfolio.ReadOnly = true;
            dgvPortfolio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvPortfolio.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CoinSymbol",
                HeaderText = "Symbol",
                Name = "Symbol",
                Width = 80
            });

            dgvPortfolio.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Amount",
                HeaderText = "Amount",
                Name = "Amount",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N4" }
            });

            dgvPortfolio.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CurrentPrice",
                HeaderText = "Price",
                Name = "Price",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvPortfolio.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalValue",
                HeaderText = "Total Value",
                Name = "TotalValue",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvPortfolio.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProfitLossPercentage",
                HeaderText = "24h Change",
                Name = "Change24h",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            dgvPortfolio.CellFormatting += DgvPortfolio_CellFormatting;
        }

        private void DgvPortfolio_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPortfolio.Columns[e.ColumnIndex].Name == "Change24h" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.CellStyle.ForeColor = value >= 0 ? Color.Green : Color.Red;
                    e.Value = $"{(value >= 0 ? "+" : "")}{value:N2}%";
                    e.FormattingApplied = true;
                }
            }
        }

        private void LoadDummyTransactions()
        {
            try
            {
                _transactionService.Add(new Transaction(new DateTime(2025, 9, 28), TransactionType.Buy, "BTC", 0.1000m, 44200m));
                _transactionService.Add(new Transaction(new DateTime(2025, 9, 25), TransactionType.Buy, "ETH", 1.5000m, 2615m));
                _transactionService.Add(new Transaction(new DateTime(2025, 9, 20), TransactionType.Buy, "ADA", 5000m, 0.39m));
                _transactionService.Add(new Transaction(new DateTime(2025, 9, 15), TransactionType.Buy, "SOL", 25m, 24.15m));
                _transactionService.Add(new Transaction(new DateTime(2025, 9, 28), TransactionType.Buy, "BTC", 0.3523m, 44500m));
                _transactionService.Add(new Transaction(new DateTime(2025, 9, 22), TransactionType.Buy, "ETH", 3.734m, 2620m));
                _transactionService.Add(new Transaction(new DateTime(2025, 9, 18), TransactionType.Buy, "ADA", 10230m, 0.385m));
                _transactionService.Add(new Transaction(new DateTime(2025, 9, 12), TransactionType.Buy, "DOT", 450m, 5.44m));
                _transactionService.Add(new Transaction(new DateTime(2025, 9, 10), TransactionType.Buy, "SOL", 100.5m, 24.00m));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dummy data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async System.Threading.Tasks.Task RefreshDashboardAsync()
        {
            try
            {
                // Show loading cursor
                this.Cursor = Cursors.WaitCursor;
                btnRefresh.Enabled = false;
                btnRefresh.Text = "Loading...";

                // Get live prices from API
                await _cryptoService.RefreshPricesAsync();

                // Get portfolio with updated prices
                var portfolio = _portfolioService.GetPortfolio();

                // Update live prices for each portfolio item
                var liveCoins = await _cryptoService.GetAllCoinsAsync();
                foreach (var item in portfolio)
                {
                    var liveCoin = liveCoins.FirstOrDefault(c => c.Symbol.Equals(item.CoinSymbol, StringComparison.OrdinalIgnoreCase));
                    if (liveCoin != null)
                    {
                        item.CurrentPrice = liveCoin.CurrentPrice;
                    }
                }

                // Update DataGridView
                dgvPortfolio.DataSource = null;
                dgvPortfolio.DataSource = portfolio;

                // Update summary labels
                lblTotalValue.Text = $"${_portfolioService.GetTotalPortfolioValue():N0}";
                lblTotalInvested.Text = $"${_portfolioService.GetTotalInvested():N0}";

                var profitLoss = _portfolioService.GetTotalProfitLoss();
                lblProfitLoss.Text = $"{(profitLoss >= 0 ? "+" : "")}${profitLoss:N0}";
                lblProfitLoss.ForeColor = profitLoss >= 0 ? Color.Green : Color.Red;

                lblAssets.Text = _portfolioService.GetAssetCount().ToString();

                // Update 24h change column
                RefreshChangeData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnRefresh.Enabled = true;
                btnRefresh.Text = "Refresh";
            }
        }

        private void RefreshChangeData()
        {
            foreach (DataGridViewRow row in dgvPortfolio.Rows)
            {
                if (row.DataBoundItem is PortfolioItem item)
                {
                    var coin = _cryptoService.GetCoinBySymbol(item.CoinSymbol);
                    if (coin != null)
                    {
                        row.Cells["Change24h"].Value = coin.Change24h;
                    }
                }
            }
        }

        private async System.Threading.Tasks.Task BtnRefresh_Click_Async(object sender, EventArgs e)
        {
            await RefreshDashboardAsync();
            MessageBox.Show("Prices refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnViewTransactions_Click(object sender, EventArgs e)
        {
            try
            {
                var transactionsForm = new TransactionsForm(_transactionService, _cryptoService);
                transactionsForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening transactions form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddCoin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Coin feature - to be implemented in Transactions screen", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCoinDetails_Click(object sender, EventArgs e)
        {
            try
            {
                var coinDetailsForm = new CoinDetailsForm(_cryptoService, _transactionService);
                coinDetailsForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening coin details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTransactions_Click(object sender, EventArgs e)
        {
            try
            {
                var transactionsForm = new TransactionsForm(_transactionService, _cryptoService);
                transactionsForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening transactions form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTrending_Click(object sender, EventArgs e)
        {
            string apiKey = "CG-soteDFybxG9PyLxHe3fAP3re";
            var coinGeckoApi = new CoinGeckoApiService(apiKey, apiKey);
            var trendingForm = new Form3(coinGeckoApi);
            trendingForm.Show();
            this.Hide();
        }

        private void HighlightButton(Button activeButton)
        {
            foreach (Control control in panelTopNav.Controls)
            {
                if (control is Button btn)
                {
                    btn.BackColor = SystemColors.Control;
                    btn.ForeColor = Color.Black;
                }
            }
            activeButton.BackColor = Color.DodgerBlue;
            activeButton.ForeColor = Color.White;
        }

        private void HighlightNav()
        {
            btnDashboard.BackColor = Color.DodgerBlue;
            btnDashboard.ForeColor = Color.White;
            btnCoinDetails.BackColor = Color.FromArgb(45, 45, 48);
            btnCoinDetails.ForeColor = Color.White;
            btnTransactions.BackColor = Color.FromArgb(45, 45, 48);
            btnTransactions.ForeColor = Color.White;
            btnTrending.BackColor = Color.FromArgb(45, 45, 48);
            btnTrending.ForeColor = Color.White;
        }

        public async void RefreshDashboardData()
        {
            await RefreshDashboardAsync();
        }
    }
}