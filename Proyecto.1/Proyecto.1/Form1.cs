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

        // Este método agrega el número presionado en la calculadora
        private void AgregarNumero(object sender, EventArgs e)
        {
            var boton = ((Button)sender);

            if (txtResultado.Text == "0")
                txtResultado.Text = "";

            txtResultado.Text += boton.Text;
        }

        // Botón para agregar punto decimal
        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (!txtResultado.Text.Contains("."))
            {
                txtResultado.Text += ".";
            }
        }

        // Botón para cambiar el signo del número
        private void btnSignos_Click(object sender, EventArgs e)
        {
            Num1 = Convert.ToDouble(txtResultado.Text);
            Num1 *= -1;
            txtResultado.Text = Num1.ToString();
        }

        // Botón para borrar el último cálculo (reset)
        private void btnCE_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
        }

        // Botón para borrar toda la operación actual
        private void btnC_Click(object sender, EventArgs e)
        {
            Num1 = 0;
            Num2 = 0;
            Operador = '\0';
            txtResultado.Text = "0";
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
            GuardarHistorial(Operador.ToString(), Num1, Num2, resultado); // Guardar la operación y resultado
            Num1 = resultado;
        }

        // Botón para elevar al cuadrado el número
        private void btnAlCuadrado_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtResultado.Text, out double num))
            {
                double resultado = Math.Pow(num, 2);
                txtResultado.Text = resultado.ToString();

                // Guardar la operación "num^2" en la base de datos
                GuardarHistorial($"{num}^2", num, 0, resultado);
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

                    // Guardar la operación "√num" en la base de datos
                    GuardarHistorial($"√{num}", num, 0, resultado);
                }
                else
                {
                    txtResultado.Text = "ERROR";
                }
            }
            else
            {
                txtResultado.Text = "ERROR";
            }
        }

        // Método para guardar el historial de operaciones en la base de datos
        private void GuardarHistorial(string operacion, double num1, double num2, double resultado)
        {
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el historial: " + ex.Message);
                }
            }
        }

        // Botón para mostrar el historial de operaciones
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            MostrarHistorial();
        }

        // Método para cargar y mostrar los datos en el ListBox
        private void MostrarHistorial()
        {
            listBox1.Items.Clear(); // Limpiar el ListBox antes de cargar los datos

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT operacion, resultado FROM HistorialCalculos"; // Consulta para obtener las operaciones y resultados
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open(); // Abre la conexión a la base de datos
                    SqlDataReader reader = command.ExecuteReader(); // Ejecuta la consulta y obtiene los resultados

                    while (reader.Read()) // Lee los resultados fila por fila
                    {
                        string operacion = reader["operacion"].ToString(); // Obtiene el valor de la columna "operacion"
                        string resultado = reader["resultado"].ToString(); // Obtiene el valor de la columna "resultado"
                        listBox1.Items.Add($"{operacion} = {resultado}"); // Muestra cada operación y resultado en el ListBox
                    }

                    reader.Close(); // Cierra el lector de datos
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el historial: " + ex.Message); // Muestra un mensaje de error si ocurre algún problema
                }
            }
        }
    }
}
