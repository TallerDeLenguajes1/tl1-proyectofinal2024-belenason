class Menu 
{
    private int indiceSelecc;

    private string [] opciones;
    private string pregunta; 

    public Menu (string Pregunta, string [] Opciones)
    {
        pregunta = Pregunta;
        opciones = Opciones;
        indiceSelecc = 0;
    }

    private void mostrarOpciones()
    {
        Console.WriteLine(pregunta);
        for (int i = 0; i < opciones.Length; i++)
        {
            string opcionActual = opciones [i];
            string prefijo;

            if (i == indiceSelecc)
            {
                prefijo = "*";
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            } else
            {
                prefijo = " ";
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine($"{prefijo} << {opcionActual} >>");
        }
        Console.ResetColor();
    }

    public int Correr()
    {
        ConsoleKey teclaPresionada;
        do
        {
            Console.Clear();
            mostrarOpciones();
            ConsoleKeyInfo infoTeclaPresionada = Console.ReadKey(true);
            teclaPresionada = infoTeclaPresionada.Key;

            if (teclaPresionada == ConsoleKey.UpArrow)
            {
                indiceSelecc--;
                if (indiceSelecc == -1)
                {
                    indiceSelecc = opciones.Length - 1;
                }
            } else if (teclaPresionada == ConsoleKey.DownArrow)
            {
                indiceSelecc++;
                if (indiceSelecc == opciones.Length)
                {
                    indiceSelecc = 0;
                }
            }
        } while (teclaPresionada != ConsoleKey.Enter);
        return indiceSelecc;
    }
}