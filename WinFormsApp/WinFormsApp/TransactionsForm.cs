// ============================================
// FILE: TransactionsForm.cs
// ============================================
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp.Models;
using WinFormsApp.Services;

namespace WinFormsApp
{
    public partial class TransactionsForm : Form
    {
        private readonly TransactionService _transactionService;
        private readonly CryptoService _cryptoService;
        private int _editingIndex = -1; // -1 means adding new, >= 0 means editing existing

        /// <summary>
        /// Constructor accepts shared service instances to maintain data consistency
        /// </summary>
        public TransactionsForm(TransactionService transactionService, CryptoService cryptoService)
        {
            InitializeComponent();

            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
            _cryptoService = cryptoService ?? throw new ArgumentNullException(nameof(cryptoService));

            SetupDataGridView();
            PopulateComboBoxes();
            LoadTransactions();
            WireUpEvents();
            HighlightButton(btnTransactions);
        }

        private void WireUpEvents()
        {
            // Navigation buttons
            btnDashboard.Click += BtnDashboard_Click;
            btnCoinDetails.Click += BtnCoinDetails_Click;
            btnTransactions.Click += (s, e) => HighlightButton(btnTransactions);
            btnTrending.Click += BtnTrending_Click;

            // Action buttons
            btnAddTransaction.Click += BtnAddTransaction_Click;
            btnEditSelected.Click += BtnEditSelected_Click;
            btnDeleteSelected.Click += BtnDeleteSelected_Click;
            btnSaveToFile.Click += BtnSaveToFile_Click;

            // Form buttons
            btnSave.Click += BtnSave_Click;
            btnClear.Click += BtnClear_Click;

            // Auto-calculate total value when amount or price changes
            txtAmount.TextChanged += CalculateTotalValue;
            txtPrice.TextChanged += CalculateTotalValue;
        }

        private void SetupDataGridView()
        {
            dgvTransactions.Columns.Clear();
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.ReadOnly = true;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "Date",
                Name = "Date",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Type",
                HeaderText = "Type",
                Name = "Type",
                Width = 80
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CoinSymbol",
                HeaderText = "Coin",
                Name = "Coin",
                Width = 100
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Amount",
                HeaderText = "Amount",
                Name = "Amount",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N4" }
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PricePerCoin",
                HeaderText = "Price",
                Name = "Price",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalValue",
                HeaderText = "Total",
                Name = "Total",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            // Color code Buy/Sell
            dgvTransactions.CellFormatting += DgvTransactions_CellFormatting;
        }

        private void DgvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTransactions.Columns[e.ColumnIndex].Name == "Type" && e.Value != null)
            {
                string type = e.Value.ToString();
                e.CellStyle.ForeColor = type == "Buy" ? Color.Green : Color.Red;
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }
        }

        private void PopulateComboBoxes()
        {
            // Populate transaction types from enum
            cmbTransactionType.Items.Clear();
            cmbTransactionType.Items.Add(TransactionType.Buy);
            cmbTransactionType.Items.Add(TransactionType.Sell);
            cmbTransactionType.SelectedIndex = 0;

            // Populate coins from CryptoService
            cmbCoin.Items.Clear();
            var coins = _cryptoService.GetTrendingCoins(); // Gets all coins
            foreach (var coin in coins)
            {
                cmbCoin.Items.Add($"{coin.Name} ({coin.Symbol})");
            }
            if (cmbCoin.Items.Count > 0)
                cmbCoin.SelectedIndex = 0;
        }

        private void LoadTransactions()
        {
            try
            {
                var transactions = _transactionService.GetAll()
                    .OrderByDescending(t => t.Date)
                    .ToList();

                dgvTransactions.DataSource = null;
                dgvTransactions.DataSource = transactions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transactions: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotalValue(object sender, EventArgs e)
        {
            // Auto-calculate and display total value
            if (decimal.TryParse(txtAmount.Text, out decimal amount) &&
                decimal.TryParse(txtPrice.Text, out decimal price))
            {
                decimal total = amount * price;
                lblTotalValue.Text = $"${total:N2}";
            }
            else
            {
                lblTotalValue.Text = "$0.00";
            }
        }

        private void BtnAddTransaction_Click(object sender, EventArgs e)
        {
            _editingIndex = -1;
            ClearForm();
            grpAddEdit.Text = "Add Transaction";
        }

        private void BtnEditSelected_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to edit.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _editingIndex = dgvTransactions.SelectedRows[0].Index;
                var transaction = _transactionService.GetAll()[_editingIndex];

                // Populate form with selected transaction
                cmbTransactionType.SelectedItem = transaction.Type;

                // Find and select the coin
                var coins = _cryptoService.GetTrendingCoins();
                var coin = coins.FirstOrDefault(c => c.Symbol == transaction.CoinSymbol);
                if (coin != null)
                {
                    cmbCoin.SelectedIndex = cmbCoin.FindStringExact($"{coin.Name} ({coin.Symbol})");
                }

                dtpDate.Value = transaction.Date;
                txtAmount.Text = transaction.Amount.ToString("F4");
                txtPrice.Text = transaction.PricePerCoin.ToString("F2");

                grpAddEdit.Text = "Edit Transaction";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transaction for edit: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to delete.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var index = dgvTransactions.SelectedRows[0].Index;
                var transaction = _transactionService.GetAll()[index];

                // Confirmation dialog
                var result = MessageBox.Show(
                    $"Are you sure you want to delete this transaction?\n\n" +
                    $"Date: {transaction.Date:yyyy-MM-dd}\n" +
                    $"Type: {transaction.Type}\n" +
                    $"Coin: {transaction.CoinSymbol}\n" +
                    $"Amount: {transaction.Amount:N4}\n" +
                    $"Total: {transaction.TotalValue:C2}",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    _transactionService.Delete(index);
                    LoadTransactions();
                    MessageBox.Show("Transaction deleted successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting transaction: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate all inputs
            if (!ValidateInputs())
                return;

            try
            {
                // Parse inputs
                var type = (TransactionType)cmbTransactionType.SelectedItem;
                var coinText = cmbCoin.SelectedItem.ToString();
                var symbol = coinText.Substring(coinText.LastIndexOf('(') + 1).TrimEnd(')');
                var date = dtpDate.Value;
                var amount = decimal.Parse(txtAmount.Text);
                var price = decimal.Parse(txtPrice.Text);

                var transaction = new Transaction(date, type, symbol, amount, price);

                if (_editingIndex >= 0)
                {
                    // Update existing transaction
                    _transactionService.Update(_editingIndex, transaction);
                    MessageBox.Show("Transaction updated successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Add new transaction
                    _transactionService.Add(transaction);
                    MessageBox.Show("Transaction added successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadTransactions();
                ClearForm();
                _editingIndex = -1;
                grpAddEdit.Text = "Add/Edit Transaction";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving transaction: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            // Check if transaction type is selected
            if (cmbTransactionType.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a transaction type.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTransactionType.Focus();
                return false;
            }

            // Check if coin is selected
            if (cmbCoin.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a cryptocurrency.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCoin.Focus();
                return false;
            }

            // Validate amount
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Please enter an amount.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for amount.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.SelectAll();
                txtAmount.Focus();
                return false;
            }

            // Validate price
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please enter a price.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for price.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.SelectAll();
                txtPrice.Focus();
                return false;
            }

            // Validate date is not in the future
            if (dtpDate.Value > DateTime.Now)
            {
                MessageBox.Show("Transaction date cannot be in the future.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDate.Focus();
                return false;
            }

            return true;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            _editingIndex = -1;
            grpAddEdit.Text = "Add/Edit Transaction";
        }

        private void ClearForm()
        {
            cmbTransactionType.SelectedIndex = 0;
            if (cmbCoin.Items.Count > 0)
                cmbCoin.SelectedIndex = 0;
            dtpDate.Value = DateTime.Now;
            txtAmount.Clear();
            txtPrice.Clear();
            lblTotalValue.Text = "$0.00";
        }

        private void BtnSaveToFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                    saveDialog.DefaultExt = "json";
                    saveDialog.FileName = $"transactions_{DateTime.Now:yyyyMMdd}.json";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        _transactionService.SaveToFile(saveDialog.FileName);
                        MessageBox.Show($"Transactions saved successfully to:\n{saveDialog.FileName}",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving to file: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Navigation handlers
        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            NavigateToDashboard();
        }

        private void BtnCoinDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coin Details screen - Person 2's responsibility",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            HighlightButton(btnCoinDetails);
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
                // Find existing dashboard form
                var dashboardForm = Application.OpenForms.OfType<DashboardForm>().FirstOrDefault();

                if (dashboardForm != null)
                {
                    // Call public refresh method if it exists
                    dashboardForm.Show();
                    dashboardForm.BringToFront();
                }

               // this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to dashboard: {ex.Message}",
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
    }
}