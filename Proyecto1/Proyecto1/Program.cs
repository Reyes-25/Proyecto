using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;


namespace Proyecto1
{
    internal static class Program
    {
        // Variable global para acceder a la configuración
        public static IConfiguration Configuration;

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configurar el cargador de appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // Construir la configuración
            Configuration = builder.Build();

            // Iniciar la aplicación
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmCalculadora());
        }
    }
}
