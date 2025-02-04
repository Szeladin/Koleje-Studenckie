﻿using KolejeStudenckie.DTO;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace KolejeStudenckie.Utilities
{
    public static class JsonDataHandler
    {
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

        public static List<IDTO> LoadDataFromJson<IDTO>(string relativePath)
        {
            var jsonFilePath = GetFilePath(relativePath);

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

        public static void SaveDataToJson<IDTO>(string relativePath, IDTO data)
        {
            var jsonFilePath = GetFilePath(relativePath);

            var jsonData = JsonSerializer.Serialize(data, _jsonSerializerOptions);
            File.WriteAllText(jsonFilePath, jsonData);
        }

        public static async Task ArchiveOldSchedulesAsync(string schedulesPath, string archivePath, DateTime archiveBeforeDate)
        {
            var schedules = LoadDataFromJson<ScheduleDTO>(schedulesPath);
            var oldSchedules = schedules.Where(s => s.DepartureTime < archiveBeforeDate).ToList();

            if (oldSchedules.Any())
            {
                var archiveSchedules = LoadDataFromJson<ScheduleDTO>(archivePath);
                archiveSchedules.AddRange(oldSchedules);
                await SaveDataToJsonAsync(archivePath, archiveSchedules);

                schedules.RemoveAll(s => s.DepartureTime < archiveBeforeDate);
                await SaveDataToJsonAsync(schedulesPath, schedules);
            }
        }

        private static async Task SaveDataToJsonAsync<IDTO>(string relativePath, IDTO data)
        {
            var jsonFilePath = GetFilePath(relativePath);

            var jsonData = JsonSerializer.Serialize(data, _jsonSerializerOptions);
            await File.WriteAllTextAsync(jsonFilePath, jsonData);
        }

        private static string GetFilePath(string relativePath)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..", "..", "..", "..", ".."));
            return Path.Combine(projectDirectory, relativePath);
        }
    }
}