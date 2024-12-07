using Domain.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Views;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class TrainManagementViewModel : BaseViewModel
    {
        public ObservableCollection<Train> Trains { get; }
        public ICommand AddTrainCommand { get; }
        public ICommand RemoveTrainCommand { get; }
        public ICommand UpdateTrainCommand { get; }
        public Train? SelectedTrain { get; set; }

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
            AddTrainCommand = new RelayCommand(_ => AddTrain());
            RemoveTrainCommand = new RelayCommand(_ => RemoveTrain(), _ => SelectedTrain != null);
            UpdateTrainCommand = new RelayCommand(_ => UpdateTrain(), _ => SelectedTrain != null);
        }

        private void AddTrain()
        {
            var addTrain = new AddTrain
            {
                DataContext = new AddTrainViewModel()
            };

            bool? result = addTrain.ShowDialog();

            if (result == true && addTrain.NewTrain != null)
            {
                Trains.Add(addTrain.NewTrain);
                SaveTrains();
            }
        }

        private void RemoveTrain()
        {
            if (SelectedTrain != null)
            {
                var result = MessageBox.Show($"Are you sure you want to remove the train {SelectedTrain.Name}?", "Remove Train", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Trains.Remove(SelectedTrain);
                    SaveTrains();
                }
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
                var addTrain = new AddTrain
                {
                    NameTextBox = { Text = SelectedTrain.Name },
                    MaxSpeedTextBox = { Text = SelectedTrain.MaxSpeed.ToString() },
                    CarriageCountTextBox = { Text = SelectedTrain.CarriageCount.ToString() }
                };

                addTrain.ShowDialog();

                if (addTrain.NewTrain != null)
                {
                    var updatedTrain = addTrain.NewTrain;
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
