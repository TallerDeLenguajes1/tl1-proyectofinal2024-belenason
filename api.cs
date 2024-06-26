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

        public string NombrePastelero()
        {
            string nombre = ObtenerNombrePasteleros().Result;
            return nombre;
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