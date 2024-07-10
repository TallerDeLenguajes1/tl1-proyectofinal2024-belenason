namespace Juego
{
        
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


        public static void MenuInicio()
        {
            string [] opciones = {"JUGAR", "Ver historial de ganadores", "Salir"};
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
            int indiceSelecc = 0;
            ConsoleKey teclaPresionada;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                for (int i = 0; i < asciiArtTitulo.Length; i++)
                {
                    Console.SetCursorPosition((Console.BufferWidth - asciiArtTitulo[i].Length) / 2, Console.BufferHeight / 4 + i);
                    Console.WriteLine(asciiArtTitulo[i]);
                }
                Console.ResetColor();
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
                    Console.SetCursorPosition((Console.BufferWidth - opcionActual.Length - 7) / 2, Console.BufferHeight / 2 + 3 + i);
                    Console.WriteLine($"{prefijo} << {opcionActual} >>");
                }
                Console.ResetColor();
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
            switch (indiceSelecc)
            {
                case 0:
                    Console.Clear();
                    Interfaz.escribirConSuspensoCentrado("Cargando...");
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
                    MenuInicio();
                    break;
                case 1:
                    HistorialJson.mostrarHistorial();
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