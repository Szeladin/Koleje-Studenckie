using System.Windows;
using System.Collections.ObjectModel;
using Domain.Entities;

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
            trains = [];
            TrainListView.ItemsSource = trains;
        }

        private void AddTrain_Click(object sender, RoutedEventArgs e)
        {
            AddTrainWindow addTrainWindow = new();
            addTrainWindow.ShowDialog();
            
            if (addTrainWindow.NewTrain != null)
            {
                trains.Add(addTrainWindow.NewTrain);
            }
        }

        private void RemoveTrain_Click(object sender, RoutedEventArgs e)
        {
            if (TrainListView.SelectedItem is Train selectedTrain)
            {
                trains.Remove(selectedTrain);
            }
            else
            {
                MessageBox.Show("Please select a train to remove.", "No Train Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UpdateTrain_Click(object sender, RoutedEventArgs e)
        {
            //UpdateTrainWindow updateTrainWndow = new UpdateTrainWindow();
            //updateTrainWndow.ShowDialog();
            //if (TrainListView.SelectedItem is Train selectedTrain)
            //{
                //selectedTrain.Name = $"Updated {selectedTrain.Name}";
                //TrainListView.Items.Refresh();
            //}
            //else
            //{
                //MessageBox.Show("Please select a train to update.", "No Train Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
        }
    }
}
