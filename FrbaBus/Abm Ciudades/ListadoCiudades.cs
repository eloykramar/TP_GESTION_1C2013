using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Abm_Ciudades
{
    public partial class ListadoCiudades : Form
    {
        public ListadoCiudades()
        {
            InitializeComponent();

            DataGridViewButtonColumn botonesBajaCiudad = this.crearBotones("Eliminar Ciudad","Eliminar");
            dataGridView1.Columns.Add(botonesBajaCiudad);
            DataGridViewButtonColumn botonesModifCiudad = this.crearBotones("Modificar Ciudad","Modificar");
            dataGridView1.Columns.Add(botonesModifCiudad);

            using (SqlConnection conexion = new SqlConnection("Server=localhost\\SQLSERVER2008;Database=GD1C2013;User Id=gd;Password=gd2013;"))
            {
                try
                {

                    conexion.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM LOS_VIAJEROS_DEL_ANONIMATO.CIUDAD", conexion);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable tabla = new DataTable();

                    adapter.Fill(tabla);

                    dataGridView1.DataSource = tabla;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                        
                }
                catch
                { }
            }

        }

        public DataGridViewButtonColumn crearBotones(String nombreColumna, String leyendaBoton)
        {
            DataGridViewButtonColumn botones = new DataGridViewButtonColumn();
            botones.HeaderText = nombreColumna;
            botones.Text = leyendaBoton;
            botones.UseColumnTextForButtonValue = true;
            botones.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            return botones;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex != -1)
            {
                String nombreCiudadActual = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (e.ColumnIndex == 0)
                {
                    (new BajaCiudad(nombreCiudadActual)).Show() ;
                }
                if (e.ColumnIndex == 1)
                {
                    (new ModifCiudad(nombreCiudadActual)).Show();
                }
                      
            }
        }
    }
}
