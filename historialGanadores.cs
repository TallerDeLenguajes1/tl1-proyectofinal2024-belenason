using System.Text.Json;
using Juego;


public class HistorialJson
{
    public static void GuardarGanador(Pastelero pastelero)
    {
        List<Pastelero> historial = LeerGanadoresDelHistorial();
        historial.Add(pastelero);
        string jsonHistorial = JsonSerializer.Serialize(historial);
        File.WriteAllText("data/historial.json", jsonHistorial);
    }

    private static List<Pastelero> LeerGanadoresDelHistorial()
    {
        try
        {
            string jsonHistorial = File.ReadAllText("data/historial.json");
            return JsonSerializer.Deserialize<List<Pastelero>>(jsonHistorial);
        }
        catch (FileNotFoundException)
        {
            return new List<Pastelero>();
        }
    }

    public static void MostrarHistorial()
    {
        List<Pastelero> historial = LeerGanadoresDelHistorial();
        Console.Clear();
        Console.WriteLine("----HISTORIAL DE GANADORES----");
        foreach (var ganador in historial)
        {
            Console.WriteLine($"Nombre: {ganador.Nombre}");
        }
        Console.WriteLine("Presione una tecla para volver");
        Console.ReadKey();
        Game.CorrerJuego();
    }
}

