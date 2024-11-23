using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.DTO;

public static class JsonHelper
{
    public static void Save(IEnumerable<IDTO> dtos, string path)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true, 
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
            };

            var json = JsonSerializer.Serialize(dtos, options);

            File.WriteAllText(path, json);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving data: {ex.Message}", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    public static T Deserialize<T>(string path)
    {
        if (!File.Exists(path))
        {
            MessageBox.Show("File does not exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return default;
        }

        try
        {
            // Read the JSON string from the file
            var json = File.ReadAllText(path);

            // Deserialize the JSON string to the specified type
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Ensure the naming policy matches the JSON format
            };
            return JsonSerializer.Deserialize<T>(json, options);
        }
        catch (Exception ex)
        {
            // Show an error message if deserialization fails
            MessageBox.Show($"Error loading data: {ex.Message}", "Load Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return default;
        }
    }
}
