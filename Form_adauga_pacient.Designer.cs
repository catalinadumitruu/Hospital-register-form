namespace Proiect_paw_spital
{
    partial class Form_adauga_pacient
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numeTXT = new System.Windows.Forms.TextBox();
            this.varstaTXT = new System.Windows.Forms.TextBox();
            this.boalaTXT = new System.Windows.Forms.TextBox();
            this.grupaSangeTXT = new System.Windows.Forms.TextBox();
            this.alergiiTXT = new System.Windows.Forms.TextBox();
            this.cnpTXT = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.medicTXT = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Goldenrod;
            this.label1.Location = new System.Drawing.Point(146, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Goldenrod;
            this.label2.Location = new System.Drawing.Point(146, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Varsta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Goldenrod;
            this.label3.Location = new System.Drawing.Point(146, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Diagnostic";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Goldenrod;
            this.label4.Location = new System.Drawing.Point(146, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Grupa sange";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Goldenrod;
            this.label5.Location = new System.Drawing.Point(146, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Alergii";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Goldenrod;
            this.label6.Location = new System.Drawing.Point(146, 316);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "CNP";
            // 
            // numeTXT
            // 
            this.numeTXT.Location = new System.Drawing.Point(282, 101);
            this.numeTXT.Name = "numeTXT";
            this.numeTXT.Size = new System.Drawing.Size(183, 22);
            this.numeTXT.TabIndex = 6;
            this.numeTXT.Validating += new System.ComponentModel.CancelEventHandler(this.numeTXT_Validating);
            // 
            // varstaTXT
            // 
            this.varstaTXT.Location = new System.Drawing.Point(282, 143);
            this.varstaTXT.Name = "varstaTXT";
            this.varstaTXT.Size = new System.Drawing.Size(183, 22);
            this.varstaTXT.TabIndex = 7;
            this.varstaTXT.Validating += new System.ComponentModel.CancelEventHandler(this.varstaTXT_Validating);
            // 
            // boalaTXT
            // 
            this.boalaTXT.Location = new System.Drawing.Point(282, 190);
            this.boalaTXT.Name = "boalaTXT";
            this.boalaTXT.Size = new System.Drawing.Size(183, 22);
            this.boalaTXT.TabIndex = 8;
            this.boalaTXT.Validating += new System.ComponentModel.CancelEventHandler(this.boalaTXT_Validating);
            // 
            // grupaSangeTXT
            // 
            this.grupaSangeTXT.Location = new System.Drawing.Point(282, 232);
            this.grupaSangeTXT.Name = "grupaSangeTXT";
            this.grupaSangeTXT.Size = new System.Drawing.Size(183, 22);
            this.grupaSangeTXT.TabIndex = 9;
            this.grupaSangeTXT.Validating += new System.ComponentModel.CancelEventHandler(this.grupaSangeTXT_Validating);
            // 
            // alergiiTXT
            // 
            this.alergiiTXT.Location = new System.Drawing.Point(282, 274);
            this.alergiiTXT.Name = "alergiiTXT";
            this.alergiiTXT.Size = new System.Drawing.Size(183, 22);
            this.alergiiTXT.TabIndex = 10;
            // 
            // cnpTXT
            // 
            this.cnpTXT.Location = new System.Drawing.Point(282, 316);
            this.cnpTXT.Name = "cnpTXT";
            this.cnpTXT.Size = new System.Drawing.Size(183, 22);
            this.cnpTXT.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Goldenrod;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(107, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 45);
            this.button1.TabIndex = 12;
            this.button1.Text = "Adauga";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Goldenrod;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(310, 406);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 45);
            this.button2.TabIndex = 13;
            this.button2.Text = "Renunta";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Goldenrod;
            this.label7.Location = new System.Drawing.Point(136, 358);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Medic";
            // 
            // medicTXT
            // 
            this.medicTXT.Location = new System.Drawing.Point(282, 358);
            this.medicTXT.Name = "medicTXT";
            this.medicTXT.Size = new System.Drawing.Size(183, 22);
            this.medicTXT.TabIndex = 15;
            this.medicTXT.Validating += new System.ComponentModel.CancelEventHandler(this.medicTXT_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form_adauga_pacient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1080, 545);
            this.Controls.Add(this.medicTXT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cnpTXT);
            this.Controls.Add(this.alergiiTXT);
            this.Controls.Add(this.grupaSangeTXT);
            this.Controls.Add(this.boalaTXT);
            this.Controls.Add(this.varstaTXT);
            this.Controls.Add(this.numeTXT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_adauga_pacient";
            this.Text = "Form_adauga_pacient";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox numeTXT;
        private System.Windows.Forms.TextBox varstaTXT;
        private System.Windows.Forms.TextBox boalaTXT;
        private System.Windows.Forms.TextBox grupaSangeTXT;
        private System.Windows.Forms.TextBox alergiiTXT;
        private System.Windows.Forms.TextBox cnpTXT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox medicTXT;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}