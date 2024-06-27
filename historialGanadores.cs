using System.Text.Json;
using Juego;


public class Historial
{
    public static void GuardarEnHistorial(Pastelero pastelero)
    {
        List<Pastelero> historial = ObtenerHistorial();
        historial.Add(pastelero);
        string jsonHistorial = JsonSerializer.Serialize(historial);
        File.WriteAllText("historial.json", jsonHistorial);
    }

    private static List<Pastelero> ObtenerHistorial()
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
        List<Pastelero> historial = ObtenerHistorial();
        Console.Clear();
        Console.WriteLine("----HISTORIAL----");
        foreach (var ganador in historial)
        {
            Console.WriteLine($"Nombre: {ganador.Nombre}");
        }
        Console.WriteLine("Presione una tecla para continuar");
        Console.ReadKey();
    }
}

