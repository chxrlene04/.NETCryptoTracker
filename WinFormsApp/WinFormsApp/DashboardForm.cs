using WinFormsApp.Models;
using WinFormsApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class DashboardForm : Form
    {
        // Services - demonstrates dependency injection and low coupling
        private readonly TransactionService _transactionService;
        private readonly CryptoService _cryptoService;
        private readonly PortfolioService _portfolioService;

        public DashboardForm()
        {
            InitializeComponent();

            // Initialize services
            _transactionService = new TransactionService();
            _cryptoService = new CryptoService();
            _portfolioService = new PortfolioService(_transactionService, _cryptoService);

            // Load dummy data
            LoadDummyTransactions();

            // Setup DataGridView
            SetupDataGridView();

            // Load initial data
            RefreshDashboard();

            // Wire up event handlers
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            // Button click events
            btnRefresh.Click += BtnRefresh_Click;
            btnViewTransactions.Click += BtnViewTransactions_Click;
            btnAddCoin.Click += BtnAddCoin_Click;

            // Navigation buttons
            btnDashboard.Click += (s, e) => HighlightButton(btnDashboard);
            btnCoinDetails.Click += BtnCoinDetails_Click;
            btnTransactions.Click += BtnTransactions_Click;
            btnTrending.Click += BtnTrending_Click;

            // Highlight dashboard button on load
            HighlightButton(btnDashboard);
        }

        private void SetupDataGridView()
        {
            // Clear any existing columns
            dgvPortfolio.Columns.Clear();
            dgvPortfolio.AutoGenerateColumns = false;
            dgvPortfolio.AllowUserToAddRows = false;
            dgvPortfolio.ReadOnly = true;
            dgvPortfolio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Add columns manually for better control
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

            // Custom cell formatting for profit/loss colors
            dgvPortfolio.CellFormatting += DgvPortfolio_CellFormatting;
        }

        private void DgvPortfolio_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Color the 24h Change column based on positive/negative
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
            // Load realistic dummy transactions to demonstrate functionality
            try
            {
                _transactionService.Add(new Transaction(
                    new DateTime(2025, 9, 28),
                    TransactionType.Buy,
                    "BTC",
                    0.1000m,
                    44200m
                ));

                _transactionService.Add(new Transaction(
                    new DateTime(2025, 9, 25),
                    TransactionType.Buy,
                    "ETH",
                    1.5000m,
                    2615m
                ));

                _transactionService.Add(new Transaction(
                    new DateTime(2025, 9, 20),
                    TransactionType.Buy,
                    "ADA",
                    5000m,
                    0.39m
                ));

                _transactionService.Add(new Transaction(
                    new DateTime(2025, 9, 15),
                    TransactionType.Buy,
                    "SOL",
                    25m,
                    24.15m
                ));

                _transactionService.Add(new Transaction(
                    new DateTime(2025, 9, 28),
                    TransactionType.Buy,
                    "BTC",
                    0.3523m,
                    44500m
                ));

                _transactionService.Add(new Transaction(
                    new DateTime(2025, 9, 22),
                    TransactionType.Buy,
                    "ETH",
                    3.734m,
                    2620m
                ));

                _transactionService.Add(new Transaction(
                    new DateTime(2025, 9, 18),
                    TransactionType.Buy,
                    "ADA",
                    10230m,
                    0.385m
                ));

                _transactionService.Add(new Transaction(
                    new DateTime(2025, 9, 12),
                    TransactionType.Buy,
                    "DOT",
                    450m,
                    5.44m
                ));

                _transactionService.Add(new Transaction(
                    new DateTime(2025, 9, 10),
                    TransactionType.Buy,
                    "SOL",
                    100.5m,
                    24.00m
                ));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dummy data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDashboard()
        {
            try
            {
                // Get portfolio data
                var portfolio = _portfolioService.GetPortfolio();

                // Update stats labels
                lblTotalValue.Text = $"${_portfolioService.GetTotalPortfolioValue():N0}";
                lblTotalInvested.Text = $"${_portfolioService.GetTotalInvested():N0}";

                var profitLoss = _portfolioService.GetTotalProfitLoss();
                lblProfitLoss.Text = $"{(profitLoss >= 0 ? "+" : "")}${profitLoss:N0}";
                lblProfitLoss.ForeColor = profitLoss >= 0 ? Color.Green : Color.Red;

                lblAssets.Text = _portfolioService.GetAssetCount().ToString();

                // Update DataGridView
                dgvPortfolio.DataSource = null;
                dgvPortfolio.DataSource = portfolio;

                // Refresh changes column with actual coin data
                RefreshChangeData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing dashboard: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshChangeData()
        {
            // Update the 24h change column with actual coin change data
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

        // Event Handlers
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // Simulate price refresh
                _cryptoService.RefreshPrices();
                RefreshDashboard();
                MessageBox.Show("Prices refreshed successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing prices: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnViewTransactions_Click(object sender, EventArgs e)
        {
            // Navigate to transactions form (you'll create this next)
            MessageBox.Show("Transactions screen coming next!",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Open TransactionsForm
            // var transactionsForm = new TransactionsForm(_transactionService, _cryptoService);
            // transactionsForm.Show();
            // this.Hide();
        }

        private void BtnAddCoin_Click(object sender, EventArgs e)
        {
            // Quick add coin dialog
            MessageBox.Show("Add Coin feature - to be implemented in Transactions screen",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Navigation button handlers
        private void BtnCoinDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coin Details screen - Person 2's responsibility",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            HighlightButton(btnCoinDetails);
        }

        private void BtnTransactions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Transactions screen - Person 3's responsibility",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            HighlightButton(btnTransactions);
        }

        private void BtnTrending_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trending screen - Bonus/split work",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            HighlightButton(btnTrending);
        }

        private void HighlightButton(Button activeButton)
        {
            // Reset all navigation buttons to default
            foreach (Control control in panelTopNav.Controls)
            {
                if (control is Button btn)
                {
                    btn.BackColor = SystemColors.Control;
                    btn.ForeColor = Color.Black;
                }
            }

            // Highlight the active button
            activeButton.BackColor = Color.DodgerBlue;
            activeButton.ForeColor = Color.White;
        }
    }
}