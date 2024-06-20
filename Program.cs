using gestionPersonajes;
//Ideas: competencia de cocina. Hay varios campos en los que se compite donde haces decisiones (sabor elegido, color, dulce o salado, etc.). Se elige al azar en cada ronda el valor que tendra cada opción, y el q termine teniendo más puntos gana. En el caso de que haya un empate, dependera de tu carisma (pensar en lo que hicieron con lo de recomendar algo y ver si se mete gol o no.)
List<Chef> chefs= new List<Chef>(); 
fabricaDePersonajes fabrica = new fabricaDePersonajes();
chefs = fabrica.crearChefs();
 startGame();
seleccionPastelero(chefs);

 
static void startGame()
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

    // Esperar a que se presione una tecla
    Console.ReadKey();
    Console.Clear();
    Console.WriteLine("Bienvenido a la nueva edicion de Masterchef (Version Pasteleria).");
    Console.WriteLine(" En esta competencia te enfrentaras contra 3 pasteleros. Se les dira que postre deben cocinar, y procederan a trabajar sin receta alguna. Posteriormente se vera quien acerto mas en la preparación correcta de lo pedido, y se puntuara ello. Se deja a eleccion del pastelero la presentacion y el sabor especifico que desea que su postre tenga, y esto tambien sera evaluado. En cada ronda se eliminara al pastelera que obtenga la puntuacion mas baja.");
    Console.WriteLine("\nPresione cualquier tecla para continuar.");
    Console.ReadKey();
    Console.Clear();
    Console.WriteLine("\n¿Como se juega?");
    Console.WriteLine("Usted comenzara eligiendo el pastelero con el que se desea cocinar, cada uno tiene sus campos en los que se destaca (creatividad, presentacion, eleccion de sabor). A continuacion se le asignara al azar un juez. Cada juez tiene un forma distinta de evaluar los postres, de acuerdo a lo que considera mas importante, asi que piense bien que pastelero elige. Posteriormente tendra que preparar un postre sin que se le diga la receta, teniendo que elegir entre las opciones brindadas. Finalmente, considerando en primer lugar si las elecciones de como preparar el plato son correctas, y luego las habilidades del pastelero elegido en relacion de como valora el juez que le toco cada una de estas habilidades. En cada ronda podra elegir un nuevo pastelero.");
    Console.WriteLine("\nPresione cualquier tecla para continuar.");
    Console.ReadKey();
    Console.Clear();
}

static void seleccionPastelero(List<Chef> chefs)
{
    int i = 1;
    Console.WriteLine("A continuacion se le mostraran los pasteleros disponibles. Lea bien sus caracteristicas y elija uno");
    foreach (Chef opcionChef in chefs)
    {
        Console.WriteLine($"Pastelero {i}:");
        opcionChef.mostrarInfoChef();
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
            Console.WriteLine("Se selecciono Pastelero 1");
            break;
        case 1:
            Console.WriteLine("Se selecciono Pastelero 2");
            break;
        case 2:
            Console.WriteLine("Se selecciono Pastelero 3");
            break;
        case 3:
            Console.WriteLine("Se selecciono Pastelero 4");
            break;
    }
}
