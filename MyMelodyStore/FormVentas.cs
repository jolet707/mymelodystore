using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


       namespace MyMelodyStore
       {

    public partial class FormVentas : Form
    {
        private Ventas ventas = new Ventas();

        public FormVentas()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                dgvVentas.DataSource = ventas.ObtenerDatos();
                dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar la tabla: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormVentas_Load(object sender, EventArgs e)
        {

        }

        //botón insertar
        private void button1_Click(object sender, EventArgs e)
        {
            string fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            string concepto = textBox2.Text;

            decimal total = 0;
            decimal.TryParse(textBox3.Text, out total);

            Conexion conex = new Conexion();
            if (conex.AgregarVenta(fecha, concepto, total))
            {
                MessageBox.Show("Venta registrada :D ");
                CargarDatos();

                textBox2.Clear();
                textBox3.Clear();
                dateTimePicker1.Value = DateTime.Now;
            }

        }

        //botón eliminar

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {
              
                int id = Convert.ToInt32(dgvVentas.SelectedRows[0].Cells["id_venta"].Value);

                Conexion conex = new Conexion();

               
                if (conex.EliminarVenta(id))
                {
                    MessageBox.Show("Venta eliminada correctamente D:");
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Selecciona la fila de la venta en la tabla que deseas eliminar xfa");
            }
        }

        
    }
}

