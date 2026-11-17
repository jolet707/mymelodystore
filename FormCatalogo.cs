using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyMelodyStore
{

    public partial class FormCatalogo : Form
    {

        private Catalogo catalogo = new Catalogo();

        public FormCatalogo()
        {
            InitializeComponent();
            CargarDatos();
            
        }

        private void CargarDatos()
        {
            try
            {
                Conexion conex = new Conexion();
                dgvCatalogo.DataSource = conex.MostrarDatos();

                dgvCatalogo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar la tabla: " + ex.Message);
            }
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                System.Data.DataRowView filaSeleccionada = (System.Data.DataRowView)dgvCatalogo.Rows[e.RowIndex].DataBoundItem;

                string ruta = Convert.ToString(filaSeleccionada["ruta_imagen"]);

                if (!string.IsNullOrWhiteSpace(ruta) && System.IO.File.Exists(ruta))
                {
                    pbImagenProducto.Image = Image.FromFile(ruta);
                }
                else
                {
                    pbImagenProducto.Image = null;
                }
            }
        }

        //botón insertar
        private void button1_Click(object sender, EventArgs e)
        {
            Conexion conex = new Conexion();
            string nombre = textBox1.Text;
            string descripcion = textBox2.Text;
            string ruta = textBox3.Text; 

            bool resultado = conex.Agregar(nombre, descripcion, ruta);

            if (resultado)
            {
                MessageBox.Show("Producto agregado correctamente");
                CargarDatos();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }
        //botón eliminar
        private void button2_Click(object sender, EventArgs e)
        {
            string nombreABorrar = "";

            if (dgvCatalogo.SelectedRows.Count > 0)
            {
                nombreABorrar = dgvCatalogo.SelectedRows[0].Cells[0].Value?.ToString() ?? string.Empty;
            }
            else if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                nombreABorrar = textBox1.Text;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila en la tabla o escribe el nombre del producto para eliminar.");
                return;
            }

            Conexion conex = new Conexion();
            bool resultado = conex.Eliminar(nombreABorrar);

            if (resultado)
            {
                MessageBox.Show("Producto eliminado correctamente");
                CargarDatos();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear(); 
            }
            else
            {
                MessageBox.Show("No se encontró el producto para eliminar.");
            }
        }
        //botón actualizar
        private void button3_Click(object sender, EventArgs e)
        {
            string nombreAActualizar = "";

            if (dgvCatalogo.SelectedRows.Count > 0)
            {
                nombreAActualizar = dgvCatalogo.SelectedRows[0].Cells["Producto"].Value.ToString();
            }
            else if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                nombreAActualizar = textBox1.Text;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila o escribe el nombre del producto a actualizar.");
                return;
            }

            string nuevaDescripcion = textBox2.Text;
            string nuevaRuta = textBox3.Text;

            if (string.IsNullOrWhiteSpace(nuevaDescripcion))
            {
                MessageBox.Show("Por favor, escribe la nueva descripción en la segunda caja de texto.");
                return;
            }

            Conexion conex = new Conexion();
            bool resultado = conex.Actualizar(nombreAActualizar, nuevaDescripcion, nuevaRuta);

            if (resultado)
            {
                MessageBox.Show("Producto actualizado correctamente");
                CargarDatos();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear(); 
            }
            else
            {
                MessageBox.Show("No se encontró el producto para actualizar.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
