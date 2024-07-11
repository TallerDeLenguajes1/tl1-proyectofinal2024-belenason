using System.Text.Json;

namespace Juego
{

    class Competencia
    {

        //Función que recibe la receta generada aleatoriamente y los pasos seleccionados ya sea por el jugador o al azar, y calcula el puntaje en relacion a como se hizo el plato
        public static float PuntuacionDecisionesReceta(Receta receta, int [] eleccionPasos)
        {
            float puntaje = 0;
            for (int i = 0; i < receta.Pasos.Length; i++)
            {
                if (eleccionPasos[i] == receta.Pasos[i])
                {
                    puntaje = (float)(puntaje + 2.5);
                }   
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
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            Receta recetaAleatoria = Receta.SeleccionadorAleatorioReceta();
            Interfaz.PresentadorHablando([$"El postre a preparar es: {recetaAleatoria.NombreReceta}"], false);

            if (pasteleros.Contains(jugador))
            {
                Console.Clear();
                Console.WriteLine("A continuación deberá tomar decisiones sobre el preparado del postre.");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
                float gradingPlato = ProcesoDecisionJugador(recetaAleatoria);
                jugador.PuntuacionUltimaRonda = juez.CalcularPuntuacion(jugador.Creatividad, jugador.Presentacion, jugador.Rapidez, jugador.Sabor, gradingPlato);
            }
            else
            {
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }

            Console.Clear();
            Animaciones.Animar(1, 5);
            Console.Clear();

            Interfaz.PresentadorHablando([$"Veamos como les fue a nuestros pasteleros en la preparación de {recetaAleatoria.NombreReceta}"], false);
            MostrarResultadosPasteleros(pasteleros, jugador, juez, recetaAleatoria, rnd);
        }

        private float ProcesoDecisionJugador(Receta receta)
        {
            int[] decisiones = new int[4];

            for (int i = 0; i < 4; i++)
            {
                Menu menuPaso = new Menu(new string[] { receta.PreguntaPreparacion[i] }, receta.OpcionesPasos[i]);
                decisiones[i] = menuPaso.Correr(false, "White");
                CorregirRespuesta(receta.Pasos[i], decisiones[i]);
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }

            return PuntuacionDecisionesReceta(receta, decisiones);
        }

        private void MostrarResultadosPasteleros(List<Pastelero> pasteleros, Pastelero jugador, Juez juez, Receta receta, Random rnd)
        {
            foreach (var rival in pasteleros)
            {
                if (rival == jugador)
                {
                    Interfaz.PresentadorHablando([$"Recibiste una puntuación de {jugador.PuntuacionUltimaRonda}."], false);
                }
                else
                {
                    float gradingPlato = PuntuacionDecisionesReceta(receta, [rnd.Next(0, 2), rnd.Next(0, 2), rnd.Next(0, 2), rnd.Next(0, 2)]);
                    rival.PuntuacionUltimaRonda = juez.CalcularPuntuacion(rival.Creatividad, rival.Presentacion, rival.Presentacion, rival.Rapidez, gradingPlato);
                    Interfaz.PresentadorHablando([$"{rival.Nombre} recibió una puntuación de {rival.PuntuacionUltimaRonda}"], false);
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
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            Interfaz.PresentadorHablando(["Oh! Ha ocurrido un empate entre nuestros pasteleros.", "No les vamos a mentir. No pensamos que esto fuera a pasar, así que no tenemos una forma planeada de resolver el empate...", "No nos queda otra que seleccionar el pastelero eliminado tirando una moneda."], false);
            Pastelero pasteleroEliminado = pastelerosEmpatados[rnd.Next(0, pastelerosEmpatados.Count)];
            return pasteleroEliminado;
        }
        public List<Pastelero> PrimeraRonda(Pastelero jugador, List<Pastelero> pasteleros, List<Juez> jueces)
        {
            Interfaz.MostrarTextoAColorCentrado([$"  ___         _                                                      _        ", """ | _ \  _ _  (_)  _ __    ___   _ _   __ _     _ _   ___   _ _    __| |  __ _ """, """ |  _/ | '_| | | | '  \  / -_) | '_| / _` |   | '_| / _ \ | ' \  / _` | / _` |""", """ |_|   |_|   |_| |_|_|_| \___| |_|   \__,_|   |_|   \___/ |_||_| \__,_| \__,_|"""], "Red");
            Thread.Sleep(3000);
            Console.Clear();
            return EjecutarRonda(jugador, pasteleros, jueces, "Bienvenidos a la primera ronda!!!", 4, false);
        }

        public List<Pastelero> SegundaRonda(Pastelero jugador, List<Pastelero> pasteleros, List<Juez> jueces)
        {
            Interfaz.MostrarTextoAColorCentrado([$"  ___                                 _                                  _        ", """ / __|  ___   __ _   _  _   _ _    __| |  __ _     _ _   ___   _ _    __| |  __ _ """, """ \__ \ / -_) / _` | | || | | ' \  / _` | / _` |   | '_| / _ \ | ' \  / _` | / _` |""", """ |___/ \___| \__, |  \_,_| |_||_| \__,_| \__,_|   |_|   \___/ |_||_| \__,_| \__,_|""", """             |___/                                                                """], "Red");
            Thread.Sleep(3000);
            Console.Clear();
            return EjecutarRonda(jugador, pasteleros, jueces, "Bienvenidos a la segunda ronda!!!", 3, false);
        }

        public List<Pastelero> RondaFinal(Pastelero jugador, List<Pastelero> pasteleros, List<Juez> jueces)
        {
            Interfaz.MostrarTextoAColorCentrado([$"  ___                   _             __   _                 _ ", """ | _ \  ___   _ _    __| |  __ _     / _| (_)  _ _    __ _  | |""", """ |   / / _ \ | ' \  / _` | / _` |   |  _| | | | ' \  / _` | | |""", """ |_|_\ \___/ |_||_| \__,_| \__,_|   |_|   |_| |_||_| \__,_| |_|"""], "Red");
            Thread.Sleep(3000);
            Console.Clear();
            return EjecutarRonda(jugador, pasteleros, jueces, "Bienvenidos a la RONDA FINAL!!!", 2, true);
        }

        private List<Pastelero> EjecutarRonda(Pastelero jugador, List<Pastelero> pasteleros, List<Juez> jueces, string mensaje, int cantidadPasteleros, bool esFinal)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            Juez juezElegido = jueces[rnd.Next(0, jueces.Count)];
            Interfaz.PresentadorHablando([mensaje, $"En esta ronda se enfrentaran {cantidadPasteleros} pasteleros.", $"El juez asignado es: {juezElegido.Nombre}"], false);
            PreparadoReceta(jugador, juezElegido, pasteleros);
            Pastelero eliminado = EliminarPasteleroPuntuacionMasBaja(pasteleros);
            pasteleros.Remove(eliminado);

            if (!esFinal)
            {
                Interfaz.PresentadorHablando([$"El pastelero eliminado es {eliminado.Nombre}"], true);
                if (eliminado == jugador)
                {
                    Interfaz.PresentadorHablando(["HAZ PERDIDO", "Ahora simplemente podras observar el resto de la competencia."], false);
                    Animaciones.Animar(2, 1);
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar a la siguiente ronda.");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Pastelero ganador = pasteleros[0];
                Interfaz.PresentadorHablando([$"El GANADOR de Bake Off Argentina es {ganador.Nombre}"], true);
                if (eliminado == jugador)
                {
                    Interfaz.PresentadorHablando(["HAZ PERDIDO.\n"], false);
                    Animaciones.Animar(2, 1);

                }
                if (ganador == jugador)
                {
                    Interfaz.PresentadorHablando(["FELICIDADES! HAZ GANADO."], false);
                    Console.Clear();
                    Interfaz.MostrarTextoAColorCentrado(Interfaz.ObtenerAsciiTxt("trofeo.txt"), "White");
                }

                HistorialJson.GuardarGanador(ganador);
            }

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