using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MyMelodyStore
{
    internal class Conexion
    {
        private string servidor = "localhost";
        private string puerto = "3308";
        private string usuario = "root";
        private string password = "";
        private string database = "myMelodyStore";
        protected MySqlConnection conexion;


        public Conexion()
        {
            string cadenaConexion = $"server={servidor};port={puerto};user={usuario};password={password};database={database};Convert Zero Datetime=True;";
            conexion = new MySqlConnection(cadenaConexion);
        }

        public MySqlConnection AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        public DataTable MostrarDatos()
        {
            DataTable tabla = new DataTable();

            string query = "SELECT * FROM catalogo";

            AbrirConexion();

            MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
            da.Fill(tabla);

            CerrarConexion();

            return tabla;
        }

        protected int EjecutarComando(string consulta, params MySqlParameter[] parametros)
        {
            try
            {
                AbrirConexion();

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }

                    return comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error ejecutando comando en MySQL:\n" + ex.Message,
                    "Error SQL", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                CerrarConexion();
            }
        }

        protected DataTable ConsultarDatos(
           string consulta,
           params MySqlParameter[] parametros)
        {
            DataTable tabla = new DataTable();

            try
            {
                AbrirConexion();

                using (MySqlCommand comando =
                    new MySqlCommand(consulta, conexion))
                {
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }

                    using (MySqlDataAdapter adaptador =
                        new MySqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }
            finally
            {
                CerrarConexion();
            }

            return tabla;
        }

        public bool Agregar(string nombre, string descripcion, string rutaImagen)
        {
            string query = "INSERT INTO catalogo (nombre_producto, descripcion, ruta_imagen) VALUES (@nombre, @descripcion, @ruta);";

            try
            {
                AbrirConexion();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@descripcion", descripcion);
                    comando.Parameters.AddWithValue("@ruta", rutaImagen);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al guardar:\n" + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally { CerrarConexion(); }
        }

        public bool Actualizar(string nombre, string descripcion, string rutaImagen)
        {
            string query = "UPDATE catalogo SET descripcion = @descripcion, ruta_imagen = @ruta WHERE nombre_producto = @nombre;";

            try
            {
                AbrirConexion();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@descripcion", descripcion);
                    comando.Parameters.AddWithValue("@ruta", rutaImagen);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al actualizar:\n" + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally { CerrarConexion(); }
        }

        public bool Eliminar(string nombre)
        {
            string query = "DELETE FROM catalogo WHERE nombre_producto = @nombre;";

            try
            {
                AbrirConexion();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al eliminar:\n" + ex.Message,
                    "Error de Base de Datos", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }




        public bool AgregarVenta(string fecha, string concepto, decimal total)
        {
            string query = "INSERT INTO ventas (fecha, concepto, total) VALUES (@fecha, @concepto, @total);";
            try
            {
                AbrirConexion();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@fecha", fecha);
                    comando.Parameters.AddWithValue("@concepto", concepto);
                    comando.Parameters.AddWithValue("@total", total);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al registrar la venta:\n" + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally { CerrarConexion(); }
        }

        public bool ActualizarVenta(int idVenta, string fecha, string concepto, decimal total)
        {
            string query = "UPDATE ventas SET fecha = @fecha, concepto = @concepto, total = @total WHERE id_venta = @id;";
            try
            {
                AbrirConexion();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idVenta);
                    comando.Parameters.AddWithValue("@fecha", fecha);
                    comando.Parameters.AddWithValue("@concepto", concepto);
                    comando.Parameters.AddWithValue("@total", total);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al actualizar la venta:\n" + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally { CerrarConexion(); }
        }

        public bool EliminarVenta(int idVenta)
        {
            string query = "DELETE FROM ventas WHERE id_venta = @id;";
            try
            {
                AbrirConexion();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idVenta);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al eliminar la venta:\n" + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally { CerrarConexion(); }
        }


        public bool AgregarProducto(string nombre, string categoria, decimal precio, int stock)
        {
            string query = "INSERT INTO productos (nombre, categoria, precio, stock) VALUES (@nombre, @categoria, @precio, @stock);";

            try
            {
                AbrirConexion();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@categoria", categoria);
                    comando.Parameters.AddWithValue("@precio", precio);
                    comando.Parameters.AddWithValue("@stock", stock);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al agregar producto:\n" + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally { CerrarConexion(); }
        }

        public bool ActualizarProducto(int idProducto, string nombre, string categoria, decimal precio, int stock)
        {
            string query = "UPDATE productos SET nombre = @nombre, categoria = @categoria, precio = @precio, stock = @stock WHERE id_producto = @id;";

            try
            {
                AbrirConexion();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idProducto);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@categoria", categoria);
                    comando.Parameters.AddWithValue("@precio", precio);
                    comando.Parameters.AddWithValue("@stock", stock);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al actualizar producto:\n" + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally { CerrarConexion(); }
        }

        public bool EliminarProducto(int idProducto)
        {
            string query = "DELETE FROM productos WHERE id_producto = @id;";

            try
            {
                AbrirConexion();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idProducto);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al eliminar producto:\n" + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally { CerrarConexion(); }
        }



        public bool AgregarCliente(string nombre, string telefono, string correo)
        {
            string query = "INSERT INTO clientes (nombre, telefono, correo) VALUES (@nombre, @telefono, @correo);";
            try
            {
                AbrirConexion();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@telefono", telefono);
                    comando.Parameters.AddWithValue("@correo", correo);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al guardar cliente:\n" + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally { CerrarConexion(); }
        }

        public bool ActualizarCliente(int idCliente, string nombre, string telefono, string correo)
        {
            string query = "UPDATE clientes SET nombre = @nombre, telefono = @telefono, correo = @correo WHERE id_cliente = @id;";
            try
            {
                AbrirConexion();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idCliente);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@telefono", telefono);
                    comando.Parameters.AddWithValue("@correo", correo);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al actualizar cliente:\n" + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally { CerrarConexion(); }
        }

        public bool EliminarCliente(int idCliente)
        {
            string query = "DELETE FROM clientes WHERE id_cliente = @id;";
            try
            {
                AbrirConexion();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idCliente);
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al eliminar cliente:\n" + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally { CerrarConexion(); }
        }





        public bool AgregarProveedor(string empresa, string contactoNombre, string telefono)
        {
            string query = "INSERT INTO proveedores (empresa, contacto_nombre, telefono) VALUES (@empresa, @contacto, @telefono);";

            try
            {
                AbrirConexion();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@empresa", empresa);
                    comando.Parameters.AddWithValue("@contacto", contactoNombre);
                    comando.Parameters.AddWithValue("@telefono", telefono);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al agregar proveedor:\n" + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally { CerrarConexion(); }
        }

        public bool EliminarProveedor(int idProveedor)
            {
            string query = "DELETE FROM proveedores WHERE id_proveedor = @id;";

            try
            {
                AbrirConexion();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idProveedor);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al eliminar proveedor:\n" + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally { CerrarConexion(); }
        }

        public bool ActualizarProveedor(int id, string empresa, string contactoNombre, string telefono)
        {
            string query = "UPDATE proveedores SET empresa = @empresa, contacto_nombre = @contacto, telefono = @telefono WHERE id_proveedor = @id;";

            try
            {
                AbrirConexion();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@empresa", empresa);
                    comando.Parameters.AddWithValue("@contacto", contactoNombre);
                    comando.Parameters.AddWithValue("@telefono", telefono);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al actualizar proveedor:\n" + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally { CerrarConexion(); }
        }


    }
}