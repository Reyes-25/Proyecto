using System;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class frmCalculadora : Form
    {
        private double Numero1 = 0, Numero2 = 0;
        private char Operador;

        public frmCalculadora()
        {
            InitializeComponent();
        }

        // Manejador para los botones numéricos
        private void btnNumero_Click(object sender, EventArgs e)
        {
            var boton = ((Button)sender);

            if (txtResultado.Text == "0")
                txtResultado.Text = "";

            txtResultado.Text += boton.Text;
        }

        // Botón para seleccionar operadores
        private void btnOperacion_Click(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            Numero1 = Convert.ToDouble(txtResultado.Text);
            Operador = Convert.ToChar(boton.Tag);

            // Botón para borrar todo
            private void btnBorrar_Click(object sender, EventArgs e)
        {
            Numero1 = 0;
            Numero2 = 0;
            Operador = '\0';
            txtResultado.Text = "0";
        }

        // Botón para borrar solo la última entrada
        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
        }
    }
}
