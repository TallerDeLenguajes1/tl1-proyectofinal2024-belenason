using System.Text.Json;

namespace Juego
{
    class Receta
    {
        private string nombreReceta;
        private string [] preguntaPreparacion;
        private string [][] opcionesPasos;
        private int [] pasos;

        public string NombreReceta {get => nombreReceta; set => nombreReceta = value;}
        public string [] PreguntaPreparacion {get => preguntaPreparacion; set => preguntaPreparacion = value;}
        public string [][] OpcionesPasos {get => opcionesPasos; set => opcionesPasos = value;}
        public int [] Pasos {get => pasos; set => pasos = value;}
        public Receta(string nombreReceta, string [] preguntaPreparacion, string [][] opcionesPasos, int [] pasos)
        {
            NombreReceta = nombreReceta;
            PreguntaPreparacion = preguntaPreparacion;
            OpcionesPasos = opcionesPasos;
            Pasos = pasos;
        }

        /// <summary>
        /// Guarda en un archivo RecetasJson una receta.
        /// </summary>
        /// <param name="receta">Receta a guardar.</param>
        public static void GuardarRecetaEnJson(Receta receta)
        {
            List<Receta> ListaDeRecetas = LeerRecetasDelJson();
            ListaDeRecetas.Add(receta);
            string jsonRecetas= JsonSerializer.Serialize(ListaDeRecetas);
            File.WriteAllText("data/RecetasJson.json", jsonRecetas);
        }

        /// <summary>
        /// Lee las recetas almacenadas en el archivo RecetasJson.json.
        /// </summary>
        private static List<Receta> LeerRecetasDelJson()
        {
            try
            {
                string jsonHistorial = File.ReadAllText("data/RecetasJson.json");
                return JsonSerializer.Deserialize<List<Receta>>(jsonHistorial);

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ha ocurrido un error y el juego no puede continuar. Volviendo al menú de inicio...");
                Thread.Sleep(4000);
                Game.CorrerJuego();
                return null;
            }
        }

        public static Receta SeleccionadorAleatorioReceta() //Funcion que selecciona de forma aleatoria las recetas
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            if (LeerRecetasDelJson() != null)
            {
                int index = rnd.Next(LeerRecetasDelJson().Count);
                return LeerRecetasDelJson()[index];
            } else
            {
                return null;
            }
        }
    }
}