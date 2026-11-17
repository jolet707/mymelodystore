namespace MyMelodyStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void AbrirFormulario(Form formularioHijo)
        {
            foreach (Control control in panelContenedor.Controls)
            {
                control.Dispose();
            }

            panelContenedor.Controls.Clear();

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formularioHijo);

            formularioHijo.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormCatalogo());
        }


        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormVentas());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormInventario());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormClientes());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormProveedores());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
