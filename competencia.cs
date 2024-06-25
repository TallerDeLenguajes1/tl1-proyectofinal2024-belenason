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

        public Receta armadoAleatorioReceta()
        {
            string [] recetas = {"Torta Tres Leches", "Cheesecake", "Torta Red Velvet", "Tiramisu", "Carrot Cake", "SacheTorte", "Torta Selva Negra", "Lemon Pie", "Pavlova", "Banoffe", "Croquembuche", "Torta Rogel", "Chocotorta", "Tarta Tatin", "Victoria Sponge Cake", "Torta Balcarce", "Palo de Jacob", "Imperial Ruso", "Saint Honoré", "Torta Invertida"};
            var semilla = Environment.TickCount;
            var rnd = new Random();
            Receta recetaArmada = new Receta(recetas[rnd.Next(0, recetas.Length - 1)], rnd.Next(0,1), rnd.Next(0,1), rnd.Next(0,1), rnd.Next(0,1));
            return recetaArmada;
        }

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

        private void preparadoReceta(Pastelero pastelero, Juez juez)
        {
            Receta recetaAleatoria = armadoAleatorioReceta();
            string [] opcionesPaso1 = {"Azucar mascabo", "Azucar blanca"};
            string [] opcionesPaso2 = {"Picos firmes", "Picos suaves"};
            string [] opcionesPaso3 = {"Manteca", "Aceite"};
            string [] opcionesPaso4 = {"180 °C", "220 °C"};

            Menu menuPaso1 = new Menu("Selecciona el azucar a utlizar.", opcionesPaso1);
            int decisionPaso1 = menuPaso1.Correr();
            Menu menuPaso2 = new Menu("Selecciona el punto al que batir las claras.", opcionesPaso2);
            int decisionPaso2 = menuPaso2.Correr();
            Menu menuPaso3 = new Menu("Selecciona el ingrediente a utilizar.", opcionesPaso3);
            int decisionPaso3 = menuPaso3.Correr();
            Menu menuPaso4 = new Menu("Selecciona la temperatura a la que cocinar la torta.", opcionesPaso4);
            int decisionPaso4 = menuPaso4.Correr();
            float gradingPlato = puntajePlato(recetaAleatoria, decisionPaso1, decisionPaso2, decisionPaso3, decisionPaso4);
            float puntajeFinal = juez.calcularPuntuacion(pastelero.Creatividad, pastelero.Presentacion, pastelero.Rapidez, pastelero.Sabor, gradingPlato);
            Console.WriteLine($"{pastelero.Nombre} preparó {recetaAleatoria.NombreReceta} y recibió una puntuación de {puntajeFinal}");
        }

    }

    class Rondas
    {
        public static List<Pastelero> PrimeraRonda(List<Pastelero> pasteleros, List<Juez> jueces, Receta receta)
        {

        }
        public static List<Pastelero> SegundaRonda(List<Pastelero> pasteleros, List<Juez> jueces, Receta receta)
        {
            
        }
        public static List<Pastelero> RondaFinal(List<Pastelero> pasteleros, List<Juez> jueces, Receta receta)
        {
            
        }
    }
}