using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms; 

namespace MyMelodyStore
{
   
    internal class Ventas : Conexion
    {
        public string concepto, fecha;
        public decimal total;

        public DataTable ObtenerDatos()
        {
            DataTable tabla = new DataTable();
            string query = "SELECT * FROM Ventas;";
            try
            {
                AbrirConexion();
                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                da.Fill(tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
            return tabla;
        }

       

    }
}