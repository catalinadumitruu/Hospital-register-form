using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_paw_spital
{
    public partial class Form_raport_medici : Form
    {
        int nrObs = 1;
        string Provider;
        List<double> salarii = new List<double>();
        List<string> numeMedici = new List<string>();

        public Form_raport_medici()
        {
            InitializeComponent();
            Provider = "Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = proiect_spital2.accdb";

            OleDbConnection conexiune = new OleDbConnection(Provider);
            OleDbCommand comanda = new OleDbCommand();
            comanda.Connection = conexiune;

            try
            {
                conexiune.Open();

                comanda.CommandText = "SELECT count(id_medic) FROM medici";
                nrObs = Convert.ToInt32(comanda.ExecuteScalar());
               
                comanda.CommandText = "SELECT nume, salariul FROM medici";
                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    numeMedici.Add(reader["nume"].ToString());
                    salarii.Add(Convert.ToDouble(reader["salariul"]));
                }
               
            }catch(OleDbException ex)
            {
                MessageBox.Show(ex.Message);
                comanda.Transaction.Rollback();
            }
            finally
            {
                conexiune.Close();
            }
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle zonaClient = e.ClipRectangle;
           
            Brush fundal = new SolidBrush(Color.Goldenrod);
            g.FillRectangle(fundal, zonaClient);
          
            zonaClient.X += 20;
            zonaClient.Y += 20;

            zonaClient.Height -= 40;
            zonaClient.Width -= 40;

            int left = zonaClient.Left;
            int bottom = zonaClient.Bottom;
            int right = zonaClient.Right;
            int top = zonaClient.Top;

            Pen chenar = new Pen(Color.DarkSlateGray, 3);
            g.DrawRectangle(chenar, zonaClient);

            SolidBrush pensula = new SolidBrush(Color.DarkSlateGray);

            Pen creion = new Pen(Color.IndianRed);

            double raport_distanta_latime = 3;
            double max;
            int latime = (right - left) / (int)((nrObs + 1) * raport_distanta_latime + nrObs);
            int distanta_2_dreptunghiuri = (int)(latime * raport_distanta_latime);

            int i;
            //for(max = salarii[0], i = 1; i < nrObs; i++)
            //{
            //    if(max < salarii[i])
            //    {
            //        max = salarii[i];
            //    }
            //}
            max = 15000;    
            g.DrawLine(creion, left,top, left, bottom);
            g.DrawLine(creion, left, bottom, right, bottom);

            for (i = 0; i < nrObs; i++)
            {
                PointF pnt = new PointF(left + distanta_2_dreptunghiuri + i * (latime + distanta_2_dreptunghiuri),bottom - (float)salarii[i] * (bottom - top) / (float)max);
                SizeF sz = new SizeF(latime, ((float)salarii[i] * (bottom - top)) /(float)max);
             
                g.FillRectangle(pensula, new RectangleF(pnt, sz));
                string denx = "" + numeMedici[i];
                //punem denumirea sub el
                g.DrawString(denx, Font, pensula, left + distanta_2_dreptunghiuri + latime / 2 + i * (latime + distanta_2_dreptunghiuri), bottom + 5);

            }
        }
    }
}
