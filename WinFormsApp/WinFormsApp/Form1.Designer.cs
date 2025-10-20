namespace WinFormsApp
{
    partial class Form1
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
        private void InitialiseComponent()
        {
            exit = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // exit
            // 
            exit.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            exit.Location = new Point(230, 399);
            exit.Margin = new Padding(4, 3, 4, 3);
            exit.Name = "exit";
            exit.Size = new Size(133, 45);
            exit.TabIndex = 16;
            exit.Text = "Exit";
            exit.UseVisualStyleBackColor = true;
            exit.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(224, 21);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(186, 29);
            label1.TabIndex = 19;
            label1.Text = "Crypto Tracker";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 463);
            Controls.Add(label1);
            Controls.Add(exit);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Crypto Tracker";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label label1;
    }
}

