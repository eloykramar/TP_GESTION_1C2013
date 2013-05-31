using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus
{
    public partial class Alta_Rol : Form1
    {
        private List<String> funcionesAgregadas;
        private int cantidadFunc;

        public Alta_Rol()
        {
            InitializeComponent();
            listBox1.Items.Add("Funcion1");
            listBox1.Items.Add("Funcion2");
            listBox1.Items.Add("Funcion3");
            this.funcionesAgregadas = new List<string>();
            this.cantidadFunc = 0;
        }

        // Boton previsualizar
        private void button4_Click_1(object sender, EventArgs e)
        {
            MostrarRol previsualizarRol = new MostrarRol(textBox1.Text,this.funcionesAgregadas);
            previsualizarRol.Text = "Guardaras el siguiente rol";
            previsualizarRol.Show();
        }

        // Boton agregar funcionalidad
        private void button1_Click(object sender, EventArgs e)
        {
            this.funcionesAgregadas.Add(listBox1.Text);
            this.cantidadFunc++;
            label1.Text = this.cantidadFunc.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MostrarRol previsualizarRol = new MostrarRol(textBox1.Text, this.funcionesAgregadas);
            previsualizarRol.Text = "Guardaras el siguiente rol";
            previsualizarRol.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            textBox1.Text = "";
            this.funcionesAgregadas = new List<string>();
            this.cantidadFunc = 0;
        }

        
        


    }
}
