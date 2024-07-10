using Juego;

public class Interfaz
{
    public static void TituloInstruccionesDescripcion()
    {
        MostrarTextoAColorCentrado(ObtenerAsciiTxt("AsciiArtTitulo.txt"), "Red");
        string mensajeInicio = "Presiona cualquier tecla para comenzar";
        Console.SetCursorPosition((Console.BufferWidth - mensajeInicio.Length) / 2, (Console.BufferHeight / 2) + 2);
        Console.WriteLine(mensajeInicio);
        Console.ReadKey();
        Console.Clear();
        MostrarPresentacion();
        MostrarInstrucciones();
    }

    public static void MostrarPresentacion()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Bienvenido a la nueva edición de BakeOff.");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("¡Bienvenidos a la arena culinaria más feroz y emocionante! Aquí, los pasteleros no solo cocinan, sino que luchan por la gloria en tres intensas rondas de pura adrenalina y creatividad. En cada ronda, uno de estos valientes artistas del azúcar y la harina verá su sueño desvanecerse, dejando solo a los más fuertes para seguir batallando. Cada enfrentamiento es una sorpresa, con recetas al azar que desafían incluso a los más experimentados. Solo aquellos con un vasto conocimiento y habilidades excepcionales podrán mantenerse en pie. Un juez implacable, con ojo crítico y paladar exigente, evalúa cada creación. Al final de cada ronda, el pastelero con la puntuación más baja enfrentará la eliminación, y su horno se apagará para siempre. ¡Que comience la competencia y que el mejor pastelero emerja victorioso!");
        Console.WriteLine("\nPresione cualquier tecla para continuar.");
        Console.ReadKey();
        Console.Clear(); 
    }

    public static void MostrarInstrucciones()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("¿Como se juega?");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Usted comenzara eligiendo el pastelero con el que se desea cocinar, cada uno tiene su especialidad (creatividad, presentacion, eleccion de sabor, rapidez) en la cual se asegura que tiene puntaje alto. A continuacion se le asignara al azar un juez. Cada juez tiene criterios distintos de evaluacion, de acuerdo a lo que considera mas importante, asi que piense bien que pastelero elige. Posteriormente tendra que preparar un postre sin que se le diga la receta, teniendo que elegir entre las opciones brindadas. Finalmente, considerando en primer lugar si las elecciones de como preparar el plato son correctas, y luego las habilidades del pastelero elegido en relacion de como valora el juez que le toco cada una de estas habilidades.");
        Console.WriteLine("\nPresione cualquier tecla para continuar.");
        Console.ReadKey();
        Console.Clear();
    }

    public static string [] ObtenerAsciiTxt(string ruta)
    {
        string [] asciiArt = File.ReadAllLines(ruta);
        return asciiArt;
    }

    public static void MostrarTextoAColorCentrado(string [] texto, string color)
    {
        Console.CursorVisible = false;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight);
        Console.Clear();
        if (Enum.TryParse(color, true, out ConsoleColor consoleColor))
        {
            Console.ForegroundColor = consoleColor;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White; // Color por defecto si el color ingresado no es válido
        }
        for (int i = 0; i < texto.Length; i++)
        {
            Console.SetCursorPosition((Console.BufferWidth - texto[i].Length) / 2, Console.BufferHeight / 4 + i);
            Console.WriteLine(texto[i]);
        }
        Console.ResetColor();   
    }

    public static void EscribirConSuspenso(string oracion, bool centrado)
    {
        if (centrado)
        {
            Console.SetCursorPosition((Console.BufferWidth - oracion.Length) / 2, Console.BufferHeight / 4);
        }
        foreach (char c in oracion)
        {
            Console.Write(c);
            Thread.Sleep(50);
        }
        Console.Write("\n");
    }

}