using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyMelodyStore
{
        public partial class FormInventario : Form
        {
            private inventario inventario = new inventario();

            public FormInventario()
            {
                InitializeComponent();
                CargarDatos();
            }

            private void CargarDatos()
            {
                try
                {
                    dgvInventario.DataSource = inventario.ObtenerDatos();
                    dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al llenar la tabla: " + ex.Message);
                }
            }

            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            }

            private inventario inv = new inventario();

        //botón insertar
        private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    string nombre = textBox1.Text;
                    string categoria = textBox2.Text;
                    decimal precio = Convert.ToDecimal(textBox3.Text);
                    int stock = Convert.ToInt32(textBox4.Text);

                    if (inv.AgregarProducto(nombre, categoria, precio, stock))
                    {
                        MessageBox.Show("Producto agregado correctamente");
                        CargarDatos(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Verifica que el precio y stock sean números válidos: " + ex.Message);
                }
            }

        //botón eliminar
        private void button2_Click(object sender, EventArgs e)
            {
  
                if (dgvInventario.SelectedRows.Count > 0)
                {
                    try
                    {
                        int idProducto = Convert.ToInt32(dgvInventario.SelectedRows[0].Cells["id_producto"].Value);

                        string nombre = textBox1.Text;
                        string categoria = textBox2.Text;
                        decimal precio = Convert.ToDecimal(textBox3.Text);
                        int stock = Convert.ToInt32(textBox4.Text);

                        if (inv.ActualizarProducto(idProducto, nombre, categoria, precio, stock))
                        {
                            MessageBox.Show("Producto actualizado correctamente");
                            CargarDatos();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show(" Selecciona un producto de la tabla para actualizar xfis ");
                }
            }

        //botón actualizae
        private void button3_Click(object sender, EventArgs e)
            {
                if (dgvInventario.SelectedRows.Count > 0)
                {
                    DialogResult respuesta = MessageBox.Show("¿Seguro que deseas eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        int idProducto = Convert.ToInt32(dgvInventario.SelectedRows[0].Cells["id_producto"].Value);

                        if (inv.EliminarProducto(idProducto))
                        {
                            MessageBox.Show("Producto eliminado");
                            CargarDatos();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(" Selecciona un producto de la tabla para eliminar xfa");
                }
            }
        }
    }
