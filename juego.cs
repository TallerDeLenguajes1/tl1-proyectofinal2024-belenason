
namespace Juego
{
    class Game
    {
        public void partida()
        {
            List<Pastelero> pasteleros;
            List <Juez> jueces;
            fabricaDePersonajes fabrica = new fabricaDePersonajes();
            pasteleros = fabrica.crearPasteleros();
            jueces = fabrica.crearJueces();
            Interfaz interfaz = new Interfaz();
            Competencia competencia = new Competencia();
            interfaz.inicioJuego();
            Pastelero jugador = EleccionPastelero(pasteleros);
            pasteleros = competencia.PrimeraRonda(jugador, pasteleros, jueces);
            pasteleros = competencia.SegundaRonda(jugador, pasteleros, jueces);
            pasteleros = competencia.RondaFinal(jugador, pasteleros, jueces);

        }

        public Pastelero EleccionPastelero(List<Pastelero> pasteleros)
        {
            Pastelero elegido = null;
            int i = 1;
            Console.WriteLine("A continuacion se le mostraran los pasteleros disponibles. Lea bien sus caracteristicas y elija uno");
            foreach (Pastelero opcionPastelero in pasteleros)
            {
                Console.WriteLine($"Pastelero {i}:");
                opcionPastelero.mostrarInfoPastelero();
                i++;
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
            Console.Clear();
            string [] opciones = {"Pastelero creativo ", "Pastelero especializado en decoracion", "Pastelero rapido", "Pastelero especializado en sabores"};
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
                    elegido = pasteleros[4];
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