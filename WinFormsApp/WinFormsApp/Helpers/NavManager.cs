using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp.Helpers
{
    public static class NavManager
    {

        /// Resets all buttons and highlights the active one
        public static void HighlightButton(Button activeButton, Panel navPanel)
        {
            foreach (Control control in navPanel.Controls)
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


        /// Optional: Set default state for navigation buttons on form load
        public static void SetDefaultNavState(Button dashboard, Button coinDetails, Button transactions, Button trending)
        {
            dashboard.BackColor = Color.DodgerBlue;
            dashboard.ForeColor = Color.White;

            coinDetails.BackColor = Color.FromArgb(45, 45, 48);
            coinDetails.ForeColor = Color.White;

            transactions.BackColor = Color.FromArgb(45, 45, 48);
            transactions.ForeColor = Color.White;

            trending.BackColor = Color.FromArgb(45, 45, 48);
            trending.ForeColor = Color.White;
        }
    }
}
