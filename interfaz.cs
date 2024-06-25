using Juego;

public class Interfaz
{
    public void inicioJuego()
    {
        Console.CursorVisible = false;
        Console.Title = "BakeOff";
        Console.BackgroundColor = ConsoleColor.Black;
        Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        string[] asciiArtTitulo =
        {
            " ▄▄▄▄    ▄▄▄       ██ ▄█▀▓█████  ▒█████    █████▒ █████▒",
            "▓█████▄ ▒████▄     ██▄█▒ ▓█   ▀ ▒██▒  ██▒▓██   ▒▓██   ▒ ",
            "▒██▒ ▄██▒██  ▀█▄  ▓███▄░ ▒███   ▒██░  ██▒▒████ ░▒████ ░ ",
            "▒██░█▀  ░██▄▄▄▄██ ▓██ █▄ ▒▓█  ▄ ▒██   ██░░▓█▒  ░░▓█▒  ░ ",
            "░▓█  ▀█▓ ▓█   ▓██▒▒██▒ █▄░▒████▒░ ████▓▒░░▒█░   ░▒█░    ",
            "░▒▓███▀▒ ▒▒   ▓▒█░▒ ▒▒ ▓▒░░ ▒░ ░░ ▒░▒░▒░  ▒ ░    ▒ ░    ",
            "▒░▒   ░   ▒   ▒▒ ░░ ░▒ ▒░ ░ ░  ░  ░ ▒ ▒░  ░      ░      ",
            " ░    ░   ░   ▒   ░ ░░ ░    ░   ░ ░ ░ ▒   ░ ░    ░ ░    ",
            " ░            ░  ░░  ░      ░  ░    ░ ░                 ",
            "      ░                                                 "
        };

        for (int i = 0; i < asciiArtTitulo.Length; i++)
        {
            Console.SetCursorPosition((Console.BufferWidth - asciiArtTitulo[i].Length) / 2, Console.BufferHeight / 4 + i);
            Console.WriteLine(asciiArtTitulo[i]);
        }

        string mensajeInicio = "Presiona cualquier tecla para comenzar";
        Console.SetCursorPosition((Console.BufferWidth - mensajeInicio.Length) / 2, (Console.BufferHeight / 2) + 2);
        Console.WriteLine(mensajeInicio);

        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Bienvenido a la nueva edicion de BakeOff.");
        Console.WriteLine(" En esta competencia te enfrentaras contra 3 pasteleros. Se les dira que postre deben cocinar, y procederan a trabajar sin receta alguna. Posteriormente se vera quien acerto mas en la preparación correcta de lo pedido, y se puntuara ello. Se deja a eleccion del pastelero la presentacion y el sabor especifico que desea que su postre tenga, y esto tambien sera evaluado. En cada ronda se eliminara al pastelero que obtenga la puntuacion mas baja.");
        Console.WriteLine("\nPresione cualquier tecla para continuar.");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\n¿Como se juega?");
        Console.WriteLine("Usted comenzara eligiendo el pastelero con el que se desea cocinar, cada uno tiene su especialidad (creatividad, presentacion, eleccion de sabor, rapidez) en la cual se asegura que tiene puntaje alto. A continuacion se le asignara al azar un juez. Cada juez tiene criterios distintos de evaluacion, de acuerdo a lo que considera mas importante, asi que piense bien que pastelero elige. Posteriormente tendra que preparar un postre sin que se le diga la receta, teniendo que elegir entre las opciones brindadas. Finalmente, considerando en primer lugar si las elecciones de como preparar el plato son correctas, y luego las habilidades del pastelero elegido en relacion de como valora el juez que le toco cada una de estas habilidades.");
        Console.WriteLine("\nPresione cualquier tecla para continuar.");
        Console.ReadKey();
        Console.Clear();
    }

}