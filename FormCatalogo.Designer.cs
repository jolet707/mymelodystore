namespace MyMelodyStore
{
    partial class FormCatalogo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvCatalogo = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            pbImagenProducto = new PictureBox();
            textBox3 = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbImagenProducto).BeginInit();
            SuspendLayout();
            // 
            // dgvCatalogo
            // 
            dgvCatalogo.BackgroundColor = Color.FromArgb(244, 232, 214);
            dgvCatalogo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCatalogo.Location = new Point(1, -1);
            dgvCatalogo.Name = "dgvCatalogo";
            dgvCatalogo.RowHeadersWidth = 51;
            dgvCatalogo.Size = new Size(528, 324);
            dgvCatalogo.TabIndex = 0;
            dgvCatalogo.CellContentClick += dgvCatalogo_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(30, 402);
            button1.Name = "button1";
            button1.Size = new Size(141, 29);
            button1.TabIndex = 1;
            button1.Text = "Agregar producto";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(187, 402);
            button2.Name = "button2";
            button2.Size = new Size(167, 29);
            button2.TabIndex = 2;
            button2.Text = "Eliminar producto";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(362, 402);
            button3.Name = "button3";
            button3.Size = new Size(167, 29);
            button3.TabIndex = 3;
            button3.Text = "Actualizar producto";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(255, 192, 255);
            label1.Location = new Point(17, 331);
            label1.Name = "label1";
            label1.Size = new Size(154, 20);
            label1.TabIndex = 4;
            label1.Text = "Nombre del producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(255, 192, 255);
            label2.Location = new Point(187, 331);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 5;
            label2.Text = "Descripción";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(17, 354);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(154, 27);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(187, 354);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 7;
            // 
            // pbImagenProducto
            // 
            pbImagenProducto.BackColor = Color.White;
            pbImagenProducto.Location = new Point(535, 37);
            pbImagenProducto.Name = "pbImagenProducto";
            pbImagenProducto.Size = new Size(179, 158);
            pbImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;
            pbImagenProducto.TabIndex = 8;
            pbImagenProducto.TabStop = false;
            pbImagenProducto.Click += pictureBox1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(345, 354);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(255, 192, 255);
            label3.Location = new Point(345, 331);
            label3.Name = "label3";
            label3.Size = new Size(192, 20);
            label3.TabIndex = 10;
            label3.Text = "Imagen del producto (ruta):";
            // 
            // FormCatalogo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 232, 214);
            ClientSize = new Size(800, 748);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(pbImagenProducto);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dgvCatalogo);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "FormCatalogo";
            Text = "FormCatalogo";
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbImagenProducto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCatalogo;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private PictureBox pbImagenProducto;
        private TextBox textBox3;
        private Label label3;
    }
}