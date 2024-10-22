using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto._1
{
    public partial class Form1 : Form
    {
        double Num1 = 0;
        double Num2 = 0;
        char Operador;
        public Form1()
        {
            InitializeComponent();
        }

        private void AgregarNumero (object sender, EventArgs e)
        {
            var boton = ((Button)sender);

            if (txtResultado.Text == "0")
                txtResultado.Text = "";

            txtResultado.Text += boton.Text;
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (!txtResultado.Text.Contains("."))
            {
                txtResultado.Text += ".";
            }
        }

        private void btnSignos_Click(object sender, EventArgs e)
        {
            Num1 = Convert.ToDouble(txtResultado.Text);
            Num1 *= -1;
            txtResultado.Text = Num1.ToString();
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            Num1 = 0;
            Num2 = 0;
            Operador = '\0';
            txtResultado.Text = "0";
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            Num1 = Convert.ToDouble(txtResultado.Text);
            Operador = '+';
            txtResultado.Text = "0";
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            Num1 = Convert.ToDouble(txtResultado.Text);
            Operador = '-';
            txtResultado.Text = "0";
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            Num1 = Convert.ToDouble(txtResultado.Text);
            Operador = '*';
            txtResultado.Text = "0";
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            Num1 = Convert.ToDouble(txtResultado.Text);
            Operador = '/';
            txtResultado.Text = "0";
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            Num2 = Convert.ToDouble(txtResultado.Text);
            double resultado = 0;

            switch (Operador)
            {
                case '+':
                    resultado = Num1 + Num2;
                    break;
                case '-':
                    resultado = Num1 - Num2;
                    break;
                case '*':
                    resultado = Num1 * Num2;
                    break;
                case '/':
                    if (Num2 != 0)
                    {
                        resultado = Num1 / Num2;
                    }
                    else
                    {
                        MessageBox.Show("No se puede dividir por cero.");
                        return;
                    }
                    break;
            }

            txtResultado.Text = resultado.ToString();
            Num1 = resultado;  // Para seguir con la operación con el resultado si se desea.
        }
    }
}
