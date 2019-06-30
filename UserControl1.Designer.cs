namespace Proiect_paw_spital
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_proiect_spital = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.User_proiect = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.user_controler = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_proiect_spital
            // 
            this.label_proiect_spital.AutoSize = true;
            this.label_proiect_spital.Location = new System.Drawing.Point(89, 145);
            this.label_proiect_spital.Name = "label_proiect_spital";
            this.label_proiect_spital.Size = new System.Drawing.Size(0, 17);
            this.label_proiect_spital.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // user_controler
            // 
            this.user_controler.AutoSize = true;
            this.user_controler.Location = new System.Drawing.Point(135, 172);
            this.user_controler.Name = "user_controler";
            this.user_controler.Size = new System.Drawing.Size(145, 17);
            this.user_controler.TabIndex = 1;
            this.user_controler.Text = "User Controler Folosit";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.user_controler);
            this.Controls.Add(this.label_proiect_spital);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(519, 361);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_proiect_spital;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker User_proiect;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label user_controler;
    }
}
