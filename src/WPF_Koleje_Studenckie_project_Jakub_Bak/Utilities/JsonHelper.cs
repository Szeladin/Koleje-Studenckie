using System.IO;
using System.Text.Json;
using System.Windows;

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

        public static string GetDataFilePath(string fileName)
        {
            string? baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (baseDirectory == null)
            {
                throw new InvalidOperationException("Base directory cannot be null.");
            }

            string? projectDirectory = Directory.GetParent(baseDirectory)?.Parent?.Parent?.Parent?.FullName;
            if (projectDirectory == null)
            {
                throw new InvalidOperationException("Project directory cannot be determined.");
            }

            string dataFolderPath = Path.Combine(projectDirectory, "Data");
            Directory.CreateDirectory(dataFolderPath);
            return Path.Combine(dataFolderPath, fileName);
        }
    }
}
