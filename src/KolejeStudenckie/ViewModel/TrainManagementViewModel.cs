using KolejeStudenckie.Commands;
using KolejeStudenckie.DTO;
using KolejeStudenckie.DTO.Interfaces;
using KolejeStudenckie.Utilities;
using KolejeStudenckie.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace KolejeStudenckie.ViewModel
{
    internal class TrainManagementViewModel
    {
        public ObservableCollection<IDTO> Trains { get; set; }
        public TrainDTO SelectedTrain { get; set; } = new TrainDTO("", "", 0, new MovementDTO(), new CarriageDTO());

        public ICommand OpenAddTrainWindowCommand { get; }
        public ICommand RemoveTrainCommand { get; }
        public ICommand OpenUpdateTrainWindowCommand { get; }

        public TrainManagementViewModel()
        {
            Trains = new ObservableCollection<IDTO>(JsonDataLoader.LoadDataFromJson<TrainDTO>("src/KolejeStudenckie/Data/trains.json"));
            OpenAddTrainWindowCommand = new RelayCommand(OpenAddTrainWindow);
            RemoveTrainCommand = new RelayCommand(RemoveTrain);
            OpenUpdateTrainWindowCommand = new RelayCommand(OpenUpdateTrainWindow);
        }

        private void OpenAddTrainWindow()
        {
            var addTrainWindow = new AddTrainWindow();
            if (addTrainWindow.ShowDialog() == true)
            {
                // Implementacja dodawania pociągu
                var newTrain = addTrainWindow.NewTrain;
                Trains.Add(newTrain);
            }
        }

        private void RemoveTrain()
        {
            if (SelectedTrain != null)
            {
                Trains.Remove(SelectedTrain);
            }
        }

        private void OpenUpdateTrainWindow()
        {
            // Implementacja aktualizacji pociągu
        }
    }
}
