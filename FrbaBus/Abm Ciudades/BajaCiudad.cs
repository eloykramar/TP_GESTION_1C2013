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
    public partial class BajaCiudad : Form
    {
        String nombreCiudad;
        
        public BajaCiudad()
        {
            InitializeComponent();
            using (SqlConnection conexion = new SqlConnection("Server=localhost\\SQLSERVER2008;Database=GD1C2013;User Id=gd;Password=gd2013;"))
            {
                try
                {

                    conexion.Open();

                    // TODO usar funciones con parametros
                    SqlCommand cmd = new SqlCommand("USE GD1C2013 SELECT * FROM LOS_VIAJEROS_DEL_ANONIMATO.CIUDAD", conexion);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable tablaDeNombres = new DataTable();

                    adapter.Fill(tablaDeNombres);

                    comboBox1.DisplayMember = "NombreCiudad";
                    comboBox1.DataSource = tablaDeNombres;
                    
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    (new Dialogo("A la mierda con todo; " + ex.Message, "Aceptar")).ShowDialog();
                }
            }
        }

        public BajaCiudad(String nombreCiudadAEliminar)
        {
            InitializeComponent();
            //textBox1.Text = nombreCiudadAEliminar;
            comboBox1.Text = nombreCiudadAEliminar;
            //textBox1.Enabled = false;
            comboBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection("Server=localhost\\SQLSERVER2008;Database=GD1C2013;User Id=gd;Password=gd2013;"))
            {
                try
                {

                    conexion.Open();

                    //nombreCiudad = textBox1.Text;
                    nombreCiudad = comboBox1.Text;

                    // TODO usar funciones con parametros
                    SqlCommand cmd = new SqlCommand("USE GD1C2013 SELECT COUNT(*) FROM LOS_VIAJEROS_DEL_ANONIMATO.CIUDAD Ciudad WHERE Ciudad.NombreCiudad = '" + nombreCiudad + "'", conexion);

                    int cantidadDeFilas = (int)cmd.ExecuteScalar();

                    if (cantidadDeFilas == 0)
                    {
                        (new Dialogo("No existe la ciudad", "Aceptar")).ShowDialog();
                    }
                    else
                    {
                        cmd.CommandText = "USE GD1C2013 DELETE FROM LOS_VIAJEROS_DEL_ANONIMATO.CIUDAD WHERE NombreCiudad = '" + nombreCiudad + "'";
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        (new Dialogo(nombreCiudad + " eliminada: \n" + filasAfectadas + " filas afectadas", "Aceptar")).ShowDialog();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    (new Dialogo("A la mierda con todo; " + ex.Message, "Aceptar")).ShowDialog();
                }
            }
        }

    }
}
