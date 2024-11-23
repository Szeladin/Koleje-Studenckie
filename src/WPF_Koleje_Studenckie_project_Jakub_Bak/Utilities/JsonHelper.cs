using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WPF_Koleje_Studenckie_project_Jakub_Bak.DTO;

public static class JsonHelper
{
    public static void SaveToJson<T>(string filePath, List<T> data)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(filePath, JsonSerializer.Serialize(data, options));
    }

    public static List<T> LoadFromJson<T>(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<T>();
        }

        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<T>>(json);
    }
}
