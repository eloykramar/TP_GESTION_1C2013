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
    public partial class MostrarRol : Form
    {
        public MostrarRol(String nombreRol,List<String> funciones)
        {
            InitializeComponent();
            label2.Text = nombreRol;

            foreach (String funcion in funciones)
            {
                listBox1.Items.Add(funcion);
            }
        }

    }
}
