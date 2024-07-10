namespace Juego
{
        
    class Menu 
    {
        private int indiceSelecc;

        private string [] opciones;
        private string [] textoAnterior; 

        public Menu (string [] TextoAnterior, string [] Opciones)
        {
            textoAnterior = TextoAnterior;
            opciones = Opciones;
            indiceSelecc = 0;
        }

        private void MostrarOpcionesYTexto(bool centrado, string colorPregunta)
        {
            if (centrado)
            {
                Interfaz.MostrarTextoAColorCentrado(textoAnterior, colorPregunta);
            } else
            {
                foreach (string linea in textoAnterior)
                {
                    Console.WriteLine(linea);
                }
            }
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
                if (centrado)
                {
                    Console.SetCursorPosition((Console.BufferWidth - opcionActual.Length - 7) / 2, Console.BufferHeight / 2 + 3 + i);

                }
                Console.WriteLine($"{prefijo} << {opcionActual} >>");
            }
            Console.ResetColor();
        }

        public int Correr(bool centrado, string colorPregunta)
        {
            ConsoleKey teclaPresionada;
            do
            {
                Console.Clear();
                MostrarOpcionesYTexto(centrado, colorPregunta);
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
}