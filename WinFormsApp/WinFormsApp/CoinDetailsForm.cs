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
    public partial class CoinDetailsForm : Form
    {
        public CoinDetailsForm()
        {
            InitializeComponent();
            HighlightButton(btnCoinDetails);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void HighlightNav()
        {
            btnDashboard.BackColor = Color.FromArgb(45, 45, 48);
            btnDashboard.ForeColor = Color.White;
            btnCoinDetails.BackColor = Color.DodgerBlue; // this is the current page
            btnCoinDetails.ForeColor = Color.White;
            btnTransactions.BackColor = Color.FromArgb(45, 45, 48);
            btnTransactions.ForeColor = Color.White;
            btnTrending.BackColor = Color.FromArgb(45, 45, 48);
            btnTrending.ForeColor = Color.White;
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (!this.GetType().Name.Equals("DashboardForm"))
            {
                var form = new DashboardForm();
                form.Show();
                this.Close();
            }
        }

        //private void btnCoinDetails_Click(object sender, EventArgs e)
        //{
        //    // do nothing - already on this page!
        //}

        //private void btnTransactions_Click(object sender, EventArgs e)
        //{
        //    if (!this.GetType().Name.Equals("TransactionsForm"))
        //    {
        //        var form = new TransactionsForm();
        //        form.Show();
        //        this.Close();
        //    }
        //}

        //private void btnTrending_Click(object sender, EventArgs e)
        //{
        //    if (!this.GetType().Name.Equals("TrendingForm"))
        //    {
        //        var form = new TrendingForm();
        //        form.Show();
        //        this.Close();
        //    }
        //}

    }


}
