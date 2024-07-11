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

        public static void GuardarRecetaEnJson(Receta receta)
        {
            List<Receta> ListaDeRecetas = LeerRecetasDelJson();
            ListaDeRecetas.Add(receta);
            string jsonRecetas= JsonSerializer.Serialize(ListaDeRecetas);
            File.WriteAllText("RecetasJson.json", jsonRecetas);
        }

        /*public static void GuardarListaRecetaEnJson()
        {
            List<Receta> ListaDeRecetas = new List<Receta>
            {
                new Receta("Tiramisu", new string[] {"Cual es el queso principal que se utiliza en la preparación del tiramisu?", "Que tipo de licor se usa tradicionalmente en el tiramisu?", "Como se debe preparar el café para el tiramisu?", "Cuanto tiempo debe refrigerarse el tiramisu antes de servirlo?"} , new string [][] {new string []{"Ricotta", "Mascarpone"}, new string []{"Amaretto", "Rhum"}, new string []{"Fuerte y enfriado", "Suave y caliente"}, new string []{"2 horas", "4 horas"}}, [1, 0, 0, 1]),
                new Receta("Macarons", new string[] {"Que tipo de harina se utiliza para hacer macarons?", "Cuál es el punto clave para obtener la textura adecuada en los macarons?", "Qué tipo de merengue se utiliza en la elaboración de macarons?", "Cual es el indicador de que los macarons estan listos para hornear?"} , new string [][] {new string []{"Harina de trigo", "Harina de almendra"}, new string []{"Hornear a alta temperatura", "Dejar secar la masa antes de hornear"}, new string []{"Merengue frances", "Merengue italiano"}, new string []{"La superficie se seca y no se pega al tacto", "La masa se vuelve brillante"}}, [1, 1, 1, 0]),
                new Receta("Cheesecake", new string[] {"Cuál es el ingrediente principal de la base del cheesecake?", "Cual es la mejor forma de evitar que se agriete un cheesecake durante la coccion?", "Que tipo de queso se usa tradicionalmente en un cheesecake?", "Que se debe hacer con el cheesecake después de sacarlo del horno y dejarlo enfriar a temperartura ambiente?"} , new string [][] {new string []{"Bizcocho", "Galletas trituradas"}, new string []{"Cocer a banio Maria", "Cocer a alta temperatura"}, new string []{"Queso crema", "Queso Ricotta"}, new string []{"Servir inmediatamente", "Refrigerar antes de servir"}}, [1, 0, 0, 1]),
                new Receta("Creme brulee", new string[] {"Que se utiliza para caramelizar la parte superior de una creme brulee?", "Cual es la consistencia adecuada de una creme brulee después de hornearla?", "Qué tipo de azucar se utiliza para caramelizar la parte superior de una crème brulee?", "A que temperatura se debe hornear una creme brulee?"} , new string [][] {new string []{"Horno", "Soplete de cocina"}, new string []{"Firme pero ligeramente temblorosa en el centro", "Totalmente firme"}, new string []{"Azucar glas", "Azucar granulada"}, new string []{"220°C", "150°C"}}, [1, 0, 1, 1]),
                new Receta("Soufflé de chocolate", new string[] {"Qué es esencial para que un soufflé de chocolate suba correctamente?", "Cuándo se debe servir un soufflé de chocolate?", "Cuál es el recipiente más adecuado para hornear un soufflé de chocolate?", "Qué se debe hacer con los bordes del ramekin antes de verter la mezcla del soufflé?"} , new string [][] {new string []{"Agregar levadura", "Batir bien las claras de huevo"}, new string []{"Después de enfriar", "Inmediatamente después de sacarlo del horno"}, new string []{"Ramekin", "Molde desmontable"}, new string []{"Engrasarlos con manteca", "Engrasarlos y espolvorearlos con azucar"}}, [1, 1, 0, 1]),
                new Receta("Pavlova", new string[] {"Cual es el ingrediente principal de la base de una pavlova?", "Cómo se consigue la textura crujiente por fuera y suave por dentro de una pavlova?", "Qué se usa comúnmente para decorar una pavlova?", "Qué tipo de azúcar es preferible para hacer pavlova?"} , new string [][] {new string []{"Claras de huevo", "Yemas de huevo"}, new string []{"Horneando a baja temperatura y dejando enfriar en el horno", "Horneando a alta temperatura y enfriando rápidamente"}, new string []{"Frutas frescas y crema chantilly", "Chocolate rallado y frutos secos"}, new string []{"Azúcar moreno", "Azúcar glas"}}, [0, 0, 0, 1]),
                new Receta("Profiteroles", new string[] {"Que tipo de masa se utiliza para hacer profiteroles?", "Cómo se rellenan tradicionalmente los profiteroles?", "Qué se suele utilizar como cobertura para los profiteroles?", "Cómo se debe hornear la masa choux para que los profiteroles queden huecos por dentro?"} , new string [][] {new string []{"Masa choux", "Masa quebrada"}, new string []{"Con mermelada", "Con crema pastelera"}, new string []{"Chocolate fundido", "Azucar glas"}, new string []{"Hornear a alta temperatura primero y luego bajar la temperatura", "Hornear a baja temperatura y luego subir la temperatura"}}, [0, 1, 0, 0]),
                new Receta("Brownies", new string[] {"Que ingrediente le da a los brownies su textura húmeda y densa?", "Cuál es el tipo de chocolate más adecuado para hacer brownies?", "Cuál es la señal de que los brownies están listos para sacarlos del horno?", "Qué se suele agregar a la mezcla de brownies para variar su sabor y textura?"} , new string [][] {new string []{"Manteca", "Polvo de hornear"}, new string []{"Chocolate amargo", "Chocolate con leche"}, new string []{"Los bordes se separan del molde y el centro está aún ligeramente húmedo", "El centro está completamente seco"}, new string []{"Crema batida", "Nueces"}}, [0, 0, 0, 1]),
                new Receta("Eclairs", new string[] {"Que tipo de masa se utiliza para hacer eclairs?", "Qué se utiliza comúnmente para rellenar éclairs?", "Cuál es la cobertura tradicional de los éclairs?", "Qué se debe hacer con la masa choux antes de hornearla para hacer éclairs?"} , new string [][] {new string []{"Masa choux", "Masa quebrada"}, new string []{"Crema pastelera", "Mermelada"}, new string []{"Glaseado de chocolate", "Azucar glas"}, new string []{"Enfriarla en el refrigerador", "Formar los éclairs y hornear inmediatamente"}}, [0, 0, 0, 1]),
                new Receta("Tarta Tatin", new string[] {"Que tipo de manzanas se utilizan comúnmente para hacer una tarta Tatin?", "Cuál es la técnica clave para preparar la tarta Tatin?", "Qué tipo de masa se utiliza para cubrir la tarta Tatin?", "Cómo se sirve tradicionalmente la tarta Tatin?"} , new string [][] {new string []{"Manzanas Golden", "Manzanas Granny Smith"}, new string []{"Caramelizar las manzanas antes de hornear", "Cocinar las manzanas junto con la masa"}, new string []{"Masa choux", "Masa quebrada"}, new string []{"Caliente con crema o helado", "Fria con fruta fresca"}}, [1, 0, 1, 0])

            };
            string jsonRecetas= JsonSerializer.Serialize(ListaDeRecetas);
            File.WriteAllText("RecetasJson.json", jsonRecetas);
        }*/

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