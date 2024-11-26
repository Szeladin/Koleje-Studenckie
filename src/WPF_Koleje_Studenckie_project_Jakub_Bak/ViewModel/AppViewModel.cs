using Domain.Entities;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.DTO;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AppViewModel : BaseViewModel
    {
        public ObservableCollection<Train> Trains { get; private set; }
        public ObservableCollection<Personel> PersonelList { get; private set; }
        public AppViewModel()
        {
            Trains = new ObservableCollection<Train>();
            PersonelList = new ObservableCollection<Personel>();
            LoadTrains();
            LoadPersonel();
        }
        public void LoadTrains()
        {
            LoadData<TrainDTO>(GetTrainDataFilePath(), trainDto =>
            {
                var train = new Train(trainDto.Id,trainDto.Name, trainDto.MaxSpeed, trainDto.Carriage?.CarriageCount ?? 0);
                train.Movement.IsMoving = trainDto.Movement.IsMoving;
                Trains.Add(train);
            });
        }

        public void LoadPersonel()
        {
            LoadData<PersonelDTO>(GetPersonelDataFilePath(), personelDto =>
            {
                var personel = new Personel(personelDto.Id,personelDto.Name, personelDto.Surname, personelDto.Position, personelDto.Salary);
                PersonelList.Add(personel);
            });
        }
        private void LoadData<T>(string filePath, Action<T> loadAction) where T : IDTO
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var loadedData = JsonSerializer.Deserialize<ObservableCollection<T>>(json);
                if (loadedData != null)
                {
                    foreach (var item in loadedData)
                    {
                        loadAction(item);
                    }
                }
            }
        }

        public static string GetDataFilePath(string fileName)
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string dataFolderPath = Path.Combine(projectDirectory, "Data");
            Directory.CreateDirectory(dataFolderPath);
            return Path.Combine(dataFolderPath, fileName);
        }

        public static string GetTrainDataFilePath()
        {
            return GetDataFilePath("trains.json");
        }

        public static string GetPersonelDataFilePath()
        {
            return GetDataFilePath("personel.json");
        }
    }
}
