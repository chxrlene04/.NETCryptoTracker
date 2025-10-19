using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Services;
using System.Windows.Forms.DataVisualization.Charting;


namespace WinFormsApp
{
    public partial class Form3 : Form
    {

        private readonly CoinGeckoApiService _coinGeckoService; // instantied unmodifiable object 

        public Form3(CoinGeckoApiService coinGeckoService)
        {
            InitializeComponent();
            _coinGeckoService = coinGeckoService; // instatiation in constuctor 
        }

        private void button1_Click(object sender, EventArgs e) // Transaction ONclick nav 
        {

            TransactionService transactionService = new TransactionService();
            CryptoService cryptoService = new CryptoService();
            TransactionsForm transform = new TransactionsForm(transactionService, cryptoService);
            transform.Show();
            this.Hide();


        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            await LoadTrendingCoinsAsync();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            DashboardForm dashboard = new DashboardForm();
            dashboard.Show();
            this.Hide();

        }

        private void btnCoinDetails_Click(object sender, EventArgs e)
        {

            CryptoService coinservice = new CryptoService();
            TransactionService transactionService = new TransactionService();
            CoinDetailsForm coindets = new CoinDetailsForm(coinservice, transactionService);
            coindets.Show();
            this.Hide();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }




        private async Task LoadTrendingCoinsAsync()
        {
            try
            {
                // Show loading text
                statusStrip1.Text = "Loading trending coins...";

                // Fetch data
                var trendingCoins = await _coinGeckoService.GetAllTrendingCoinsAsync();

                // Bind to DataGridView or ListView
                dgvPortfolio.DataSource = trendingCoins;

                // Optionally: Customize columns
                dgvPortfolio.Columns["Name"].HeaderText = "Coin Name";
                dgvPortfolio.Columns["Symbol"].HeaderText = "Symbol";
                dgvPortfolio.Columns["MarketCapRank"].HeaderText = "Rank";
                dgvPortfolio.Columns["CurrentPrice"].HeaderText = "Price (USD)";

                // Done
                statusStrip1.Text = $"Loaded {trendingCoins.Count} trending coins.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading trending coins: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusStrip1.Text = "Failed to load trending coins.";
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
