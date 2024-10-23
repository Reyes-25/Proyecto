using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0" || operacionSeleccionada)
                txtResultado.Clear();

            operacionSeleccionada = false;
            Button btn = (Button)sender;
            txtResultado.Text += btn.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "1" || operacionSeleccionada)
                txtResultado.Clear();

            operacionSeleccionada = false;
            Button btn = (Button)sender;
            txtResultado.Text += btn.Text;
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "3" || operacionSeleccionada)
                txtResultado.Clear();

            operacionSeleccionada = false;
            Button btn = (Button)sender;
            txtResultado.Text += btn.Text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "4" || operacionSeleccionada)
                txtResultado.Clear();

            operacionSeleccionada = false;
            Button btn = (Button)sender;
            txtResultado.Text += btn.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "5" || operacionSeleccionada)
                txtResultado.Clear();

            operacionSeleccionada = false;
            Button btn = (Button)sender;
            txtResultado.Text += btn.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "6" || operacionSeleccionada)
                txtResultado.Clear();

            operacionSeleccionada = false;
            Button btn = (Button)sender;
            txtResultado.Text += btn.Text;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "7" || operacionSeleccionada)
                txtResultado.Clear();

            operacionSeleccionada = false;
            Button btn = (Button)sender;
            txtResultado.Text += btn.Text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "8" || operacionSeleccionada)
                txtResultado.Clear();

            operacionSeleccionada = false;
            Button btn = (Button)sender;
            txtResultado.Text += btn.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "9" || operacionSeleccionada)
                txtResultado.Clear();

            operacionSeleccionada = false;
            Button btn = (Button)sender;
            txtResultado.Text += btn.Text;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0" || operacionSeleccionada)
                txtResultado.Clear();

            operacionSeleccionada = false;
            Button btn = (Button)sender;
            txtResultado.Text += btn.Text;
        }

        private void btnSignos_Click(object sender, EventArgs e)
        {
            // Alterna entre signo de más y signo de menos
            if (esMas)
            {
                txtResultado.Text += "+"; // Añade el signo de más
            }
            else
            {
                txtResultado.Text += "-"; // Añade el signo de menos
            }

            // Cambia el estado del signo
            esMas = !esMas; // Alterna el valor booleano
        }

        private void btnParenInicio_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "(";
        }

        private void btnParenFinal_Click(object sender, EventArgs e)
        {
            txtResultado.Text += ")";
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            txtResultado.Text += ".";
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            double numero;
            if (double.TryParse(txtResultado.Text, out numero))
            {
                txtResultado.Text = Math.Pow(numero, 2).ToString();
            }
        }

        private void btnCuadrado_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtResultado.Text))
            {
                // Agrega el símbolo de exponente al TextBox
                txtResultado.Text += "²"; // O puedes usar Unicode: "\u00B2"
            }
        }

        private void btnPorciento_Click(object sender, EventArgs e)
        {
            // Verifica si el TextBox tiene un número válido y no es cero
            if (double.TryParse(txtResultado.Text, out double numero) && numero != 0)
            {
                // Agrega el símbolo de porcentaje al TextBox
                txtResultado.Text += "%"; // Puedes usar también txtNumero.Text += " %";
            }
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            operacion = "+";
            resultado = double.Parse(txtResultado.Text);
            operacionSeleccionada = true;
            txtResultado.Text += "+";
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            operacion = "-";
            resultado = double.Parse(txtResultado.Text);
            operacionSeleccionada = true;
            txtResultado.Text += "-";
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            operacion = "*";
            resultado = double.Parse(txtResultado.Text);
            operacionSeleccionada = true;
            txtResultado.Text += "x";
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            operacion = "/";
            resultado = double.Parse(txtResultado.Text);
            operacionSeleccionada = true;
            txtResultado.Text += "÷";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = string.Empty; // Restablece todo
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            // Verifica si hay texto en el TextBox
            if (txtResultado.Text.Length > 0)
            {
                // Elimina el último carácter del TextBox
                txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 1);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

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
    }
}
