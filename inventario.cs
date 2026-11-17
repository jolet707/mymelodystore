using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MyMelodyStore
{
    internal class inventario : Conexion
    {
        public DataTable ObtenerDatos()
        {
            DataTable tabla = new DataTable();
            string query = "SELECT * FROM Productos;";
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