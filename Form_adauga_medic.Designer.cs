namespace Proiect_paw_spital
{
    partial class Form_adauga_medic
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
            this.numeTXT = new System.Windows.Forms.TextBox();
            this.varstTXT = new System.Windows.Forms.TextBox();
            this.oreTXT = new System.Windows.Forms.TextBox();
            this.salariulTXT = new System.Windows.Forms.TextBox();
            this.departamentTXT = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Goldenrod;
            this.label1.Location = new System.Drawing.Point(152, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Goldenrod;
            this.label2.Location = new System.Drawing.Point(152, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Varsta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Goldenrod;
            this.label3.Location = new System.Drawing.Point(152, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ore lucrate/ saptamana";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Goldenrod;
            this.label4.Location = new System.Drawing.Point(152, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Salariul";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Goldenrod;
            this.label5.Location = new System.Drawing.Point(152, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Departament";
            // 
            // numeTXT
            // 
            this.numeTXT.Location = new System.Drawing.Point(322, 43);
            this.numeTXT.Name = "numeTXT";
            this.numeTXT.Size = new System.Drawing.Size(137, 22);
            this.numeTXT.TabIndex = 7;
            this.numeTXT.Validating += new System.ComponentModel.CancelEventHandler(this.numeTXT_Validating);
            // 
            // varstTXT
            // 
            this.varstTXT.Location = new System.Drawing.Point(322, 86);
            this.varstTXT.Name = "varstTXT";
            this.varstTXT.Size = new System.Drawing.Size(137, 22);
            this.varstTXT.TabIndex = 8;
            // 
            // oreTXT
            // 
            this.oreTXT.Location = new System.Drawing.Point(322, 129);
            this.oreTXT.Name = "oreTXT";
            this.oreTXT.Size = new System.Drawing.Size(137, 22);
            this.oreTXT.TabIndex = 9;
            // 
            // salariulTXT
            // 
            this.salariulTXT.Location = new System.Drawing.Point(322, 172);
            this.salariulTXT.Name = "salariulTXT";
            this.salariulTXT.Size = new System.Drawing.Size(137, 22);
            this.salariulTXT.TabIndex = 10;
            this.salariulTXT.Validating += new System.ComponentModel.CancelEventHandler(this.salariulTXT_Validating);
            // 
            // departamentTXT
            // 
            this.departamentTXT.Location = new System.Drawing.Point(322, 215);
            this.departamentTXT.Name = "departamentTXT";
            this.departamentTXT.Size = new System.Drawing.Size(137, 22);
            this.departamentTXT.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Goldenrod;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(182, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 35);
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
            this.button2.Location = new System.Drawing.Point(322, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 35);
            this.button2.TabIndex = 13;
            this.button2.Text = "Renunta";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form_adauga_medic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.departamentTXT);
            this.Controls.Add(this.salariulTXT);
            this.Controls.Add(this.oreTXT);
            this.Controls.Add(this.varstTXT);
            this.Controls.Add(this.numeTXT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_adauga_medic";
            this.Text = "Form_adauga_medic";
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
        private System.Windows.Forms.TextBox numeTXT;
        private System.Windows.Forms.TextBox varstTXT;
        private System.Windows.Forms.TextBox oreTXT;
        private System.Windows.Forms.TextBox salariulTXT;
        private System.Windows.Forms.TextBox departamentTXT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}