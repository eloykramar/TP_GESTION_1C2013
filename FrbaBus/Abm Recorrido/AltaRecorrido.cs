using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Abm_Recorrido
{
    public partial class AltaRecorrido : Form1
    {
        public AltaRecorrido()
        {
            InitializeComponent();

            // Llenar combo box con valores posibles
            using ( SqlConnection conexion = this.obtenerConexion() )
            {
                conexion.Open();
                SqlCommand cmdParaLlenarComboBox = new SqlCommand();
                cmdParaLlenarComboBox.Connection = conexion;
                
                SqlDataAdapter adapter = new SqlDataAdapter(cmdParaLlenarComboBox);

                // Llenar los combo box 'origen' y 'destino'

                cmdParaLlenarComboBox.CommandText = "USE GD1C2013 SELECT * FROM LOS_VIAJEROS_DEL_ANONIMATO.CIUDAD";
                
                DataTable ciudadesOrigen = new DataTable();
                adapter.Fill(ciudadesOrigen);
                comboBox1.DisplayMember = "NombreCiudad";
                comboBox1.DataSource = ciudadesOrigen;

                DataTable ciudadesDestino = new DataTable();
                adapter.Fill(ciudadesDestino);
                comboBox2.DisplayMember = "NombreCiudad";
                comboBox2.DataSource = ciudadesDestino;

                // Llenar el combo box 'tipo de servicio'

                cmdParaLlenarComboBox.CommandText = "USE GD1C2013 SELECT T.NombreServicio FROM LOS_VIAJEROS_DEL_ANONIMATO.TIPOSERVICIO T";
                DataTable tiposDeServicio = new DataTable();
                adapter.Fill(tiposDeServicio);
                comboBox3.DisplayMember = "NombreServicio";
                comboBox3.DataSource = tiposDeServicio; // Tipos de servicio
            }
        }

        // Previsualizar recorrido
        private void button2_Click(object sender, EventArgs e)
        {
            (new VisualizarRecorrido(   comboBox1.Text.ToString(),
                                        comboBox2.Text.ToString(),
                                        comboBox3.Text.ToString(),
                                        numericUpDown1.Value,
                                        numericUpDown2.Value) ).Show();
        }

        // Limpiar campos
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
        }
    }
}
