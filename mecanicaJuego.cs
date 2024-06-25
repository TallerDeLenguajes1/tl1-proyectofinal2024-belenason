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
            Console.WriteLine("\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
            Menu menuPaso1 = new Menu("Selecciona el azucar a utilizar.", opcionesPaso1);
            int decisionPaso1 = menuPaso1.Correr();
            Menu menuPaso2 = new Menu("Selecciona el punto al que batir las claras.", opcionesPaso2);
            int decisionPaso2 = menuPaso2.Correr();
            Menu menuPaso3 = new Menu("Selecciona el ingrediente a utilizar.", opcionesPaso3);
            int decisionPaso3 = menuPaso3.Correr();
            Menu menuPaso4 = new Menu("Selecciona la temperatura a la que cocinar la torta.", opcionesPaso4);
            int decisionPaso4 = menuPaso4.Correr();
            float gradingPlato = puntajePlato(recetaAleatoria, decisionPaso1, decisionPaso2, decisionPaso3, decisionPaso4);
            jugador.PuntuacionUltimaRonda = juez.calcularPuntuacion(jugador.Creatividad, jugador.Presentacion, jugador.Rapidez, jugador.Sabor, gradingPlato);
            foreach (var rival in pasteleros)
            {
                if (rival != jugador)
                {
                    gradingPlato = puntajePlato(recetaAleatoria, rnd.Next(0, 2), rnd.Next(0, 2), rnd.Next(0, 2), rnd.Next(0, 2));
                    rival.PuntuacionUltimaRonda = juez.calcularPuntuacion(rival.Creatividad, rival.Presentacion, rival.Presentacion, rival.Rapidez, gradingPlato);  
                }
                Console.WriteLine($"{rival.Nombre} preparó {recetaAleatoria.NombreReceta} y recibió una puntuación de {rival.PuntuacionUltimaRonda}");
            }
        }

    
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
            Console.WriteLine("BIENVENIDOS A LA PRIMERA RONDA");
            Console.WriteLine("En esta ronda se enfrentaran cuatro pasteleros.");
            Console.WriteLine($"El juez asignado es: {juezElegido.Nombre}");
            Console.WriteLine("\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
            preparadoReceta(jugador, juezElegido, pasteleros);
            Pastelero eliminado = eliminarPasteleroPuntuacionMasBaja(pasteleros);
            Console.WriteLine($"El pastelero eliminado es {eliminado.Nombre}");
            if (eliminado == jugador)
            {
                Console.WriteLine("HAZ PERDIDO");
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
            pasteleros.Remove(eliminado);
            return pasteleros;
        }
        public List<Pastelero> SegundaRonda(Pastelero jugador, List<Pastelero> pasteleros, List<Juez> jueces)
        {
            var semilla = Environment.TickCount;
            var rnd = new Random();
            Juez juezElegido = jueces[rnd.Next(0, jueces.Count)];
            Console.WriteLine("BIENVENIDOS A LA SEGUNDA RONDA");
            Console.WriteLine("En esta ronda se enfrentaran tres pasteleros.");
            Console.WriteLine($"El juez asignado es: {juezElegido.Nombre}");
            Console.WriteLine("\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
            preparadoReceta(jugador, juezElegido, pasteleros);
            Pastelero eliminado = eliminarPasteleroPuntuacionMasBaja(pasteleros);
            Console.WriteLine($"El pastelero eliminado es {eliminado.Nombre}");
            pasteleros.Remove(eliminado);
            if (eliminado == jugador)
            {
                Console.WriteLine("HAZ PERDIDO");
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
            return pasteleros;
        }
        public List<Pastelero> RondaFinal(Pastelero jugador, List<Pastelero> pasteleros, List<Juez> jueces)
        {
            var semilla = Environment.TickCount;
            var rnd = new Random();
            Juez juezElegido = jueces[rnd.Next(0, jueces.Count)];
            Console.WriteLine("BIENVENIDOS A LA RONDA FINAL");
            Console.WriteLine("En esta ronda se enfrentaran dos pasteleros.");
            Console.WriteLine($"El juez asignado es: {juezElegido.Nombre}");
            Console.WriteLine("\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
            preparadoReceta(jugador, juezElegido, pasteleros);
            Pastelero eliminado = eliminarPasteleroPuntuacionMasBaja(pasteleros);
            pasteleros.Remove(eliminado);
            if (eliminado == jugador)
            {
                Console.WriteLine("HAZ PERDIDO");
            }
            foreach (var pastelero in pasteleros)
            {
                Console.WriteLine($"El ganador de BakeOff es {pastelero}");
            }
            return pasteleros;  
        }
    }
}