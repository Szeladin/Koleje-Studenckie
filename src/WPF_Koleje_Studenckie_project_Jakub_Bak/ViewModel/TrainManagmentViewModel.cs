﻿using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using Domain.Entities;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Handlers;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class TrainManagementViewModel : BaseViewModel
    {
        public ObservableCollection<Train> Trains { get; }
        public ICommand AddTrainCommand { get; }
        public ICommand RemoveTrainCommand { get; }
        public ICommand UpdateTrainCommand { get; }
        public TrainHandler _trainHandler;

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
            _trainHandler = new TrainHandler();
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
                    if (index >= 0)
                    {
                        Trains[index] = (Train)addTrainWindow.NewTrain;
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
            try
            {
                string json = JsonSerializer.Serialize(Trains, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(AppViewModel.GetDataFilePath(), json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving trains: {ex.Message}", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public Train SelectedTrain { get; set; }
    }
}
