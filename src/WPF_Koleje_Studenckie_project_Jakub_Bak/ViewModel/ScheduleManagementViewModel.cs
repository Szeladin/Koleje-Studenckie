using Domain.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPF_Koleje_Studenckie_project_Jakub_Bak.DTO;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;


namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class ScheduleManagementViewModel : BaseViewModel
    {
        public ObservableCollection<Schedule> Schedules { get; set; }
        public ICommand AddScheduleCommand { get; }
        public ICommand UpdateScheduleCommand { get; }
        public ICommand RemoveScheduleCommand { get; }

        public Schedule SelectedSchedule { get; set; }

        public ScheduleManagementViewModel()
        {
            var appViewModel = (AppViewModel)Application.Current.Resources["AppViewModel"];
            if (appViewModel != null)
            {
                Schedules = appViewModel.Schedules;
            }
            else
            {
                MessageBox.Show("AppViewModel is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            AddScheduleCommand = new RelayCommand(AddSchedule);
            UpdateScheduleCommand = new RelayCommand(UpdateSchedule);
            RemoveScheduleCommand = new RelayCommand(RemoveSchedule);
        }

        private void AddSchedule()
        {
            var addScheduleWindow = new AddScheduleWindow
            {
                DataContext = new AddScheduleViewModel()
            };

            bool? result = addScheduleWindow.ShowDialog();

            if (result == true && addScheduleWindow.NewSchedule != null)
            {
                Schedules.Add(addScheduleWindow.NewSchedule);
                SaveSchedules();
            }
        }

        private void UpdateSchedule()
        {
            if (SelectedSchedule != null)
            {
                var addScheduleWindow = new AddScheduleWindow
                {
                    SelectedTrainIdComboBox = { SelectedValue = SelectedSchedule.TrainId },
                    DepartureTimePicker = { Text = SelectedSchedule.DepartureTime.ToString() },
                    ArrivalTimePicker = { Text = SelectedSchedule.ArrivalTime.ToString() },
                    StationTextBox = { Text = SelectedSchedule.Station },
                };

                bool? result = addScheduleWindow.ShowDialog();

                if (result == true && addScheduleWindow.NewSchedule != null)
                {
                    var updatedSchedule = addScheduleWindow.NewSchedule;
                    updatedSchedule.Id = SelectedSchedule.Id;
                    int index = Schedules.IndexOf(SelectedSchedule);
                    Schedules[index] = updatedSchedule;

                    SaveSchedules();
                }
            }
            else
            {
                MessageBox.Show("Please select a schedule to update.", "No Schedule Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RemoveSchedule()
        {
            if (SelectedSchedule != null)
            {
                var result = MessageBox.Show("Are you sure you want to remove the selected schedule?", "Confirm Removal", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Schedules.Remove(SelectedSchedule);
                    SaveSchedules();
                }
            }
            else
            {
                MessageBox.Show("Please select a schedule to remove.", "No Schedule Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SaveSchedules()
        {
            JsonHelper.SaveToJson(Schedules, FilePathProvider.GetScheduleDataFilePath());
        }
    }
}
