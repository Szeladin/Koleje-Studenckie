using Domain.Entities;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using WPF_Koleje_Studenckie_project_Jakub_Bak.DTO;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AppViewModel : BaseViewModel
    {
        public ObservableCollection<Train> Trains { get; private set; }
        public ObservableCollection<Personel> PersonelList { get; private set; }
        public AppViewModel()
        {
            Trains = [];
            PersonelList = [];
            LoadTrains();
            LoadPersonel();
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

        public void LoadPersonel()
        {
            string filePath = GetPersonelDataFilePath();
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var loadedPersonel = JsonSerializer.Deserialize<ObservableCollection<PersonelDTO>>(json);
                if (loadedPersonel != null)
                {
                    foreach (var personelDTO in loadedPersonel)
                    {
                        var personel = new Personel(personelDTO.Name, personelDTO.Surname, personelDTO.Position, personelDTO.Salary);
                        PersonelList.Add(personel);
                    }
                }
            }
        }
        public static string GetDataFilePath()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string dataFolderPath = Path.Combine(projectDirectory, "Data");
            Directory.CreateDirectory(dataFolderPath);
            return Path.Combine(dataFolderPath, "trains.json");
        }

        public static string GetPersonelDataFilePath()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string dataFolderPath = Path.Combine(projectDirectory, "Data");
            Directory.CreateDirectory(dataFolderPath);
            return Path.Combine(dataFolderPath, "personel.json");
        }
    }
}
