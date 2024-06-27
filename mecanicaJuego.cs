namespace Juego
{
    class Receta
    {
        private string nombreReceta;
        private int paso1;
        private int paso2;
        private int paso3;
        private int paso4;

        public string NombreReceta {get => nombreReceta; set => nombreReceta = value;}
        public int Paso1 {get => paso1; set => paso1 = value;}
        public int Paso2 {get => paso2; set => paso2 = value;}
        public int Paso3 {get => paso3; set => paso3 = value;}
        public int Paso4 {get => paso4; set => paso4 = value;}
        public Receta(string nombre, int p1, int p2, int p3, int p4)
        {
            NombreReceta = nombre;
            Paso1 = p1;
            Paso2 = p2;
            Paso3 = p3;
            Paso4 = p4;
        }
    }

    class Competencia
    {
        //Función que recibe la receta generada aleatoriamente y los pasos seleccionados ya sea por el jugador o al azar, y calcula el puntaje en relacion a como se hizo el plato
        public float puntajePlato(Receta receta, int eleccionPaso1, int eleccionPaso2, int eleccionPaso3, int eleccionPaso4)
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
        public void preparadoReceta(Pastelero jugador, Juez juez, List<Pastelero> pasteleros)
        {
            var semilla = Environment.TickCount;
            var rnd = new Random();
            string [] recetas = {"Torta Tres Leches", "Cheesecake", "Torta Red Velvet", "Tiramisu", "Carrot Cake", "SacheTorte", "Torta Selva Negra", "Lemon Pie", "Pavlova", "Banoffe", "Croquembuche", "Torta Rogel", "Chocotorta", "Tarta Tatin", "Victoria Sponge Cake", "Torta Balcarce", "Palo de Jacob", "Imperial Ruso", "Saint Honoré", "Torta Invertida", "Alfajores de maicena"};
            Receta recetaAleatoria = new Receta(recetas[rnd.Next(0, recetas.Length)], rnd.Next(0,2), rnd.Next(0,2), rnd.Next(0,2), rnd.Next(0,2));

            Console.WriteLine($"El postre a preparar es: {recetaAleatoria.NombreReceta}");
            string [] opcionesPaso1 = {"Azucar mascabo", "Azucar blanca"};
            string [] opcionesPaso2 = {"Picos firmes", "Picos suaves"};
            string [] opcionesPaso3 = {"Manteca", "Aceite"};
            string [] opcionesPaso4 = {"180 °C", "220 °C"};
            float gradingPlato;
            string decisionesJugador = "\nDecidiste ";
            if (pasteleros.Contains(jugador))
            {
                Console.WriteLine("\nA continuacion debera tomar tomar decisiones sobre el preparado del postre.");
                Console.ReadKey();
                Menu menuPaso1 = new Menu("Selecciona el azucar a utilizar.", opcionesPaso1);
                int decisionPaso1 = menuPaso1.Correr();
                Menu menuPaso2 = new Menu("Selecciona el punto al que batir las claras.", opcionesPaso2);
                int decisionPaso2 = menuPaso2.Correr();
                Menu menuPaso3 = new Menu("Selecciona el ingrediente a utilizar.", opcionesPaso3);
                int decisionPaso3 = menuPaso3.Correr();
                Menu menuPaso4 = new Menu("Selecciona la temperatura a la que cocinar la torta.", opcionesPaso4);
                int decisionPaso4 = menuPaso4.Correr();
                if (decisionPaso1 == 0) // Usamos estos if para ir armando una oración que diga como realizó él postre el usuario
                {
                    decisionesJugador = decisionesJugador + "usar el azucar mascabo, ";
                } else
                {
                    decisionesJugador = decisionesJugador + "usar el azucar blanca, ";
                }
                if (decisionPaso1 == 0)
                {
                    decisionesJugador = decisionesJugador + "batir las claras hasta obtener picos firmes, ";
                } else
                {
                    decisionesJugador = decisionesJugador + "batir las claras hasta obtener picos suaves, ";
                }
                if (decisionPaso1 == 0)
                {
                    decisionesJugador = decisionesJugador + "usar la manteca y";
                } else
                {
                    decisionesJugador = decisionesJugador + "usar el aceite y";
                }
                if (decisionPaso1 == 0)
                {
                    decisionesJugador = decisionesJugador + " cocinar el postre a 180 °C.";
                } else
                {
                    decisionesJugador = decisionesJugador + " cocinar el postre a 220 °C.";
                }
                gradingPlato = puntajePlato(recetaAleatoria, decisionPaso1, decisionPaso2, decisionPaso3, decisionPaso4);
                jugador.PuntuacionUltimaRonda = juez.calcularPuntuacion(jugador.Creatividad, jugador.Presentacion, jugador.Rapidez, jugador.Sabor, gradingPlato);
            } else
            {
                Console.ReadKey();
            }
            Console.Clear();
            Animaciones.animar();
            Console.Clear();
            Console.WriteLine($"Veamos como les fue a nuestros pasteleros en la preparacion de {recetaAleatoria.NombreReceta}");
            string preparadoCorrecto = "La correcta preparacion del postre consistia en "; //En este string guardamos la preparacion correcta del postre
            if (recetaAleatoria.Paso1 == 0)
            {
                preparadoCorrecto = preparadoCorrecto + "usar el azucar mascabo, ";
            } else
            {
                preparadoCorrecto = preparadoCorrecto + "usar el azucar blanca, ";
            }
            if (recetaAleatoria.Paso1 == 0)
            {
                preparadoCorrecto = preparadoCorrecto + "batir las claras hasta obtener picos firmes, ";
            } else
            {
                preparadoCorrecto = preparadoCorrecto + "batir las claras hasta obtener picos suaves, ";
            }
            if (recetaAleatoria.Paso1 == 0)
            {
                preparadoCorrecto = preparadoCorrecto + "utilizar la manteca y";
            } else
            {
                preparadoCorrecto = preparadoCorrecto + "utilizar el aceite y";
            }
            if (recetaAleatoria.Paso1 == 0)
            {
                preparadoCorrecto = preparadoCorrecto + " cocinar a 180°C.";
            } else
            {
                preparadoCorrecto = preparadoCorrecto + " cocinar a 220°C.";
            }
            Console.WriteLine(preparadoCorrecto);
            if (decisionesJugador !=  "\nDecidiste ")
            {
                Console.WriteLine(decisionesJugador);
                Console.WriteLine($"\nRecibiste una puntacion de {jugador.PuntuacionUltimaRonda}.\n");
            }
            foreach (var rival in pasteleros) //Este foreach hace que cada pastelero que no es el jugador haga decisiones al azar y calcula la puntuacion de estos
            {
                if (rival != jugador)
                {
                    gradingPlato = puntajePlato(recetaAleatoria, rnd.Next(0, 2), rnd.Next(0, 2), rnd.Next(0, 2), rnd.Next(0, 2));
                    rival.PuntuacionUltimaRonda = juez.calcularPuntuacion(rival.Creatividad, rival.Presentacion, rival.Presentacion, rival.Rapidez, gradingPlato);  
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
            Console.WriteLine("------BIENVENIDOS A LA PRIMERA RONDA------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("En esta ronda se enfrentaran cuatro pasteleros.");
            Console.WriteLine($"El juez asignado es: {juezElegido.Nombre}");
            preparadoReceta(jugador, juezElegido, pasteleros);
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
            Console.WriteLine("------BIENVENIDOS A LA SEGUNDA RONDA------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("En esta ronda se enfrentaran tres pasteleros.");
            Console.WriteLine($"El juez asignado es: {juezElegido.Nombre}");
            preparadoReceta(jugador, juezElegido, pasteleros);
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
            Console.WriteLine("BIENVENIDOS A LA RONDA FINAL");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("En esta ronda se enfrentaran dos pasteleros.");
            Console.WriteLine($"El juez asignado es: {juezElegido.Nombre}");
            preparadoReceta(jugador, juezElegido, pasteleros);
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
            Historial.GuardarEnHistorial(ganador);
            return pasteleros;  
        }
        public static bool VolverAJugar()
        {
            string [] opciones = {"Si", "No"};
            Menu pregunta = new Menu("Desea volver a jugar?", opciones);
            int respuesta = pregunta.Correr();
            if (respuesta == 0)
            {
                return true;
            } else
            {
                return false;
            }
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
                opcionPastelero.mostrarInfoPastelero();
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