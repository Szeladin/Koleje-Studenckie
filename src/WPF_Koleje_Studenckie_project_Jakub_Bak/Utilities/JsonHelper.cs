using System.IO;
using System.Text.Json;
using System.Windows;
using System.Collections.Generic;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities
{
    public class JsonHelper
    {
        public static void SaveToJson<IDTO>(IEnumerable<IDTO> data, string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(data, JsonOptionsProvider.GetDefaultOptions());
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
