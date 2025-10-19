using System.Windows.Forms.DataVisualization.Charting;
namespace WinFormsApp
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            btnCoinDetails = new Button();
            btnDashboard = new Button();
            bindingSource1 = new BindingSource(components);
            dgvPortfolio = new DataGridView();
            label1 = new Label();
            statusStrip1 = new StatusStrip();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPortfolio).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnCoinDetails);
            panel1.Controls.Add(btnDashboard);
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(4, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1025, 76);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10F);
            button2.ForeColor = Color.White;
            button2.Location = new Point(766, 13);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(219, 59);
            button2.TabIndex = 7;
            button2.Text = "Trending ";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(508, 13);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(221, 59);
            button1.TabIndex = 6;
            button1.Text = "Transactions ";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnCoinDetails
            // 
            btnCoinDetails.FlatStyle = FlatStyle.Flat;
            btnCoinDetails.Font = new Font("Segoe UI", 10F);
            btnCoinDetails.ForeColor = Color.White;
            btnCoinDetails.Location = new Point(256, 13);
            btnCoinDetails.Margin = new Padding(3, 4, 3, 4);
            btnCoinDetails.Name = "btnCoinDetails";
            btnCoinDetails.Size = new Size(194, 59);
            btnCoinDetails.TabIndex = 5;
            btnCoinDetails.Text = "Coin Details";
            btnCoinDetails.UseVisualStyleBackColor = true;
            btnCoinDetails.Click += btnCoinDetails_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10F);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(12, 13);
            btnDashboard.Margin = new Padding(3, 4, 3, 4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(208, 59);
            btnDashboard.TabIndex = 4;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // dgvPortfolio
            // 
            dgvPortfolio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPortfolio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPortfolio.Location = new Point(-13, 210);
            dgvPortfolio.Margin = new Padding(3, 4, 3, 4);
            dgvPortfolio.Name = "dgvPortfolio";
            dgvPortfolio.RowHeadersWidth = 51;
            dgvPortfolio.Size = new Size(1042, 416);
            dgvPortfolio.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(80, 123);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 14;
            label1.Text = "label1";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 604);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1029, 24);
            statusStrip1.TabIndex = 15;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.ItemClicked += statusStrip1_ItemClicked;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 628);
            Controls.Add(statusStrip1);
            Controls.Add(label1);
            Controls.Add(dgvPortfolio);
            Controls.Add(panel1);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPortfolio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panel1;
        private BindingSource bindingSource1;
        private Button btnDashboard;
        private Button button2;
        private Button button1;
        private Button btnCoinDetails;
        private DataGridView dgvPortfolio;
        private Label label1;
        private StatusStrip statusStrip1;
    }
}