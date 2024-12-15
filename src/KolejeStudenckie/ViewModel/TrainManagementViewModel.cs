using KolejeStudenckie.Commands;
using KolejeStudenckie.DTO;
using KolejeStudenckie.DTO.Interfaces;
using KolejeStudenckie.Utilities;
using KolejeStudenckie.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace KolejeStudenckie.ViewModel
{
    internal class TrainManagementViewModel : BaseViewModel
    {
        public ObservableCollection<IDTO> Trains { get; set; }
        private TrainDTO _selectedTrain;
        public TrainDTO SelectedTrain
        {
            get => _selectedTrain;
            set
            {
                _selectedTrain = value;
                OnPropertyChanged();
                ((RelayCommand)RemoveTrainCommand).RaiseCanExecuteChanged();
                ((RelayCommand)OpenUpdateTrainWindowCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand OpenAddTrainWindowCommand { get; }
        public ICommand RemoveTrainCommand { get; }
        public ICommand OpenUpdateTrainWindowCommand { get; }

        public TrainManagementViewModel()
        {
            Trains = new ObservableCollection<IDTO>();
            _selectedTrain = null;

            OpenAddTrainWindowCommand = new RelayCommand(OpenAddTrainWindow);
            RemoveTrainCommand = new RelayCommand(RemoveTrain, CanExecuteRemoveOrUpdate);
            OpenUpdateTrainWindowCommand = new RelayCommand(OpenUpdateTrainWindow, CanExecuteRemoveOrUpdate);
            RefreshTrains();
        }

        private bool CanExecuteRemoveOrUpdate(object? parameter)
        {
            return SelectedTrain != null;
        }

        private void OpenAddTrainWindow(object? parameter)
        {
            var addTrainWindow = new AddTrainWindow();
            if (addTrainWindow.ShowDialog() == true)
            {
                RefreshTrains();
            }
        }

        private void RemoveTrain(object? parameter)
        {
            var schedules = JsonDataHandler.LoadDataFromJson<ScheduleDTO>("src/KolejeStudenckie/Data/schedules.json");
            var hasSchedule = schedules.Any(s => s.TrainId == SelectedTrain.Id);

            if (hasSchedule)
            {
                // Można dodać komunikat informujący użytkownika, że pociąg ma przypisane harmonogramy
                MessageBox.Show("Nie można usunąć pociągu, ponieważ ma przypisane harmonogramy.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var trains = JsonDataHandler.LoadDataFromJson<TrainDTO>("src/KolejeStudenckie/Data/trains.json");
            var trainToRemove = trains.FirstOrDefault(t => t.Id == SelectedTrain.Id);
            if (trainToRemove != null)
            {
                trains.Remove(trainToRemove);
                JsonDataHandler.SaveDataToJson("src/KolejeStudenckie/Data/trains.json", trains);
                RefreshTrains();
            }
        }

        private void OpenUpdateTrainWindow(object? parameter)
        {
            if (SelectedTrain != null)
            {
                var updateTrainWindow = new UpdateTrainWindow(SelectedTrain);
                if (updateTrainWindow.ShowDialog() == true)
                {
                    RefreshTrains();
                }
            }
        }

        private void RefreshTrains()
        {
            var trains = JsonDataHandler.LoadDataFromJson<TrainDTO>("src/KolejeStudenckie/Data/trains.json");
            Trains = new ObservableCollection<IDTO>(trains);
            OnPropertyChanged(nameof(Trains));
        }
    }
}
