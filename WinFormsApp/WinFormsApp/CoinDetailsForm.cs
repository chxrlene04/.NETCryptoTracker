using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Helpers;
using WinFormsApp.Services;
using WinFormsApp.Models;


namespace WinFormsApp
{
    public partial class CoinDetailsForm : Form
    {
        private CryptoService _cryptoService;    // Service for coin data (dummy for now)
        private Dictionary<string, List<PriceHistoryItem>> _dummyHistory; // Dummy price history


        public CoinDetailsForm()
        {
            InitializeComponent();
            NavManager.HighlightButton(btnCoinDetails, panelTopNav);
            // Initialise our services and dummy data
            _cryptoService = new CryptoService();
            SetupDummyPriceHistory();

            // Populate the coin ComboBox
            LoadCoins();

            // Set up selection change handler for ComboBox
            cmbCoins.SelectedIndexChanged += cmbCoins_SelectedIndexChanged;
        }



        //private void label1_Click(object sender, EventArgs e)
        //{

        //}


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            NavManager.HighlightButton(btnDashboard, panelTopNav);

            if (!this.GetType().Name.Equals("DashboardForm"))
            {
                var form = new DashboardForm();
                form.Show();
            }
        }
        private void btnCoinDetails_Click(object sender, EventArgs e)
        {
            // Already on this page
            NavManager.HighlightButton(btnCoinDetails, panelTopNav);
        }

        private void btnTransactions_Click(object sender, EventArgs e) => NavManager.HighlightButton(btnTransactions, panelTopNav);

        private void btnTrending_Click(object sender, EventArgs e) => NavManager.HighlightButton(btnTrending, panelTopNav);



        // Step 1: Populate the ComboBox with dummy data
        private void LoadCoins()
        {
            var coins = _cryptoService.GetAllCoins();
            cmbCoins.DataSource = coins;
            cmbCoins.DisplayMember = "Name";      // Show coin names
            cmbCoins.ValueMember = "Symbol";      // Value is the symbol/code
            if (coins.Count > 0)
                cmbCoins.SelectedIndex = 0;       // Select first coin by default
        }


        // Step 2: When user changes coin, update display
        private void cmbCoins_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCoin = cmbCoins.SelectedItem as Coin;
            if (selectedCoin == null) return;

            // Update current info labels
            lblPrice.Text = $"${selectedCoin.CurrentPrice:N2}";
            lblChange24h.Text = $"{selectedCoin.Change24h:+0.##%;-0.##%}";
            lblChange24h.ForeColor = selectedCoin.Change24h >= 0 ? Color.Green : Color.Red;
            lblMarketCap.Text = $"${selectedCoin.MarketCap}B";
            lblVolume.Text = $"${selectedCoin.Volume}B";

            // Step 3: Show dummy 7-day price history for this coin
            if (_dummyHistory.TryGetValue(selectedCoin.Symbol, out var history))
            {
                dgvPriceHistory.DataSource = history;
            }
            else
            {
                dgvPriceHistory.DataSource = null;
            }
            // Optional: Format DataGridView columns for currency/percent, set column widths
        }

        // Setup dummy price history for coins (swap for API later if needed)
        private void SetupDummyPriceHistory()
        {
            // Create a dictionary mapping each symbol to 7 price history items
            _dummyHistory = new Dictionary<string, List<PriceHistoryItem>>();

            // Example for BTC, ETH; add more as needed
            _dummyHistory["BTC"] = new List<PriceHistoryItem>
            {
                new PriceHistoryItem("2025-10-01", 44800, 46120, 44650, 45621, 1.8m),
                new PriceHistoryItem("2025-09-30", 45200, 45890, 44400, 44800, -0.9m),
                new PriceHistoryItem("2025-09-29", 44600, 45450, 44320, 45200, 1.3m),
                new PriceHistoryItem("2025-09-28", 43900, 44780, 43750, 44600, 1.6m),
                new PriceHistoryItem("2025-09-27", 43200, 44100, 43050, 43900, 1.6m),
                new PriceHistoryItem("2025-09-26", 44200, 45000, 43400, 43200, -2.3m),
                new PriceHistoryItem("2025-09-25", 44500, 44800, 44000, 44200, -0.2m)
            };
            _dummyHistory["ETH"] = new List<PriceHistoryItem>
            {
                new PriceHistoryItem("2025-10-01", 2615, 2680, 2595, 2629, 2.9m),
                new PriceHistoryItem("2025-09-30", 2640, 2655, 2580, 2615, -0.5m),
                new PriceHistoryItem("2025-09-29", 2587, 2642, 2574, 2640, 1.4m),
                new PriceHistoryItem("2025-09-28", 2535, 2595, 2510, 2587, 1.5m),
                new PriceHistoryItem("2025-09-27", 2505, 2540, 2450, 2535, 1.2m),
                new PriceHistoryItem("2025-09-26", 2470, 2510, 2460, 2505, -1.1m),
                new PriceHistoryItem("2025-09-25", 2510, 2530, 2400, 2470, 0.4m)
            };
            // ... Add for other symbols (ADA, SOL, etc) if needed
        }


        // Nested class for DataGridView price history rows
        private class PriceHistoryItem
        {
            public string Date { get; set; }
            public decimal Open { get; set; }
            public decimal High { get; set; }
            public decimal Low { get; set; }
            public decimal Close { get; set; }
            public decimal Change { get; set; }

            public PriceHistoryItem(string date, decimal open, decimal high, decimal low, decimal close, decimal change)
            {
                Date = date;
                Open = open;
                High = high;
                Low = low;
                Close = close;
                Change = change;
            }
        }

    }



}
