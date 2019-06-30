namespace Proiect_paw_spital
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
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pacientiBTN = new System.Windows.Forms.Button();
            this.mediciBTN = new System.Windows.Forms.Button();
            this.reteteBTN = new System.Windows.Forms.Button();
            this.departamenteBTN = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Goldenrod;
            this.label1.Location = new System.Drawing.Point(21, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "<>  Selecteaza activitatea dorita <>";
            // 
            // pacientiBTN
            // 
            this.pacientiBTN.BackColor = System.Drawing.Color.Goldenrod;
            this.pacientiBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pacientiBTN.Location = new System.Drawing.Point(42, 164);
            this.pacientiBTN.Name = "pacientiBTN";
            this.pacientiBTN.Size = new System.Drawing.Size(156, 77);
            this.pacientiBTN.TabIndex = 2;
            this.pacientiBTN.Text = "Deschide formular pacienti";
            this.pacientiBTN.UseVisualStyleBackColor = false;
            this.pacientiBTN.Click += new System.EventHandler(this.pacientiBTN_Click);
            // 
            // mediciBTN
            // 
            this.mediciBTN.BackColor = System.Drawing.Color.Goldenrod;
            this.mediciBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.mediciBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mediciBTN.Location = new System.Drawing.Point(278, 164);
            this.mediciBTN.Name = "mediciBTN";
            this.mediciBTN.Size = new System.Drawing.Size(145, 78);
            this.mediciBTN.TabIndex = 3;
            this.mediciBTN.Text = "Deschide formular meidici";
            this.mediciBTN.UseVisualStyleBackColor = false;
            this.mediciBTN.Click += new System.EventHandler(this.mediciBTN_Click);
            // 
            // reteteBTN
            // 
            this.reteteBTN.BackColor = System.Drawing.Color.Goldenrod;
            this.reteteBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.reteteBTN.Location = new System.Drawing.Point(506, 164);
            this.reteteBTN.Name = "reteteBTN";
            this.reteteBTN.Size = new System.Drawing.Size(149, 78);
            this.reteteBTN.TabIndex = 4;
            this.reteteBTN.Text = "Deschide formular retete";
            this.reteteBTN.UseVisualStyleBackColor = false;
            this.reteteBTN.Click += new System.EventHandler(this.reteteBTN_Click);
            // 
            // departamenteBTN
            // 
            this.departamenteBTN.BackColor = System.Drawing.Color.Goldenrod;
            this.departamenteBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.departamenteBTN.Location = new System.Drawing.Point(750, 164);
            this.departamenteBTN.Name = "departamenteBTN";
            this.departamenteBTN.Size = new System.Drawing.Size(141, 78);
            this.departamenteBTN.TabIndex = 5;
            this.departamenteBTN.Text = "Deschide formular departamente";
            this.departamenteBTN.UseVisualStyleBackColor = false;
            this.departamenteBTN.Click += new System.EventHandler(this.departamenteBTN_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1082, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.eXITToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.eXITToolStripMenuItem.MergeIndex = 0;
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.eXITToolStripMenuItem.Text = "EXIT";
            this.eXITToolStripMenuItem.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1082, 467);
            this.Controls.Add(this.departamenteBTN);
            this.Controls.Add(this.reteteBTN);
            this.Controls.Add(this.mediciBTN);
            this.Controls.Add(this.pacientiBTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pacientiBTN;
        private System.Windows.Forms.Button mediciBTN;
        private System.Windows.Forms.Button reteteBTN;
        private System.Windows.Forms.Button departamenteBTN;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
    }
}

