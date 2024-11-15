using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using Domain.Entities;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Services;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AdminViewModel : BaseViewModel
    {
        public ObservableCollection<Train> Trains { get; }
        public ICommand AddTrainCommand { get; }
        public ICommand RemoveTrainCommand { get; }
        public ICommand UpdateTrainCommand { get; }
        public TrainHandler _trainHandler;

        public AdminViewModel()
        {
            Trains = App.Trains;
            _trainHandler = new TrainHandler();
            AddTrainCommand = new RelayCommand(AddTrain);
            RemoveTrainCommand = new RelayCommand(RemoveTrain);
            UpdateTrainCommand = new RelayCommand(UpdateTrain);
        }

        private void AddTrain()
        {
            var addTrainWindow = new AddTrainWindow();
            addTrainWindow.ShowDialog();

            if (addTrainWindow.NewTrain != null)
            {
                Trains.Add((Train)addTrainWindow.NewTrain);
                SaveTrains();
            }
        }

        private void RemoveTrain()
        {
            if (SelectedTrain != null)
            {
                Trains.Remove(SelectedTrain);
                SaveTrains();
            }
            else
            {
                MessageBox.Show("Please select a train to remove.", "No Train Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UpdateTrain()
        {
            if (SelectedTrain != null)
            {
                var addTrainWindow = new AddTrainWindow
                {
                    NameTextBox = { Text = SelectedTrain.Name },
                    MaxSpeedTextBox = { Text = SelectedTrain.MaxSpeed.ToString() },
                    CarriageCountTextBox = { Text = SelectedTrain.Carriage.CarriageCount.ToString() }
                };

                addTrainWindow.ShowDialog();

                if (addTrainWindow.NewTrain != null)
                {
                    int index = Trains.IndexOf(SelectedTrain);
                    Trains[index] = (Train)addTrainWindow.NewTrain;
                    SaveTrains();
                }
            }
            else
            {
                MessageBox.Show("Please select a train to update.", "No Train Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SaveTrains()
        {
            string json = JsonSerializer.Serialize(Trains, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(App.GetDataFilePath(), json);
        }

        public Train SelectedTrain { get; set; }
    }
}
