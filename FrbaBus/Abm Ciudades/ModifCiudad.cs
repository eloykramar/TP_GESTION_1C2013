﻿using System;
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
    public partial class ModifCiudad : Form
    {
        String nombreCiudad;

        public ModifCiudad()
        {
            InitializeComponent();
        }

        public ModifCiudad(String nombreCiudadAModificar)
        {
            InitializeComponent();
            textBox1.Text = nombreCiudadAModificar;
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection("Server=localhost\\SQLSERVER2008;Database=GD1C2013;User Id=gd;Password=gd2013;"))
            {
                try
                {

                    conexion.Open();

                    nombreCiudad = textBox1.Text;
                    String nuevoNombreCiudad = textBox2.Text;

                    // TODO usar funciones con parametros
                    SqlCommand cmd = new SqlCommand("USE GD1C2013 SELECT COUNT(*) FROM LOS_VIAJEROS_DEL_ANONIMATO.CIUDAD Ciudad WHERE Ciudad.NombreCiudad = '" + nombreCiudad + "'", conexion);

                    int cantidadDeFilas = (int)cmd.ExecuteScalar();

                    if (cantidadDeFilas == 0)
                    {
                        (new Dialogo("No existe la ciudad", "Aceptar")).ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        cmd.CommandText = "USE GD1C2013 UPDATE LOS_VIAJEROS_DEL_ANONIMATO.CIUDAD SET NombreCiudad = '" + nuevoNombreCiudad + "' WHERE NombreCiudad = '" + nombreCiudad + "'";
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        (new Dialogo(nombreCiudad + " modificada \n por: " + nuevoNombreCiudad + "\n" + filasAfectadas + " filas afectadas", "Aceptar")).ShowDialog();
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
