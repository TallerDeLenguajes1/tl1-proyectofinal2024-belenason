using System.Text.Json;
using Juego;


public class HistorialJson
{
    public static void GuardarGanador(Pastelero pastelero)
    {
        List<Pastelero> historial = LeerGanadores();
        historial.Add(pastelero);
        string jsonHistorial = JsonSerializer.Serialize(historial);
        File.WriteAllText("historial.json", jsonHistorial);
    }

    private static List<Pastelero> LeerGanadores()
    {
        try
        {
            string jsonHistorial = File.ReadAllText("historial.json");
            return JsonSerializer.Deserialize<List<Pastelero>>(jsonHistorial);
        }
        catch (FileNotFoundException)
        {
            return new List<Pastelero>();
        }
    }

    public static void mostrarHistorial()
    {
        List<Pastelero> historial = LeerGanadores();
        Console.Clear();
        Console.WriteLine("----HISTORIAL----");
        foreach (var ganador in historial)
        {
            Console.WriteLine($"Nombre: {ganador.Nombre}");
        }
        Console.WriteLine("Presione una tecla para volver");
        Console.ReadKey();
        Menu.MenuInicio();
    }
}

