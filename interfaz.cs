public class Interfaz
{
    /// <summary>
    /// Muestra por consola el nombre del juego, la descripción del mismo y las instrucciones de cómo jugar.
    /// </summary>
    public static void TituloInstruccionesDescripcion()
    {
        MostrarTextoAColorCentrado(ObtenerAsciiTxt("data/AsciiArtTitulo.txt"), "Red");
        string mensajeInicio = "Presiona cualquier tecla para comenzar";
        Console.SetCursorPosition((Console.BufferWidth - mensajeInicio.Length) / 2, (Console.BufferHeight / 2) + 2);
        Console.WriteLine(mensajeInicio);
        Console.ReadKey();
        Console.Clear();
        MostrarPresentacion();
        MostrarInstrucciones();
    }

    /// <summary>
    /// Muestra por consola la presentación del juego.
    /// </summary>
    public static void MostrarPresentacion()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Bienvenido a la nueva edición de BakeOff.");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("¡Bienvenidos a la arena culinaria más feroz y emocionante!\nAquí, los pasteleros no solo cocinan, sino que luchan por la gloria en tres intensas rondas de pura adrenalina y creatividad. En cada ronda, uno de estos valientes artistas del azúcar y la harina verá su sueño desvanecerse, dejando solo a los más fuertes para seguir batallando.\nCada enfrentamiento es una sorpresa, con recetas al azar que desafían incluso a los más experimentados. Solo aquellos con un vasto conocimiento y habilidades excepcionales podrán mantenerse en pie.\nUn juez implacable, con ojo crítico y paladar exigente, evalúa cada creación. Al final de cada ronda, el pastelero con la puntuación más baja enfrentará la eliminación, y su horno se apagará para siempre.\n¡Que comience la competencia y que el mejor pastelero emerja victorioso!");
        Console.WriteLine("\nPresione cualquier tecla para continuar.");
        Console.ReadKey();
        Console.Clear(); 
    }

    /// <summary>
    /// Muestra por consola el cómo funciona el juego.
    /// </summary>
    public static void MostrarInstrucciones()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("¿Cómo se juega?");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Usted comenzará eligiendo el pastelero con el que se desea cocinar, cada uno tiene su especialidad (creatividad, presentación del plato, elección de sabor, rapidez de preparación) en la cual se asegura que tiene puntaje alto. A continuación se le asignara al azar un juez. Cada juez tiene criterios distintos de evaluación, de acuerdo a lo que considera más importante, así que piense bien que pastelero elige. Posteriormente tendrá que preparar un postre sin que se le diga la receta, teniendo que elegir entre las opciones brindadas. Finalmente, considerando en primer lugar si las elecciones de como preparar el plato son correctas, y luego las habilidades del pastelero elegido en relación de como valora el juez que le tocó cada una de estas habilidades.");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nATENCION! Se recomienda tener la pantalla del juego maximizada para que los gráficos se muestren adecuadamente.");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nPresione cualquier tecla para continuar.");
        Console.ReadKey();
        Console.Clear();
    }

    /// <summary>
    /// Lee un archivo de texto y obtiene el arte ASCII contenido en él.
    /// </summary>
    /// <param name="ruta">Ruta del archivo de texto que contiene el arte ASCII.</param>
    /// <returns>Arreglo de cadenas de texto, donde cada cadena representa una línea del arte ASCII.</returns>
public static string[] ObtenerAsciiTxt(string ruta)
{
    if (!File.Exists(ruta))
    {
        return null;
    } else
    {
        string[] asciiArt = File.ReadAllLines(ruta);
        return asciiArt;
    }
}

    /// <summary>
    /// Muestra un texto centrado en la consola con un color específico.
    /// </summary>
    /// <param name="texto">Arreglo de cadenas de texto a mostrar, cada cadena representa una línea.</param>
    /// <param name="color">Nombre del color de la fuente en inglés en formato string.</param>
    public static void MostrarTextoAColorCentrado(string [] texto, string color)
    {
        if (texto != null)
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
    }

    /// <summary>
    /// Escribe una oración en la consola con un efecto de suspenso.
    /// </summary>
    /// <param name="oracion">La oración a escribir en la consola.</param>
    /// <param name="centrado">Indica si la oración debe ser centrada horizontalmente en la consola.</param>
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

    /// <summary>
    /// Presenta por pantalla un Ascii Art de presentador y muestra durante un tiempo determinado mensajes recibidos como parámetro.
    /// </summary>
    /// <param name="mjes">Oraciones a mostrar.</param>
    /// <param name="suspenso">Indica si los mensajes se deben escribir con un efecto de suspenso.</param>
    public static void PresentadorHablando(string [] mjes, bool suspenso)
    {
        try
        {
            string [] asciiArt = ObtenerAsciiTxt("data/presentador.txt");
            Console.SetCursorPosition(0, asciiArt.Length);
            Console.SetCursorPosition(0, 0);
            if (asciiArt != null)
            {
                foreach (var linea in asciiArt)
                {
                    Console.WriteLine(linea);
                }
                int cursorLeft = 0;
                int cursorTop = asciiArt.Length;
                ActualizarMensajes(mjes, cursorLeft, cursorTop, 3000, suspenso);
            } else
            {
                ActualizarMensajes(mjes, 0, 0, 3000, suspenso);
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            ActualizarMensajes(mjes, 0, 0, 3000, suspenso);
        }
    }

    /// <summary>
    /// Va actualizando los mensajes a mostrar por pantalla.
    /// </summary>
    /// <param name="mjes">Oraciones a mostrar.</param>
    /// <param name="cursorLeft">Indica donde se debe posicionar el cursor para escribir con respecto a la izquierda.</param>
    /// <param name="cursorTop">Indica donde se debe posicionar el cursor para escribir con respecto a la izquierda.</param>
    /// <param name="intervalo">Indica cuantos milisegundos debe durar cada mensaje.</param>
    /// <param name="suspenso">Indica si los mensajes se deben escribir con un efecto de suspenso.</param>
    static void ActualizarMensajes(string[] mjes, int cursorLeft, int cursorTop, int intervalo, bool suspenso)
    {
        for (int index = 0; index < mjes.Length; index++)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth)); // Limpiar el mensaje anterior
            Console.SetCursorPosition(cursorLeft, cursorTop);
            if (suspenso)
            {
                EscribirConSuspenso(mjes[index], false);
            } else
            {
                Console.Write(mjes[index]);
            }
            Thread.Sleep(intervalo);
        }
        Console.Clear();
    }

}