using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Ciudades
{
    public partial class ABM_Ciudad_Pantalla_Inicial : Form
    {
        public ABM_Ciudad_Pantalla_Inicial()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (new AltaCiudad()).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new BajaCiudad()).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new ModifCiudad()).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            (new ListadoCiudades()).Show();
        }
    }
}
