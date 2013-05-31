using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus
{
    public partial class PruebaSQL : Form
    {

        public PruebaSQL()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "PROCESANDO";

            SqlConnection conexion = new SqlConnection("Server=localhost\\SQLSERVER2008;Database=GD1C2013;User Id=gd;Password=gd2013;");
            try
            {

                conexion.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM LOS_VIAJEROS_DEL_ANONIMATO.TIPOSERVICIO", conexion);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable tabla = new DataTable();

                adapter.Fill(tabla);

                dataGridView1.DataSource = tabla;
                dataGridView1.AutoSize = true;

                this.Text = "LISTO";

            }
            catch
            { }

            conexion.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
