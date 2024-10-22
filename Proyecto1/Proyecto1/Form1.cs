﻿using System;
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
        double Num1 = 0;
        double Num2 = 0;
        char Operador;

        public frmCalculadora()
        {
            InitializeComponent();
        }

        // Manejador para los botones numéricos
        private void AgregarNumero(object sender, EventArgs e)
        {
            var boton = ((Button)sender);

            if (txtResultados.Text == "0")
                txtResultados.Text = "";

            txtResultados.Text += boton.Text;
        }
        private void btnPunto_Click(object sender, EventArgs e)
        {
            Num1 = Convert.ToDouble(txtResultados.Text);
            Num1 *= -1;
            txtResultados.Text = Num1.ToString();
        }
        private void btnSignos_Click(object sender, EventArgs e)
        {
            Num1 = Convert.ToDouble(txtResultados.Text);
            Num1 *= -1;
            txtResultados.Text = Num1.ToString();
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtResultados.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            Num1 = 0;
            Num2 = 0;
            Operador = '\0';
            txtResultados.Text = "0";
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            Num1 = Convert.ToDouble(txtResultados.Text);
            Operador = '+';
            txtResultados.Text = "0";
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            Num1 = Convert.ToDouble(txtResultados.Text);
            Operador = '-';
            txtResultados.Text = "0";
        }

        private void btnMultiplica_Click(object sender, EventArgs e)
        {
            Num1 = Convert.ToDouble(txtResultados.Text);
            Operador = '*';
            txtResultados.Text = "0";
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            Num1 = Convert.ToDouble(txtResultados.Text);
            Operador = '/';
            txtResultados.Text = "0";
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            Num2 = Convert.ToDouble(txtResultados.Text);
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

            txtResultados.Text = resultado.ToString();
            Num1 = resultado;  // Para seguir con la operación con el resultado si se desea.
        }
    }
    }
    
