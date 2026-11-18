using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyMelodyStore
{
    public partial class FormClientes : Form
    {
        private Clientes clientes = new Clientes();

        public FormClientes()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                dgvClientes.DataSource = clientes.ObtenerDatos();
                dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar la tabla: " + ex.Message);
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        //botón insertar
        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string telefono = textBox2.Text;
            string correo = textBox3.Text;

            Conexion conex = new Conexion();
            if (conex.AgregarCliente(nombre, telefono, correo))
            {
                MessageBox.Show("Cliente agregado correctamente");
                CargarDatos();
            }
        }

        //botón eliminar
        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["id_cliente"].Value);

                Conexion conex = new Conexion();
                if (conex.EliminarCliente(id))
                {
                    MessageBox.Show("Cliente eliminado correctamente ");
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Selecciona la fila completa del cliente en la tabla antes de eliminar plis porfavor");
            }
        }

        //botón actualizar
        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["id_cliente"].Value);

                string nombre = textBox1.Text;
                string telefono = textBox2.Text;
                string correo = textBox3.Text;

                Conexion conex = new Conexion();
                if (conex.ActualizarCliente(id, nombre, telefono, correo))
                {
                    MessageBox.Show("Datos del cliente actualizados ");
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Selecciona el cliente en la tabla, cambia sus datos en las cajas de texto y luego presiona Actualizar ");
            }
        }
    }
}
