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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //// Method to create the payment receipt 
        //public string GetReceipt()
        //{
        //    // Initialize the variables for total proice and the recipt string
        //    double totalPrice = 0.0;
        //    string receipt = "Student Restaurant \n\nYour Order Details: \n\n";

        //    // Process each selected food item and calculate the total price
        //    foreach (int items in menuItems.SelectedIndices)
        //    {
        //        // Concatenate the selected food items and their price.
        //        receipt = receipt + menuItems.Items[items].ToString() + " : $" + Convert.ToDouble(pricelist.Items[items].ToString()) + "\n";

        //        // Calculate the total price
        //        totalPrice += Convert.ToDouble(pricelist.Items[items].ToString());

        //    }
        //    // Add the total price to the Receipt
        //    receipt = receipt + "\nTotal Price :$" + totalPrice.ToString();

        //    // Return receipt
        //    return receipt;
        //}

        //private void groupBox1_Enter(object sender, EventArgs e)
        //{

        //}

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        //private void button2_Click(object sender, EventArgs e)
        //{
        //    // Call the GetReceipt() method and display the recipt in a Label
        //    string receipt = GetReceipt();

        //    // Show the receipt string in a Label in the Receipt Groupbox
        //    receiptText.Text = receipt;

        //}

        //private void menuItems_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
