using KolejeStudenckie.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace KolejeStudenckie.Utilities
{
    public static class JsonDataLoader
    {
        public static List<IDTO> LoadDataFromJson<IDTO>(string relativePath) 
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\.."));
            var jsonFilePath = Path.Combine(projectDirectory, relativePath);

            if (File.Exists(jsonFilePath))
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<List<IDTO>>(jsonData);
                return data ?? new List<IDTO>();
            }
            else
            {
                MessageBox.Show("Missing data files", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show(jsonFilePath);
            }
            return new List<IDTO>();
        }
    }
}