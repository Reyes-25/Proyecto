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
            MostrarHistorial(); // Mostrar operaciones al iniciar
        }

        private void AgregarNumero(object sender, EventArgs e)
        {
            var boton = (Button)sender;

            if (txtResultado.Text == "0")
                txtResultado.Text = "";

            txtResultado.Text += boton.Text;
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (!txtResultado.Text.Contains("."))
                txtResultado.Text += ".";
        }

        private void btnSignos_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtResultado.Text, out Num1))
            {
                Num1 *= -1;
                txtResultado.Text = Num1.ToString();
            }
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.Length > 1)
                txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 1);
            else
                txtResultado.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
            Num1 = 0;
            Num2 = 0;
            Operador = '\0';
        }

        // Operaciones matemáticas básicas
        private void btnSuma_Click(object sender, EventArgs e)
        {
            SetOperacion('+');
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            SetOperacion('-');
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            SetOperacion('*');
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            SetOperacion('/');
        }

        private void SetOperacion(char operador)
        {
            Num1 = Convert.ToDouble(txtResultado.Text);
            Operador = operador;
            txtResultado.Text = "0";
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            try
            {
                Num2 = Convert.ToDouble(txtResultado.Text);
                double resultado = 0;
                string operacionCompleta = "";
                string operacionText = "";

                // Determinar operación
                switch (Operador)
                {
                    case '+':
                        resultado = Num1 + Num2;
                        operacionCompleta = $"{Num1} + {Num2}";
                        operacionText = "Suma";
                        break;
                    case '-':
                        resultado = Num1 - Num2;
                        operacionCompleta = $"{Num1} - {Num2}";
                        operacionText = "Resta";
                        break;
                    case '*':
                        resultado = Num1 * Num2;
                        operacionCompleta = $"{Num1} * {Num2}";
                        operacionText = "Multiplicación";
                        break;
                    case '/':
                        if (Num2 != 0)
                        {
                            resultado = Num1 / Num2;
                            operacionCompleta = $"{Num1} / {Num2}";
                            operacionText = "División";
                        }
                        else
                        {
                            MessageBox.Show("No se puede dividir por cero.");
                            return;
                        }
                        break;
                    default:
                        MessageBox.Show("Operación no válida.");
                        return;
                }

                txtResultado.Text = resultado.ToString();
                Num1 = resultado;

                GuardarOperacion(Num1, Num2, operacionCompleta, operacionText, resultado);

                listBox1.Items.Add($"{operacionCompleta} = {resultado}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        private void GuardarOperacion(double valor1, double valor2, string operacion, string operacionText, double resultado)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    INSERT INTO HistorialCalculos 
                    (Valor1, Valor2, Operacion, OperacionText, Resultado, FechaRegistro) 
                    VALUES 
                    (@Valor1, @Valor2, @Operacion, @OperacionText, @Resultado, GETDATE())";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Valor1", valor1);
                    command.Parameters.AddWithValue("@Valor2", valor2);
                    command.Parameters.AddWithValue("@Operacion", operacion);
                    command.Parameters.AddWithValue("@OperacionText", operacionText);
                    command.Parameters.AddWithValue("@Resultado", resultado);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show($"Error al guardar en la base de datos: {sqlEx.Message}");
                    }
                }
            }
        }

        private void btnAlCuadrado_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtResultado.Text, out double num))
            {
                try
                {
                    double resultado = Math.Pow(num, 2); // Elevamos al cuadrado
                    if (double.IsInfinity(resultado)) // Comprobamos si el resultado excede los límites
                    {
                        MessageBox.Show("El resultado es demasiado grande para procesarlo.");
                        return;
                    }

                    txtResultado.Text = resultado.ToString();
                    GuardarOperacion(num, 0, $"{num}^2", "Potencia al cuadrado", resultado);
                    MostrarHistorial();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al calcular la potencia: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un número válido.");
            }
        }


        private void btnRaiz_Click(object sender, EventArgs e)
        {
            RealizarOperacionUnaria(Math.Sqrt, "√", "Raíz cuadrada", validarNegativos: true);
        }

        private void RealizarOperacionUnaria(Func<double, double> operacion, string simbolo, string texto, bool validarNegativos = false)
        {
            if (double.TryParse(txtResultado.Text, out double num))
            {
                if (validarNegativos && num < 0)
                {
                    MessageBox.Show("No se puede realizar esta operación con números negativos.");
                    return;
                }

                double resultado = operacion(num);
                txtResultado.Text = resultado.ToString();
                GuardarOperacion(num, 0, simbolo, texto, resultado);
                MostrarHistorial();
            }
        }

        private void MostrarHistorial()
        {
            listBox1.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Operacion, Resultado FROM HistorialCalculos ORDER BY FechaRegistro DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            string operacion = reader["Operacion"].ToString();
                            string resultado = reader["Resultado"].ToString();
                            listBox1.Items.Add($"{operacion} = {resultado}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar el historial: {ex.Message}");
                    }
                }
            }
        }
    }
}
