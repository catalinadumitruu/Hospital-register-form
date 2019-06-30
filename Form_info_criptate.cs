using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_paw_spital
{
    public partial class Form_info_criptate : Form
    {
        public Form_info_criptate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            Informatii_criptate_in_binar.Font = fontDialog1.Font;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Fisier binar(*.dat)|*.dat";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                FileStream fileStream = new FileStream(openFile.FileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();

                List<string> lista = (List<string>)bf.Deserialize(fileStream);
                string str;

                for (int i = 0; i < lista.Count; i++)
                {
                    str = lista[i];

                    Informatii_criptate_in_binar.Items.Add(str);
                }
                fileStream.Close();
            }
        }
    }
}
