using System.Text.Json;

namespace Juego
{
    class Receta
    {
        private string nombreReceta;
        private string [] preguntaPreparacion;
        private string [][] opcionesPasos;
        private int paso1;
        private int paso2;
        private int paso3;
        private int paso4;

        public string NombreReceta {get => nombreReceta; set => nombreReceta = value;}
        public string [] PreguntaPreparacion {get => preguntaPreparacion; set => preguntaPreparacion = value;}
        public string [][] OpcionesPasos {get => opcionesPasos; set => opcionesPasos = value;}
        public int Paso1 {get => paso1; set => paso1 = value;}
        public int Paso2 {get => paso2; set => paso2 = value;}
        public int Paso3 {get => paso3; set => paso3 = value;}
        public int Paso4 {get => paso4; set => paso4 = value;}
        public Receta(string nombreReceta, string [] preguntaPreparacion, string [][] opcionesPasos, int paso1, int paso2, int paso3, int paso4)
        {
            NombreReceta = nombreReceta;
            PreguntaPreparacion = preguntaPreparacion;
            OpcionesPasos = opcionesPasos;
            Paso1 = paso1;
            Paso2 = paso2;
            Paso3 = paso3;
            Paso4 = paso4;
        }

        public static void GuardarRecetaEnJson(Receta receta)
        {
            List<Receta> ListaDeRecetas = LeerRecetasDelJson();
            ListaDeRecetas.Add(receta);
            string jsonRecetas= JsonSerializer.Serialize(ListaDeRecetas);
            File.WriteAllText("RecetasJson.json", jsonRecetas);
        }

        private static List<Receta> LeerRecetasDelJson()
        {
            try
            {
                string jsonHistorial = File.ReadAllText("RecetasJson.json");
                return JsonSerializer.Deserialize<List<Receta>>(jsonHistorial);

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ha ocurrido un error con la lista de recetas.");
                return null;
            }
        }

        public static Receta SeleccionadorAleatorioReceta() //Funcion que selecciona de forma aleatoria las recetas
        {
            Random rnd = new Random();
            int index = rnd.Next(LeerRecetasDelJson().Count);
            return LeerRecetasDelJson()[index];
        }
    }
}