namespace Juego
{
    public class Receta
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
        public Receta(string nombre, string [] preguntas, string [][] opciones, int p1, int p2, int p3, int p4)
        {
            NombreReceta = nombre;
            PreguntaPreparacion = preguntas;
            OpcionesPasos = opciones;
            Paso1 = p1;
            Paso2 = p2;
            Paso3 = p3;
            Paso4 = p4;
        }


        public static List<Receta> SeleccionDeRecetas() //Armamos una lista con recetas
        {
            List<Receta> ListaDeRecetas = new List<Receta>
            {
                new Receta("Tiramisu", new string[] {"Cual es el queso principal que se utiliza en la preparación del tiramisu?", "Que tipo de licor se usa tradicionalmente en el tiramisu?", "Como se debe preparar el café para el tiramisu?", "Cuanto tiempo debe refrigerarse el tiramisu antes de servirlo?"} , new string [][] {new string []{"Ricotta", "Mascarpone"}, new string []{"Amaretto", "Rhum"}, new string []{"Fuerte y enfriado", "Suave y caliente"}, new string []{"2 horas", "4 horas"}}, 1, 0, 0, 1),
                new Receta("Macarons", new string[] {"Que tipo de harina se utiliza para hacer macarons?", "Cuál es el punto clave para obtener la textura adecuada en los macarons?", "Qué tipo de merengue se utiliza en la elaboración de macarons?", "Cual es el indicador de que los macarons estan listos para hornear?"} , new string [][] {new string []{"Harina de trigo", "Harina de almendra"}, new string []{"Hornear a alta temperatura", "Dejar secar la masa antes de hornear"}, new string []{"Merengue frances", "Merengue italiano"}, new string []{"La superficie se seca y no se pega al tacto", "La masa se vuelve brillante"}}, 1, 1, 1, 0),
                new Receta("Cheesecake", new string[] {"Cuál es el ingrediente principal de la base del cheesecake?", "Cual es la mejor forma de evitar que se agriete un cheesecake durante la coccion?", "Que tipo de queso se usa tradicionalmente en un cheesecake?", "Que se debe hacer con el cheesecake después de sacarlo del horno y dejarlo enfriar a temperartura ambiente?"} , new string [][] {new string []{"Bizcocho", "Galletas trituradas"}, new string []{"Cocer a banio Maria", "Cocer a alta temperatura"}, new string []{"Queso crema", "Queso Ricotta"}, new string []{"Servir inmediatamente", "Refrigerar antes de servir"}}, 1, 0, 0, 1),
                new Receta("Creme brulee", new string[] {"Que se utiliza para caramelizar la parte superior de una creme brulee?", "Cual es la consistencia adecuada de una creme brulee después de hornearla?", "Qué tipo de azucar se utiliza para caramelizar la parte superior de una crème brulee?", "A que temperatura se debe hornear una creme brulee?"} , new string [][] {new string []{"Horno", "Soplete de cocina"}, new string []{"Firme pero ligeramente temblorosa en el centro", "Totalmente firme"}, new string []{"Azucar glas", "Azucar granulada"}, new string []{"220°C", "150°C"}}, 1, 0, 1, 1),
                new Receta("Soufflé de chocolate", new string[] {"Qué es esencial para que un soufflé de chocolate suba correctamente?", "Cuándo se debe servir un soufflé de chocolate?", "Cuál es el recipiente más adecuado para hornear un soufflé de chocolate?", "Qué se debe hacer con los bordes del ramekin antes de verter la mezcla del soufflé?"} , new string [][] {new string []{"Agregar levadura", "Batir bien las claras de huevo"}, new string []{"Después de enfriar", "Inmediatamente después de sacarlo del horno"}, new string []{"Ramekin", "Molde desmontable"}, new string []{"Engrasarlos con manteca", "Engrasarlos y espolvorearlos con azucar"}}, 1, 1, 0, 1),
                new Receta("Pavlova", new string[] {"Cual es el ingrediente principal de la base de una pavlova?", "Cómo se consigue la textura crujiente por fuera y suave por dentro de una pavlova?", "Qué se usa comúnmente para decorar una pavlova?", "Qué tipo de azúcar es preferible para hacer pavlova?"} , new string [][] {new string []{"Claras de huevo", "Yemas de huevo"}, new string []{"Horneando a baja temperatura y dejando enfriar en el horno", "Horneando a alta temperatura y enfriando rápidamente"}, new string []{"Frutas frescas y crema chantilly", "Chocolate rallado y frutos secos"}, new string []{"Azúcar moreno", "Azúcar glas"}}, 0, 0, 0, 1),
                new Receta("Profiteroles", new string[] {"Que tipo de masa se utiliza para hacer profiteroles?", "Cómo se rellenan tradicionalmente los profiteroles?", "Qué se suele utilizar como cobertura para los profiteroles?", "Cómo se debe hornear la masa choux para que los profiteroles queden huecos por dentro?"} , new string [][] {new string []{"Masa choux", "Masa quebrada"}, new string []{"Con mermelada", "Con crema pastelera"}, new string []{"Chocolate fundido", "Azucar glas"}, new string []{"Hornear a alta temperatura primero y luego bajar la temperatura", "Hornear a baja temperatura y luego subir la temperatura"}}, 0, 1, 0, 0),
                new Receta("Brownies", new string[] {"Que ingrediente le da a los brownies su textura húmeda y densa?", "Cuál es el tipo de chocolate más adecuado para hacer brownies?", "Cuál es la señal de que los brownies están listos para sacarlos del horno?", "Qué se suele agregar a la mezcla de brownies para variar su sabor y textura?"} , new string [][] {new string []{"Manteca", "Polvo de hornear"}, new string []{"Chocolate amargo", "Chocolate con leche"}, new string []{"Los bordes se separan del molde y el centro está aún ligeramente húmedo", "El centro está completamente seco"}, new string []{"Crema batida", "Nueces"}}, 0, 0, 0, 1),
                new Receta("Tarta Tatin", new string[] {"Que tipo de manzanas se utilizan comúnmente para hacer una tarta Tatin?", "Cuál es la técnica clave para preparar la tarta Tatin?", "Qué tipo de masa se utiliza para cubrir la tarta Tatin?", "Cómo se sirve tradicionalmente la tarta Tatin?"} , new string [][] {new string []{"Manzanas Golden", "Manzanas Granny Smith"}, new string []{"Caramelizar las manzanas antes de hornear", "Cocinar las manzanas junto con la masa"}, new string []{"Masa choux", "Masa quebrada"}, new string []{"Caliente con crema o helado", "Fria con fruta fresca"}}, 1, 0, 1, 0),
                new Receta("Eclairs", new string[] {"Que tipo de masa se utiliza para hacer eclairs?", "Qué se utiliza comúnmente para rellenar éclairs?", "Cuál es la cobertura tradicional de los éclairs?", "Qué se debe hacer con la masa choux antes de hornearla para hacer éclairs?"} , new string [][] {new string []{"Masa choux", "Masa quebrada"}, new string []{"Crema pastelera", "Mermelada"}, new string []{"Glaseado de chocolate", "Azucar glas"}, new string []{"Enfriarla en el refrigerador", "Formar los éclairs y hornear inmediatamente"}}, 0, 0, 0, 1)
            };
            HistorialJson.GuardarRecetas(ListaDeRecetas);
            return ListaDeRecetas;
        }

        public static Receta SeleccionadorAleatorioReceta() //Funcion que selecciona de forma aleatoria las recetas
        {
            Random rnd = new Random();
            int index = rnd.Next(SeleccionDeRecetas().Count);
            return SeleccionDeRecetas()[index];
        }
    }

    class Competencia
    {

        //Función que recibe la receta generada aleatoriamente y los pasos seleccionados ya sea por el jugador o al azar, y calcula el puntaje en relacion a como se hizo el plato
        public float PuntajePlato(Receta receta, int eleccionPaso1, int eleccionPaso2, int eleccionPaso3, int eleccionPaso4)
        {
            float puntaje = 0;
            if (eleccionPaso1 == receta.Paso1)
            {
                puntaje = (float)(puntaje + 2.5);
            }
            if (eleccionPaso2 == receta.Paso2)
            {
                puntaje = (float)(puntaje + 2.5);
            }
            if (eleccionPaso3 == receta.Paso3)
            {
                puntaje = (float)(puntaje + 2.5);
            }
            if (eleccionPaso4 == receta.Paso4)
            {
                puntaje = (float)(puntaje + 2.5);
            }
            return puntaje;
        }

        //Funcion que recibe el jugador, la lista de pasteleros, y el juez que se ha asignado. Genera una receta aleatoriamente, y en caso de que el jugador aun no haya perdido, le permite decidir como preparar el postre;
        public void PreparadoReceta(Pastelero jugador, Juez juez, List<Pastelero> pasteleros)
        {
            var semilla = Environment.TickCount;
            var rnd = new Random();
            Receta recetaAleatoria = Receta.SeleccionadorAleatorioReceta();
            Console.WriteLine($"El postre a preparar es: {recetaAleatoria.NombreReceta}");
            float gradingPlato;
            if (pasteleros.Contains(jugador))
            {
                Console.WriteLine("\nA continuacion debera tomar tomar decisiones sobre el preparado del postre.");
                Console.ReadKey();
                Menu menuPaso1 = new Menu(recetaAleatoria.PreguntaPreparacion[0], recetaAleatoria.OpcionesPasos[0]);
                int decisionPaso1 = menuPaso1.Correr();
                if (recetaAleatoria.Paso1 == decisionPaso1)
                {
                    Console.WriteLine("Respuesta correcta.");
                } else {
                    Console.WriteLine("Respuesta incorrecta.");
                }
                Console.ReadKey();
                Menu menuPaso2 = new Menu(recetaAleatoria.PreguntaPreparacion[1], recetaAleatoria.OpcionesPasos[1]);
                int decisionPaso2 = menuPaso2.Correr();
                if (recetaAleatoria.Paso2 == decisionPaso2)
                {
                    Console.WriteLine("Respuesta correcta.");
                } else {
                    Console.WriteLine("Respuesta incorrecta.");
                }
                Console.ReadKey();
                Menu menuPaso3 = new Menu(recetaAleatoria.PreguntaPreparacion[2], recetaAleatoria.OpcionesPasos[2]);
                int decisionPaso3 = menuPaso3.Correr();
                if (recetaAleatoria.Paso3 == decisionPaso3)
                {
                    Console.WriteLine("Respuesta correcta.");
                } else {
                    Console.WriteLine("Respuesta incorrecta.");
                }
                Console.ReadKey();
                Menu menuPaso4 = new Menu(recetaAleatoria.PreguntaPreparacion[3], recetaAleatoria.OpcionesPasos[3]);
                int decisionPaso4 = menuPaso4.Correr();
                if (recetaAleatoria.Paso4 == decisionPaso4)
                {
                    Console.WriteLine("Respuesta correcta.");
                } else {
                    Console.WriteLine("Respuesta incorrecta.");
                }
                Console.ReadKey();
                gradingPlato = PuntajePlato(recetaAleatoria, decisionPaso1, decisionPaso2, decisionPaso3, decisionPaso4);
                jugador.PuntuacionUltimaRonda = juez.CalcularPuntuacion(jugador.Creatividad, jugador.Presentacion, jugador.Rapidez, jugador.Sabor, gradingPlato);
            } else
            {
                Console.ReadKey();
            }
            Console.Clear();
            Animaciones.animar();
            Console.Clear();
            Console.WriteLine($"Veamos como les fue a nuestros pasteleros en la preparacion de {recetaAleatoria.NombreReceta}");
            if (pasteleros.Contains(jugador))
            {
                Console.WriteLine($"\nRecibiste una puntacion de {jugador.PuntuacionUltimaRonda}.\n");
            }
            foreach (var rival in pasteleros) //Este foreach hace que cada pastelero que no es el jugador haga decisiones al azar y calcula la puntuacion de estos
            {
                if (rival != jugador)
                {
                    gradingPlato = PuntajePlato(recetaAleatoria, rnd.Next(0, 2), rnd.Next(0, 2), rnd.Next(0, 2), rnd.Next(0, 2));
                    rival.PuntuacionUltimaRonda = juez.CalcularPuntuacion(rival.Creatividad, rival.Presentacion, rival.Presentacion, rival.Rapidez, gradingPlato);  
                    Console.WriteLine($"{rival.Nombre} recibió una puntuación de {rival.PuntuacionUltimaRonda}");
                }
            }
        }

        //Esta función se fija quien tiene la puntuación más baja y lo elimina. 
        public Pastelero eliminarPasteleroPuntuacionMasBaja(List <Pastelero> pasteleros)
        {
            Pastelero pasteleroEliminado = null;
            float menorPuntuacion = float.MaxValue;
            foreach (var pastelero in pasteleros)
            {
                if (pastelero.PuntuacionUltimaRonda < menorPuntuacion)
                {
                    menorPuntuacion = pastelero.PuntuacionUltimaRonda;
                    pasteleroEliminado = pastelero;
                }
            }
            return pasteleroEliminado;
        }
        public List<Pastelero> PrimeraRonda(Pastelero jugador, List<Pastelero> pasteleros, List<Juez> jueces)
        {
            var semilla = Environment.TickCount;
            var rnd = new Random();
            Juez juezElegido = jueces[rnd.Next(0, jueces.Count)];
            Console.ForegroundColor = ConsoleColor.Red;

            string oracion = "𝔹𝕚𝕖𝕟𝕧𝕖𝕟𝕚𝕕𝕠𝕤 𝕒 𝕝𝕒 𝕡𝕣𝕚𝕞𝕖𝕣𝕒 𝕣𝕠𝕟𝕕𝕒";
            Interfaz.escribirConSuspenso(oracion);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nEn esta ronda se enfrentaran cuatro pasteleros.");
            Console.WriteLine($"El juez asignado es: {juezElegido.Nombre}");
            PreparadoReceta(jugador, juezElegido, pasteleros);
            Pastelero eliminado = eliminarPasteleroPuntuacionMasBaja(pasteleros);
            Interfaz.escribirConSuspenso($"\nEl pastelero eliminado es {eliminado.Nombre}");
            if (eliminado == jugador)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nHAZ PERDIDO\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Ahora simplemente podras observar el resto de la competencia.");
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar a la siguiente ronda.");
            Console.ReadKey();
            Console.Clear();
            pasteleros.Remove(eliminado);
            return pasteleros;
        }
        public List<Pastelero> SegundaRonda(Pastelero jugador, List<Pastelero> pasteleros, List<Juez> jueces)
        {
            var semilla = Environment.TickCount;
            var rnd = new Random();
            Juez juezElegido = jueces[rnd.Next(0, jueces.Count)];
            Console.ForegroundColor = ConsoleColor.Red;
            string oracion = "𝔹𝕚𝕖𝕟𝕧𝕖𝕟𝕚𝕕𝕠𝕤 𝕒 𝕝𝕒 𝕤𝕖𝕘𝕦𝕟𝕕𝕒 𝕣𝕠𝕟𝕕𝕒";
            Interfaz.escribirConSuspenso(oracion);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nEn esta ronda se enfrentaran tres pasteleros.");
            Console.WriteLine($"El juez asignado es: {juezElegido.Nombre}");
            PreparadoReceta(jugador, juezElegido, pasteleros);
            Pastelero eliminado = eliminarPasteleroPuntuacionMasBaja(pasteleros);
            Interfaz.escribirConSuspenso($"\nEl pastelero eliminado es {eliminado.Nombre}");
            pasteleros.Remove(eliminado);
            if (eliminado == jugador)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nHAZ PERDIDO\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Ahora simplemente podras observar el resto de la competencia.");
            }
            Console.WriteLine("Presione cualquier tecla para continuar a la siguiente ronda.");
            Console.ReadKey();
            Console.Clear();
            return pasteleros;
        }
        public List<Pastelero> RondaFinal(Pastelero jugador, List<Pastelero> pasteleros, List<Juez> jueces)
        {
            var semilla = Environment.TickCount;
            var rnd = new Random();
            Juez juezElegido = jueces[rnd.Next(0, jueces.Count)];
            Console.ForegroundColor = ConsoleColor.Red;
            string oracion = "𝔹𝕚𝕖𝕟𝕧𝕖𝕟𝕚𝕕𝕠𝕤 𝕒 𝕝𝕒 𝕗𝕚𝕟𝕒𝕝 𝕕𝕖 𝔹𝕒𝕜𝕖𝕆𝕗𝕗 𝔸𝕣𝕘𝕖𝕟𝕥𝕚𝕟𝕒";
            Interfaz.escribirConSuspenso(oracion);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nEn esta ronda se enfrentaran nuestros finalistas.");
            Console.WriteLine($"El juez asignado es: {juezElegido.Nombre}");
            PreparadoReceta(jugador, juezElegido, pasteleros);
            Pastelero eliminado = eliminarPasteleroPuntuacionMasBaja(pasteleros);
            Pastelero ganador = null;
            pasteleros.Remove(eliminado);

            foreach (var pastelero in pasteleros)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Interfaz.escribirConSuspenso($"\nEl GANADOR de Bake Off Argentina es {pastelero.Nombre}");
                Console.ForegroundColor = ConsoleColor.White;
                if (eliminado == jugador)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nHAZ PERDIDO.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (pastelero == jugador)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nFELICIDADES! HAZ GANADO.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                ganador = pastelero;
            }
            HistorialJson.GuardarGanador(ganador);
            return pasteleros;  
        }
        public static Pastelero EleccionPastelero(List<Pastelero> pasteleros)
        {
            Console.Clear();
            Pastelero elegido = null;
            int i = 0;
            Console.WriteLine("A continuacion se le mostraran los pasteleros disponibles. Lea bien sus caracteristicas y elija uno");
            string [] opciones = {"Pastelero creativo: ", "Pastelero especializado en decoracion: ", "Pastelero rapido: ", "Pastelero especializado en sabores: "};

            foreach (Pastelero opcionPastelero in pasteleros)
            {
                opciones[i] = opciones[i] + $"{opcionPastelero.Nombre}";
                i++;
                Console.WriteLine($"Pastelero {i}:");
                opcionPastelero.MostrarInfoPastelero();
                Console.Write("\n");
            }
            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
            Console.Clear();
            string pregunta = "Seleccione su pastelero para esta ronda";
            Menu menu1 = new Menu(pregunta, opciones);
            int indiceSelecc = menu1.Correr();

            switch (indiceSelecc)
            {
                case 0:
                    elegido = pasteleros[0];
                    Console.WriteLine($"Se selecciono a {elegido.Nombre}");
                    break;
                case 1:
                    elegido = pasteleros[1];
                    Console.WriteLine($"Se selecciono a {elegido.Nombre}");
                    break;
                case 2:
                    elegido = pasteleros[2];
                    Console.WriteLine($"Se selecciono a {elegido.Nombre}");
                    break;
                case 3:
                    elegido = pasteleros[3];
                    Console.WriteLine($"Se selecciono a {elegido.Nombre}");
                    break;
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
            Console.Clear();
            return elegido;
        }
    }
}