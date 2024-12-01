using Domain.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class TrainManagementViewModel : BaseViewModel
    {
        public ObservableCollection<Train> Trains { get; }
        public ICommand AddTrainCommand { get; }
        public ICommand RemoveTrainCommand { get; }
        public ICommand UpdateTrainCommand { get; }
        public Train SelectedTrain { get; set; }
        public TrainManagementViewModel()
        {
            var appViewModel = (AppViewModel)Application.Current.Resources["AppViewModel"];
            if (appViewModel != null)
            {
                Trains = appViewModel.Trains;
            }
            else
            {
                MessageBox.Show("AppViewModel is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            AddTrainCommand = new RelayCommand(AddTrain);
            RemoveTrainCommand = new RelayCommand(RemoveTrain);
            UpdateTrainCommand = new RelayCommand(UpdateTrain);
        }

        private void AddTrain()
        {
            var addTrainWindow = new AddTrainWindow
            {
                DataContext = new AddTrainViewModel()
            };

            bool? result = addTrainWindow.ShowDialog();

            if (result == true && addTrainWindow.NewTrain != null)
            {
                Trains.Add(addTrainWindow.NewTrain);
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
                    var updatedTrain = (Train)addTrainWindow.NewTrain;
                    updatedTrain.Id = SelectedTrain.Id;

                    int index = Trains.IndexOf(SelectedTrain);
                    if (index >= 0)
                    {
                        Trains[index] = updatedTrain;
                        SaveTrains();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a train to update.", "No Train Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SaveTrains()
        {
            JsonHelper.SaveToJson(Trains, FilePathProvider.GetTrainDataFilePath());
        }
    }
}
