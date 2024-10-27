using System.Windows;
using System.Collections.ObjectModel;
using Domain.Entities;
using System.IO;
using System.Text.Json;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly ObservableCollection<Train> trains;

        public AdminWindow()
        {
            InitializeComponent();
            trains = App.Trains;
            TrainListView.ItemsSource = trains;
        }

        private void AddTrain_Click(object sender, RoutedEventArgs e)
        {
            AddTrainWindow addTrainWindow = new();
            addTrainWindow.ShowDialog();
            
            if (addTrainWindow.NewTrain != null)
            {
                trains.Add(addTrainWindow.NewTrain);
                SaveTrains();
            }
        }

        private void RemoveTrain_Click(object sender, RoutedEventArgs e)
        {
            if (TrainListView.SelectedItem is Train selectedTrain)
            {
                trains.Remove(selectedTrain);
                SaveTrains();
            }
            else
            {
                MessageBox.Show("Please select a train to remove.", "No Train Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UpdateTrain_Click(object sender, RoutedEventArgs e)
        {
            if (TrainListView.SelectedItem is Train selectedTrain)
            {
                AddTrainWindow addTrainWindow = new();
                addTrainWindow.NameTextBox.Text = selectedTrain.Name;
                addTrainWindow.MaxSpeedTextBox.Text = selectedTrain.MaxSpeed.ToString();
                addTrainWindow.CarriageCountTextBox.Text = selectedTrain.CarriageCount.ToString();
                addTrainWindow.ShowDialog();

                if (addTrainWindow.NewTrain != null)
                {
                    int index = trains.IndexOf(selectedTrain);
                    trains[index] = addTrainWindow.NewTrain;
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
            string json = JsonSerializer.Serialize(App.Trains, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(App.GetDataFilePath(), json);
        }

    }
}
