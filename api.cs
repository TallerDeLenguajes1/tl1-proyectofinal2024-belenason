using System.Text.Json;

namespace Juego
{
    public class Api
    {

        public static string [] NombresPasteleros()
        {
            string [] nombres = new string[4];
            for (int i = 0; i < 4; i++)
            {
                if (ArmarNombrePasteleroUsandoApi().Result != null)
                {
                    nombres[i] = ArmarNombrePasteleroUsandoApi().Result;
                } else
                {
                    nombres[i] = ObtenerNombreAlternativo();
                }
            }
            return nombres;
        }

        public static async Task<string> ArmarNombrePasteleroUsandoApi()
        {
            string url = "https://fakerapi.it/api/v1/users?_quantity=1&_gender=female";
            Root jsonResponse = await RealizarPedidoAsincronico(url);
            if (jsonResponse == null)
            {
                return null;
            } else
            {
                string nombre = jsonResponse.Data[0].Firstname;
                string apellido = jsonResponse.Data[0].Lastname;
                string nombrePastelero = $"{nombre} {apellido}";
                return nombrePastelero;
            }
        }

        static async Task<Root> RealizarPedidoAsincronico(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Root infoMujer = JsonSerializer.Deserialize<Root>(responseBody);
                return infoMujer;
            }
            catch
            {
                return null;
            }
        }

        private static string ObtenerNombreAlternativo()
        {
            string [] nombresAlternativos = ["Belén Ason", "Sofía Rodriguez del Busto", "Milena Salem", "Maia Naessens", "Sofia Blasco", "Valentina Espeche", "Valentina Sucar", "Lourdes Ason", "Marcela Alexia Lazarte", "Mora Bappé", "Naiara Vidal", "Rocio Lardies", "Constanza Puertas" ];
            var rand = new Random(Guid.NewGuid().GetHashCode());
            return nombresAlternativos[rand.Next(0, nombresAlternativos.Length)];
        }
    }
}