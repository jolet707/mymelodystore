using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MyMelodyStore
{
    internal class Catalogo : Conexion
    {
        public string nombre, descripcion;

        public DataTable ObtenerDatos()
        {
            DataTable tabla = new DataTable();
            string query = "SELECT nombre_producto AS 'Producto', descripcion AS 'Descripción' FROM catalogo;";

            try
            {
                AbrirConexion();
                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                da.Fill(tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el catálogo: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return tabla;
        }
    

    }
   }


    

