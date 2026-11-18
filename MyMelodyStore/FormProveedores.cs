using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyMelodyStore
{
    public partial class FormProveedores : Form
    {
        private Proveedores proveedores = new Proveedores();

        public FormProveedores()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                dgvProveedores.DataSource = proveedores.ObtenerDatos();
                dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar la tabla: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //botón insertar
        private void button1_Click(object sender, EventArgs e)
        {
            string empresa = textBox1.Text;
            string contacto = textBox2.Text;
            string telefono = textBox3.Text;

            Conexion conex = new Conexion();

            if (conex.AgregarProveedor(empresa, contacto, telefono))
            {
                MessageBox.Show("Proveedor registrado exitosamente ");
                CargarDatos();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        //botón eliminar
        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show("¿Seguro que deseas eliminar este proveedor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {

                    int id = Convert.ToInt32(dgvProveedores.SelectedRows[0].Cells["id_proveedor"].Value);

                    Conexion conex = new Conexion();
                    if (conex.EliminarProveedor(id))
                    {
                        MessageBox.Show("Proveedor eliminado");
                        CargarDatos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona toda la fila del proveedor en la tabla antes de eliminar ");
            }
        }

        //botón actualizar
        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvProveedores.SelectedRows[0].Cells["id_proveedor"].Value);

                string empresa = textBox1.Text;
                string contacto = textBox2.Text;
                string telefono = textBox3.Text;

                Conexion conex = new Conexion();
                if (conex.ActualizarProveedor(id, empresa, contacto, telefono))
                {
                    MessageBox.Show("Datos del proveedor actualizados ");
                    CargarDatos();

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }
            else
            {
                MessageBox.Show("Selecciona el proveedor en la tabla, cambia sus datos en las cajas y presiona Actualizar ");
            }
        }
    }
}