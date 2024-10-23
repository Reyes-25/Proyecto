using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto._1
{
    public partial class Form1 : Form
    {
        double Num1 = 0;
        double Num2 = 0;
        char Operador;
        string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CalculadoraDB;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }
        private void AgregarNumero(object sender, EventArgs e)
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
            if (txtResultado.Text.Length > 1)
            {
                txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 1);
            }
            else
            {
                txtResultado.Text = "0";
            }
        }
        private void btnC_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0"; 
            listBox1.Items.Clear(); 
            Num1 = 0;               
            Num2 = 0;
            Operador = '\0';        
        }

        // Operaciones matemáticas básicas
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

        // Botón para calcular el resultado
        private void btnResultado_Click(object sender, EventArgs e)
        {
            Num2 = Convert.ToDouble(txtResultado.Text);
            double resultado = 0;
            string operacionTexto = $"{Num1} {Operador} {Num2}";

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
            Num1 = resultado;

            GuardarYMostrarOperacion(operacionTexto, resultado);
        }

        private void btnAlCuadrado_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtResultado.Text, out double num))
            {
                double resultado = Math.Pow(num, 2);
                txtResultado.Text = resultado.ToString();

                // Guardar y mostrar la operación
                GuardarYMostrarOperacion($"{num}²", resultado);
            }
            else
            {
                txtResultado.Text = "ERROR";
            }
        }

        // Botón para calcular la raíz cuadrada
        private void btnRaiz_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtResultado.Text, out double num))
            {
                if (num >= 0)
                {
                    double resultado = Math.Sqrt(num);
                    txtResultado.Text = resultado.ToString();

                    // Guardar y mostrar la operación
                    GuardarYMostrarOperacion($"√{num}", resultado);
                }
                else
                {
                    MessageBox.Show("No se puede calcular la raíz cuadrada de un número negativo.");
                }
            }
            else
            {
                txtResultado.Text = "ERROR";
            }
        }

        private void GuardarYMostrarOperacion(string operacion, double resultado)
        {
            listBox1.Items.Add($"{operacion} = {resultado}");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO HistorialCalculos (operacion, resultado) VALUES (@operacion, @resultado)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@operacion", operacion);
                command.Parameters.AddWithValue("@resultado", resultado);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Error al guardar en la base de datos: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error general al guardar en la base de datos: " + ex.Message);
                }
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            listBox1.Items.Clear(); 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT operacion, resultado FROM HistorialCalculos";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string operacion = reader["operacion"].ToString();
                        string resultado = reader["resultado"].ToString();
                        listBox1.Items.Add($"{operacion} = {resultado}"); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el historial: " + ex.Message);
                }
            }
        }
    }
}
