using System;
using System.Data;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class frmCalculadora : Form
    {
        private double resultado = 0;
        private string operacion = "";
        private bool operacionSeleccionada = false;
        private bool esMas;

        public frmCalculadora()
        {
            InitializeComponent();
        }

        // Manejador único para todos los botones numéricos
        private void btnNumero_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0" || operacionSeleccionada)
                txtResultado.Clear();

            operacionSeleccionada = false;
            Button btn = (Button)sender;
            txtResultado.Text += btn.Text;
        }

        // Botón para los operadores
        private void btnOperacion_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            operacion = btn.Text;
            resultado = double.Parse(txtResultado.Text);
            operacionSeleccionada = true;
            txtResultado.Text += operacion;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            
            try
            {
                var resultadoOperacion = new DataTable().Compute(txtResultado.Text, null);

                // Muestra la operación arriba y el resultado debajo alineado a la derecha
                string operacion = txtResultado.Text;

                // Calcula los espacios necesarios para alinear el resultado a la derecha
                int totalSpaces = txtResultado.Width / 10 - resultadoOperacion.ToString().Length;
                string espacios = new string(' ', Math.Max(0, totalSpaces));

                // Actualiza el TextBox con la operación y el resultado alineado a la derecha
                txtResultado.Text = $"{operacion}\r\n{espacios}{resultadoOperacion}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la operación: " + ex.Message);
            }
        }

        // Otros botones (limpiar, etc.)
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = string.Empty; // Restablece todo
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.Length > 0)
            {
                txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 1);
            }
        }
    }
}
