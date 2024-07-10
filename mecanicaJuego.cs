using System.Text.Json;

namespace Juego
{

    class Competencia
    {

        //Función que recibe la receta generada aleatoriamente y los pasos seleccionados ya sea por el jugador o al azar, y calcula el puntaje en relacion a como se hizo el plato
        public static float PuntuacionDecisionesReceta(Receta receta, int eleccionPaso1, int eleccionPaso2, int eleccionPaso3, int eleccionPaso4)
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

        public void CorregirRespuesta(int respuestaCorrecta, int respuestaDada)
        {
            if (respuestaCorrecta == respuestaDada)
            {
                Console.WriteLine("Respuesta correcta.");
            } else
            {
                Console.WriteLine("Respuesta incorrecta");
            }
        }
        

        //Funcion que recibe el jugador, la lista de pasteleros, y el juez que se ha asignado. Genera una receta aleatoriamente, y en caso de que el jugador aun no haya perdido, le permite decidir como preparar el postre;
        public void PreparadoReceta(Pastelero jugador, Juez juez, List<Pastelero> pasteleros)
        {
            var rnd = new Random();
            Receta recetaAleatoria = Receta.SeleccionadorAleatorioReceta();
            Console.WriteLine($"El postre a preparar es: {recetaAleatoria.NombreReceta}");
            float gradingPlato;
            if (pasteleros.Contains(jugador))
            {
                Console.WriteLine("\nA continuacion debera tomar tomar decisiones sobre el preparado del postre.");
                Console.ReadKey();
                Menu menuPaso1 = new Menu([recetaAleatoria.PreguntaPreparacion[0]], recetaAleatoria.OpcionesPasos[0]);
                int decisionPaso1 = menuPaso1.Correr(false, "White");
                CorregirRespuesta(recetaAleatoria.Paso1, decisionPaso1);
                Console.ReadKey();
                Menu menuPaso2 = new Menu([recetaAleatoria.PreguntaPreparacion[1]], recetaAleatoria.OpcionesPasos[1]);
                int decisionPaso2 = menuPaso2.Correr(false, "White");
                CorregirRespuesta(recetaAleatoria.Paso2, decisionPaso2);
                Console.ReadKey();
                Menu menuPaso3 = new Menu([recetaAleatoria.PreguntaPreparacion[2]], recetaAleatoria.OpcionesPasos[2]);
                int decisionPaso3 = menuPaso3.Correr(false, "White");
                CorregirRespuesta(recetaAleatoria.Paso3, decisionPaso3);
                Console.ReadKey();
                Menu menuPaso4 = new Menu([recetaAleatoria.PreguntaPreparacion[3]], recetaAleatoria.OpcionesPasos[3]);
                int decisionPaso4 = menuPaso4.Correr(false, "White");
                CorregirRespuesta(recetaAleatoria.Paso4, decisionPaso4);
                Console.ReadKey();
                gradingPlato = PuntuacionDecisionesReceta(recetaAleatoria, decisionPaso1, decisionPaso2, decisionPaso3, decisionPaso4);
                jugador.PuntuacionUltimaRonda = juez.CalcularPuntuacion(jugador.Creatividad, jugador.Presentacion, jugador.Rapidez, jugador.Sabor, gradingPlato);
            } else
            {
                Console.ReadKey();
            }
            Console.Clear();
            Animaciones.Animar();
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
                    gradingPlato = PuntuacionDecisionesReceta(recetaAleatoria, rnd.Next(0, 2), rnd.Next(0, 2), rnd.Next(0, 2), rnd.Next(0, 2));
                    rival.PuntuacionUltimaRonda = juez.CalcularPuntuacion(rival.Creatividad, rival.Presentacion, rival.Presentacion, rival.Rapidez, gradingPlato);  
                    Console.WriteLine($"{rival.Nombre} recibió una puntuación de {rival.PuntuacionUltimaRonda}");
                }
            }
        }

        //Esta función se fija quien tiene la puntuación más baja y lo elimina. 
        public static Pastelero EliminarPasteleroPuntuacionMasBaja(List <Pastelero> pasteleros)
        {
            List<Pastelero> pastelerosEmpatados = new List<Pastelero>();
            float menorPuntuacion = float.MaxValue;
            foreach (var pastelero in pasteleros)
            {
                if (pastelero.PuntuacionUltimaRonda < menorPuntuacion)
                {
                    menorPuntuacion = pastelero.PuntuacionUltimaRonda;
                    pastelerosEmpatados.Clear(); // Borrar la lista ya que tenemos una nueva menor puntuación
                    pastelerosEmpatados.Add(pastelero);
                }
                else if (pastelero.PuntuacionUltimaRonda == menorPuntuacion)
                {
                    pastelerosEmpatados.Add(pastelero);
                }
            }
            Pastelero pasteleroEliminado;
            if (pastelerosEmpatados.Count > 1)
            {
                pasteleroEliminado = ResolverEmpate(pastelerosEmpatados);
            }
            else
            {
                pasteleroEliminado = pastelerosEmpatados[0];
            }

            return pasteleroEliminado;
        }

        public static Pastelero ResolverEmpate(List <Pastelero> pastelerosEmpatados)
        {
            var rnd = new Random();
            Console.WriteLine("Oh! Ha ocurrido un empate entre nuestros pasteleros.");
            Console.WriteLine("No les vamos a mentir. No pensamos que esto fuera a pasar, así que no tenemos una forma planeada de resolver el empate...");
            Console.WriteLine("No nos queda otra que seleccionar el pastelero eliminado tirando una moneda.");
            Pastelero pasteleroEliminado = pastelerosEmpatados[rnd.Next(0, pastelerosEmpatados.Count)];
            return pasteleroEliminado;
        }
        public List<Pastelero> PrimeraRonda(Pastelero jugador, List<Pastelero> pasteleros, List<Juez> jueces)
        {
            var semilla = Environment.TickCount;
            var rnd = new Random();
            Juez juezElegido = jueces[rnd.Next(0, jueces.Count)];
            Console.ForegroundColor = ConsoleColor.Red;

            string oracion = "𝔹𝕚𝕖𝕟𝕧𝕖𝕟𝕚𝕕𝕠𝕤 𝕒 𝕝𝕒 𝕡𝕣𝕚𝕞𝕖𝕣𝕒 𝕣𝕠𝕟𝕕𝕒";
            Interfaz.EscribirConSuspenso(oracion, false);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nEn esta ronda se enfrentaran cuatro pasteleros.");
            Console.WriteLine($"El juez asignado es: {juezElegido.Nombre}");
            PreparadoReceta(jugador, juezElegido, pasteleros);
            Pastelero eliminado = EliminarPasteleroPuntuacionMasBaja(pasteleros);
            Interfaz.EscribirConSuspenso($"\nEl pastelero eliminado es {eliminado.Nombre}", false);
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
            Interfaz.EscribirConSuspenso(oracion, false);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nEn esta ronda se enfrentaran tres pasteleros.");
            Console.WriteLine($"El juez asignado es: {juezElegido.Nombre}");
            PreparadoReceta(jugador, juezElegido, pasteleros);
            Pastelero eliminado = EliminarPasteleroPuntuacionMasBaja(pasteleros);
            Interfaz.EscribirConSuspenso($"\nEl pastelero eliminado es {eliminado.Nombre}", false);
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
            Interfaz.EscribirConSuspenso(oracion, false);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nEn esta ronda se enfrentaran nuestros finalistas.");
            Console.WriteLine($"El juez asignado es: {juezElegido.Nombre}");
            PreparadoReceta(jugador, juezElegido, pasteleros);
            Pastelero eliminado = EliminarPasteleroPuntuacionMasBaja(pasteleros);
            Pastelero ganador = null;
            pasteleros.Remove(eliminado);

            foreach (var pastelero in pasteleros)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Interfaz.EscribirConSuspenso($"\nEl GANADOR de Bake Off Argentina es {pastelero.Nombre}", false);
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
            Console.WriteLine("A continuacion se le mostraran los pasteleros disponibles. Cada uno tiene una especialización en la cual se asegura que sea bueno.");
            Console.WriteLine("Elija con cuidado. Recuerde que los pasteleros no elegidos serán sus rivales.");
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
            string [] pregunta = ["Seleccione su pastelero para esta ronda"];
            Menu menu1 = new Menu(pregunta, opciones);
            int indiceSelecc = menu1.Correr(false, "White");

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

    public class Game
    {
        public static void CorrerJuego()
        {
            string [] opciones = {"JUGAR", "Ver historial de ganadores", "Salir"};
            string[] asciiArtTitulo = Interfaz.ObtenerAsciiTxt("AsciiArtTitulo.txt");
            Menu MenuInicio = new Menu(asciiArtTitulo, opciones);
            int opcionSelecc = MenuInicio.Correr(true, "Red");
            switch (opcionSelecc)
            {
                case 0:
                    Console.Clear();
                    Interfaz.EscribirConSuspenso("Cargando...", true);
                    List<Pastelero> pasteleros;
                    List <Juez> jueces;
                    fabricaDePersonajes fabrica = new fabricaDePersonajes();
                    pasteleros = fabrica.CrearPasteleros();
                    jueces = fabrica.CrearJueces();
                    Competencia competencia = new Competencia();
                    Pastelero jugador = Competencia.EleccionPastelero(pasteleros);
                    pasteleros = competencia.PrimeraRonda(jugador, pasteleros, jueces);
                    pasteleros = competencia.SegundaRonda(jugador, pasteleros, jueces);
                    pasteleros = competencia.RondaFinal(jugador, pasteleros, jueces);
                    Console.WriteLine("\nPresione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    CorrerJuego();
                    break;
                case 1:
                    HistorialJson.MostrarHistorial();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Nos vemos!");
                    Thread.Sleep(2000); 
                    Console.Clear();
                    break;
            }
        }
    }
}