using KolejeStudenckie.DTO;
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

        public static void SaveDataToJson<IDTO>(string relativePath, IDTO data)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\.."));
            var jsonFilePath = Path.Combine(projectDirectory, relativePath);

            var jsonData = JsonSerializer.Serialize(data, _jsonSerializerOptions);
            File.WriteAllText(jsonFilePath, jsonData);
        }

        public static void ArchiveOldSchedules(string schedulesPath, string archivePath, DateTime archiveBeforeDate)
        {
            var schedules = LoadDataFromJson<ScheduleDTO>(schedulesPath);
            var oldSchedules = schedules.Where(s => s.DepartureTime < archiveBeforeDate).ToList();

            if (oldSchedules.Any())
            {
                var archiveSchedules = LoadDataFromJson<ScheduleDTO>(archivePath);
                archiveSchedules.AddRange(oldSchedules);
                SaveDataToJson(archivePath, archiveSchedules);

                schedules.RemoveAll(s => s.DepartureTime < archiveBeforeDate);
                SaveDataToJson(schedulesPath, schedules);
            }
        }
    }
}