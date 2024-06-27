using Juego;
Interfaz.inicioJuego();
do
{
    List<Pastelero> pasteleros;
    List <Juez> jueces;
    fabricaDePersonajes fabrica = new fabricaDePersonajes();
    pasteleros = fabrica.crearPasteleros();
    jueces = fabrica.crearJueces();
    Competencia competencia = new Competencia();
    Pastelero jugador = Competencia.EleccionPastelero(pasteleros);
    pasteleros = competencia.PrimeraRonda(jugador, pasteleros, jueces);
    pasteleros = competencia.SegundaRonda(jugador, pasteleros, jueces);
    pasteleros = competencia.RondaFinal(jugador, pasteleros, jueces);
    Console.WriteLine("Presione una tecla para continuar");
    Console.ReadKey();
    Console.Clear();
    string [] opciones = {"Si", "No"};
    Menu pregunta = new Menu("Desea ver el historial de ganadores?", opciones);
    int respuesta = pregunta.Correr();
    if (respuesta == 0)
    {
        Historial.mostrarHistorial();
    }
} while (Competencia.VolverAJugar());


