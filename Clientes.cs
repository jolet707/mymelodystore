using Mysqlx.Crud;
using MySqlX.XDevAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace MyMelodyStore
{
    internal class Clientes: Conexion
    {
        public DataTable ObtenerDatos()
        {
            DataTable tabla = new DataTable();
            string query = "SELECT * FROM Clientes;";
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
