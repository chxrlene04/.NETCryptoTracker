using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Models;
using WinFormsApp.Services;

namespace WinFormsApp
{
    public partial class CoinDetailsForm : Form
    {
        private readonly CryptoService _cryptoService;
        private readonly TransactionService _transactionService;
        private bool _isLoading = false;

        /// <summary>
        /// Constructor - accepts shared services to maintain data consistency
        /// </summary>
        public CoinDetailsForm(CryptoService cryptoService, TransactionService transactionService)
        {
            InitializeComponent();

            _cryptoService = cryptoService ?? throw new ArgumentNullException(nameof(cryptoService));
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));

            // Setup UI
            SetupDataGridView();
            HighlightButton(btnCoinDetails);
            WireUpEvents();

            // Load initial data
            LoadCoinsAsync();
        }

        private void WireUpEvents()
        {
            // Navigation buttons
            btnDashboard.Click += BtnDashboard_Click;
            btnCoinDetails.Click += (s, e) => HighlightButton(btnCoinDetails);
            btnTransactions.Click += BtnTransactions_Click;
            btnTrending.Click += BtnTrending_Click;

            // Coin selection changed
            cmbCoins.SelectedIndexChanged += CmbCoins_SelectedIndexChanged;

            // Add to portfolio button
            btnAddToPortfolio.Click += BtnAddToPortfolio_Click;
        }

        private void SetupDataGridView()
        {
            dgvPriceHistory.Columns.Clear();
            dgvPriceHistory.AutoGenerateColumns = false;
            dgvPriceHistory.AllowUserToAddRows = false;
            dgvPriceHistory.ReadOnly = true;
            dgvPriceHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Setup columns for price history
            dgvPriceHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "Date",
                Name = "Date",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });

            dgvPriceHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Open",
                HeaderText = "Open",
                Name = "Open",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvPriceHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "High",
                HeaderText = "High",
                Name = "High",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvPriceHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Low",
                HeaderText = "Low",
                Name = "Low",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvPriceHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Close",
                HeaderText = "Close",
                Name = "Close",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvPriceHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ChangePercentage",
                HeaderText = "Change %",
                Name = "Change",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            // Color code the change column
            dgvPriceHistory.CellFormatting += DgvPriceHistory_CellFormatting;
        }

        private void DgvPriceHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPriceHistory.Columns[e.ColumnIndex].Name == "Change" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.CellStyle.ForeColor = value >= 0 ? Color.Green : Color.Red;
                    e.Value = $"{(value >= 0 ? "+" : "")}{value:N2}%";
                    e.FormattingApplied = true;
                }
            }
        }

        /// <summary>
        /// Loads all available coins into the dropdown
        /// This uses CACHED data - no API call unless cache is stale
        /// </summary>
        private async void LoadCoinsAsync()
        {
            try
            {
                _isLoading = true;
                cmbCoins.Enabled = false;
                cmbCoins.Items.Clear();
                cmbCoins.Items.Add("Loading...");
                cmbCoins.SelectedIndex = 0;

                // Get coins from service (uses cache if available, or calls API)
                var coins = await _cryptoService.GetAllCoinsAsync();

                cmbCoins.Items.Clear();

                // Add coins to dropdown with format: "Bitcoin (BTC)"
                foreach (var coin in coins.OrderBy(c => c.Name))
                {
                    cmbCoins.Items.Add(new CoinComboItem(coin));
                }

                if (cmbCoins.Items.Count > 0)
                {
                    cmbCoins.SelectedIndex = 0; // Select first coin (will trigger LoadCoinDetails)
                }
                else
                {
                    MessageBox.Show("No coins available. Using offline mode with dummy data.",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading coins: {ex.Message}\nUsing offline mode.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                _isLoading = false;
                cmbCoins.Enabled = true;
            }
        }

        /// <summary>
        /// Event handler for when user selects a different coin
        /// This gets data from CACHE - no new API call!
        /// </summary>
        private async void CmbCoins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading || cmbCoins.SelectedItem == null) return;

            var selectedItem = cmbCoins.SelectedItem as CoinComboItem;
            if (selectedItem == null) return;

            await LoadCoinDetailsAsync(selectedItem.Coin.Symbol);
        }

        /// <summary>
        /// Loads details for the selected coin
        /// Current price/stats come from cache (instant)
        /// Price history makes ONE API call per coin
        /// </summary>
        private async Task LoadCoinDetailsAsync(string symbol)
        {
            try
            {
                // Disable controls during load
                cmbCoins.Enabled = false;
                btnAddToPortfolio.Enabled = false;

                // Get current coin data from cache (instant - no API call)
                var coin = _cryptoService.GetCoinBySymbol(symbol);

                if (coin == null)
                {
                    MessageBox.Show($"Coin {symbol} not found.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update current info labels
                lblPrice.Text = $"${coin.CurrentPrice:N2}";

                // Color code the 24h change
                lblChange24h.Text = $"{(coin.Change24h >= 0 ? "+" : "")}{coin.Change24h:N2}%";
                lblChange24h.ForeColor = coin.Change24h >= 0 ? Color.Green : Color.Red;

                // Format large numbers nicely
                lblMarketCap.Text = FormatLargeNumber(coin.MarketCap);
                lblVolume.Text = FormatLargeNumber(coin.Volume);

                // Load price history (makes ONE API call per coin)
                await LoadPriceHistoryAsync(symbol);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading coin details: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmbCoins.Enabled = true;
                btnAddToPortfolio.Enabled = true;
            }
        }

        /// <summary>
        /// Loads 7-day price history for the selected coin
        /// This makes ONE API call (or uses dummy data if API unavailable)
        /// </summary>
        private async Task LoadPriceHistoryAsync(string symbol)
        {
            try
            {
                // Clear any previous data
                dgvPriceHistory.DataSource = null;

                // Temporary "loading" placeholder
                var loadingHistory = new List<CoinGeckoMarketData.PriceHistory>
        {
            new CoinGeckoMarketData.PriceHistory(DateTime.Now, 0, 0, 0, 0)
        };
                dgvPriceHistory.DataSource = loadingHistory;

                // Fetch price history from service (API call)
                var history = await _cryptoService.GetPriceHistoryAsync(symbol);

                // Display real data
                dgvPriceHistory.DataSource = null;
                dgvPriceHistory.DataSource = history;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading price history: {ex.Message}");
                MessageBox.Show(
                    "Could not load price history. Showing estimated data.",
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        /// <summary>
        /// Formats large numbers into readable format (e.g., $895B, $28.4B)
        /// </summary>
        private string FormatLargeNumber(decimal number)
        {
            if (number >= 1_000_000_000) // Billions
            {
                return $"${number / 1_000_000_000:N1}B";
            }
            else if (number >= 1_000_000) // Millions
            {
                return $"${number / 1_000_000:N1}M";
            }
            else if (number >= 1_000) // Thousands
            {
                return $"${number / 1_000:N1}K";
            }
            else
            {
                return $"${number:N2}";
            }
        }

        // Event Handlers
        private void BtnAddToPortfolio_Click(object sender, EventArgs e)
        {
            if (cmbCoins.SelectedItem == null) return;

            var selectedItem = cmbCoins.SelectedItem as CoinComboItem;
            if (selectedItem == null) return;

            var result = MessageBox.Show(
                $"This will open the Transactions screen where you can add {selectedItem.Coin.Name} to your portfolio.\n\nContinue?",
                "Add to Portfolio",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Navigate to transactions form
                NavigateToTransactions();
            }
        }

        // Navigation handlers
        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            NavigateToDashboard();
        }

        private void BtnTransactions_Click(object sender, EventArgs e)
        {
            NavigateToTransactions();
        }

        private void BtnTrending_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trending screen - Bonus/split work",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            HighlightButton(btnTrending);
        }

        private void NavigateToDashboard()
        {
            try
            {
                var dashboardForm = Application.OpenForms.OfType<DashboardForm>().FirstOrDefault();

                if (dashboardForm != null)
                {
                    dashboardForm.Show();
                    dashboardForm.BringToFront();
                }
                else
                {
                    // Create new dashboard if not found
                    var newDashboard = new DashboardForm();
                    newDashboard.Show();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to dashboard: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NavigateToTransactions()
        {
            try
            {
                var transactionsForm = Application.OpenForms.OfType<TransactionsForm>().FirstOrDefault();

                if (transactionsForm != null)
                {
                    transactionsForm.Show();
                    transactionsForm.BringToFront();
                }
                else
                {
                    // Create new transactions form with shared services
                    var newTransactions = new TransactionsForm(_transactionService, _cryptoService);
                    newTransactions.Show();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to transactions: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HighlightButton(Button activeButton)
        {
            // Reset all navigation buttons
            foreach (Control control in panelTopNav.Controls)
            {
                if (control is Button btn)
                {
                    btn.BackColor = Color.FromArgb(45, 45, 48);
                    btn.ForeColor = Color.White;
                }
            }

            // Highlight active button
            activeButton.BackColor = Color.DodgerBlue;
            activeButton.ForeColor = Color.White;
        }

        // Not used but keeping for compatibility
        private void label1_Click(object sender, EventArgs e)
        {
            // Empty - legacy code
        }

        private void HighlightNav()
        {
            // Use HighlightButton instead
            HighlightButton(btnCoinDetails);
        }
    }

    /// <summary>
    /// Helper class for ComboBox items
    /// Allows us to display "Bitcoin (BTC)" but access the full Coin object
    /// </summary>
    public class CoinComboItem
    {
        public Coin Coin { get; set; }

        public CoinComboItem(Coin coin)
        {
            Coin = coin;
        }

        public override string ToString()
        {
            return $"{Coin.Name} ({Coin.Symbol})";
        }
    }
}