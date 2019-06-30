namespace Proiect_paw_spital
{
    partial class Form_info_criptate
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
            this.Informatii_criptate_in_binar = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Informatii_criptate_in_binar
            // 
            this.Informatii_criptate_in_binar.BackColor = System.Drawing.Color.Goldenrod;
            this.Informatii_criptate_in_binar.FormattingEnabled = true;
            this.Informatii_criptate_in_binar.ItemHeight = 16;
            this.Informatii_criptate_in_binar.Location = new System.Drawing.Point(112, 67);
            this.Informatii_criptate_in_binar.Name = "Informatii_criptate_in_binar";
            this.Informatii_criptate_in_binar.ScrollAlwaysVisible = true;
            this.Informatii_criptate_in_binar.Size = new System.Drawing.Size(559, 228);
            this.Informatii_criptate_in_binar.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Goldenrod;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(284, 389);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Alege font";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Goldenrod;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(284, 335);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Incarca date";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form_info_criptate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Informatii_criptate_in_binar);
            this.Name = "Form_info_criptate";
            this.Text = "Form_info_criptate";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Informatii_criptate_in_binar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button button2;
    }
}