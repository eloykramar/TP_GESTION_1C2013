using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Recorrido
{
    public partial class VisualizarRecorrido : Form1
    {
        public VisualizarRecorrido( String Origen,
                                    String Destino, 
                                    String Servicio, 
                                    decimal basePasaje, 
                                    decimal baseXKg)
        {
            InitializeComponent();

            listBox1.Height = listBox1.ItemHeight * 6;

            listBox1.Items.Add(Origen);
            listBox1.Items.Add(Destino);
            listBox1.Items.Add(Servicio);
            listBox1.Items.Add(basePasaje);
            listBox1.Items.Add(baseXKg);

            listBox2.Height = listBox1.ItemHeight * 6;
            
            listBox2.Items.Add("Origen");
            listBox2.Items.Add("Destino");
            listBox2.Items.Add("Servicio");
            listBox2.Items.Add("Base Pasaje");
            listBox2.Items.Add("Base por kilo");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
