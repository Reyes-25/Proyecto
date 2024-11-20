using Proyecto._2.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://tudominio.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // GET: api/HistorialCalculos/Todos
            HttpResponseMessage response = await client.GetAsync("api/HistorialCalculos/Todos");
            if (response.IsSuccessStatusCode)
            {
                var calculos = await response.Content.ReadAsAsync<IEnumerable<HistorialCalculos>>();
                foreach (var calculo in calculos)
                {
                    Console.WriteLine($"{calculo.Id}: {calculo.Operacion} = {calculo.Resultado}");
                }
            }
        }
    }
}