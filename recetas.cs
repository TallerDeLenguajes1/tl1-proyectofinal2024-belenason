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
        /// Selecciona de forma aleatoria una receta entre las guardadas en RecetasJson.json.
        /// </summary>
        public static Receta SeleccionadorAleatorioReceta()
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            if (LeerRecetasDelJson() != null)
            {
                int index = rnd.Next(LeerRecetasDelJson().Count);
                return LeerRecetasDelJson()[index];
            } else
            {
                return null;
            }
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
                Game.MenuPrincipal();
                return null;
            }
        }
    }
}