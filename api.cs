using System.Text.Json;

namespace Juego
{
    public class Api
    {
        public async Task<string> ObtenerNombrePasteleros()
        {
            string url = "https://fakerapi.it/api/v1/users?_quantity=1&_gender=female";
            Root jsonResponse = await MakeRequestAsync(url);
            string nombre = jsonResponse.Data[0].Firstname;
            string apellido = jsonResponse.Data[0].Lastname;
            string nombrePastelero = $"{nombre} {apellido}";
            return nombrePastelero;
        }

        private string ObtenerNombreAlternativo()
        {
            string[] nombresAlternativos = { "Belén Ason", "Sofía Rodriguez del Busto", "Milena Salem", "Maia Naessens, Sofia Blasco, Valentina Espeche, Valentina Sucar, Lourdes Ason, Marcela Alexia Lazarte, Mora Bappé, Marie Curie, Naiara Vidal" };
            Random rand = new Random();
            return nombresAlternativos[rand.Next(nombresAlternativos.Length)];
        }

        public string [] NombresPasteleros()
        {
            string [] nombres = new string[4];
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    nombres[i] = ObtenerNombrePasteleros().Result;
                }
                catch
                {
                    nombres[i] = ObtenerNombreAlternativo();
                }
            }
            return nombres;
        }

        static async Task<Root> MakeRequestAsync(string url)
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
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud aquí
                Console.WriteLine($"Problemas de acceso a la API: {ex.Message}");
                return null;
            }
        }
    }
}