using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
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
}

