using Domain.Entities;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using WPF_Koleje_Studenckie_project_Jakub_Bak.DTO;
using System.Windows;

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
        }

        private void LoadTrain(TrainDTO trainDto)
        {
            var train = new Train(trainDto.Name, trainDto.MaxSpeed, trainDto.Carriage.CarriageCount);
            train.Movement.CurrentSpeed = trainDto.Movement.CurrentSpeed;
            train.Movement.IsMoving = trainDto.Movement.IsMoving;
            Trains.Add(train);
        }

        private void LoadPersonel(PersonelDTO personelDto)
        {
            var personel = new Personel(personelDto.Name, personelDto.Surname, personelDto.Position, personelDto.Salary);
            PersonelList.Add(personel);
        }

        public static string GetTrainDataFilePath()
        {
            return GetFilePath("trains.json");
        }

        public static string GetPersonelDataFilePath()
        {
            return GetFilePath("personel.json");
        }

        private static string GetFilePath(string fileName)
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string dataFolderPath = Path.Combine(projectDirectory, "Data");
            Directory.CreateDirectory(dataFolderPath);
            return Path.Combine(dataFolderPath, fileName);
        }
    }
}
