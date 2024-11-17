using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using Domain.Entities;
using WPF_Koleje_Studenckie_project_Jakub_Bak.DTO;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AppViewModel : BaseViewModel
    {
        public ObservableCollection<Train> Trains { get; private set; }

        public AppViewModel()
        {
            Trains = [];
            LoadTrains();
        }

        public void LoadTrains()
        {
            string filePath = GetDataFilePath();
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
              
                    var loadedTrains = JsonSerializer.Deserialize<ObservableCollection<TrainDTO>>(json);
                    if (loadedTrains != null)
                    {
                        foreach (var trainDto in loadedTrains)
                        {
                            var train = new Train(trainDto.Name, trainDto.MaxSpeed, trainDto.Carriage.CarriageCount);
                            train.Movement.IsMoving = trainDto.Movement.IsMoving;
                            Trains.Add(train);
                        }
                    }
                
            }
        }

        public void SaveTrains()
        {
            string json = JsonSerializer.Serialize(Trains, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(GetDataFilePath(), json);
        }

        public static string GetDataFilePath()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string dataFolderPath = Path.Combine(projectDirectory, "Data");
            Directory.CreateDirectory(dataFolderPath);
            return Path.Combine(dataFolderPath, "trains.json");
        }
    }
}
