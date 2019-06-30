using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_paw_spital
{
    public partial class Form_imprimare : Form
    {
        private Font printFont;
        private PrintPreviewDialog printPreviewDialog1;
        public PrintDocument pd;
        StreamReader streamToPrint = null;

        public Form_imprimare()
        {
            InitializeComponent();
            this.printPreviewDialog1 = new PrintPreviewDialog();
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void incarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                streamToPrint = new StreamReader("E:\\Facultate\\Anul II\\Semestrul 2\\PAW\\Proiect\\Proiect_paw_spital\\bin\\Debug\\raport.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            string linie_txt;
            while ((linie_txt = streamToPrint.ReadLine()) != null)
            {
                textBox1.Text += linie_txt + "\r\n";
            }
            streamToPrint.Close();
        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pd = new PrintDocument();
            printFont = new Font("Arial", 16);
            try
            {
                streamToPrint = new StreamReader("E:\\Facultate\\Anul II\\Semestrul 2\\PAW\\Proiect\\Proiect_paw_spital\\bin\\Debug\\raport.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            this.pd.PrintPage += new PrintPageEventHandler(this.PrintPage);
            printPreviewDialog1.Document = pd;
            printPreviewDialog1.ShowDialog();
            streamToPrint.Close();
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            String linie_txt = "Text de scris in document";
            SolidBrush pns = new SolidBrush(Color.Black);
            float x = 250.0F;
            float y = 250.0F;
         
           ev.Graphics.DrawString(linie_txt, printFont, pns, x, y);
            ev.HasMorePages = true;
            float linesPerPage = 0;
            float yPos = 0;
            int count = 10;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            linie_txt = null;

            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
            while (count < linesPerPage && ((linie_txt = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(linie_txt, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }

            if (linie_txt != null)
                ev.HasMorePages = true;
            else ev.HasMorePages = false;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                streamToPrint = new StreamReader("E:\\Facultate\\Anul II\\Semestrul 2\\PAW\\Proiect\\Proiect_paw_spital\\bin\\Debug\\raport.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            try
            {
                printFont = new Font("Ariel", 12);
                pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(this.PrintPage);
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            streamToPrint.Close();
        }
    }
}
