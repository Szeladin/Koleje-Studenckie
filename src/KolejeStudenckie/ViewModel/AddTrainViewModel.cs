using KolejeStudenckie.Commands;
using KolejeStudenckie.DTO;
using KolejeStudenckie.Utilities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace KolejeStudenckie.ViewModel
{
    internal class AddTrainViewModel : BaseViewModel
    {
        public TrainDTO NewTrain { get; set; }
        public ObservableCollection<PersonnelDTO> AvailablePersonnel { get; set; }
        public List<string> SelectedPersonnel { get; set; }

        public ICommand AddTrainCommand { get; }
        public ICommand CancelCommand { get; }

        public AddTrainViewModel()
        {
            string newTrainId = ShortGuidHandler.GenerateUniqueShortGuid("Trains-");
            SelectedPersonnel = new List<string> { "", "", "" };
            NewTrain = new TrainDTO(newTrainId, "", 0, new MovementDTO(), new CarriageDTO(), DateTime.Now, SelectedPersonnel);

            AvailablePersonnel = new ObservableCollection<PersonnelDTO>(JsonDataHandler.LoadDataFromJson<PersonnelDTO>("src/KolejeStudenckie/Data/personnels.json"));

            AddTrainCommand = new RelayCommand(AddTrain);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void AddTrain(object? parameter)
        {
            if (parameter is Window window)
            {
                if (SelectedPersonnel.Distinct().Count() != 3 || SelectedPersonnel.Any(p=> string.IsNullOrEmpty(p)))
                {
                    MessageBox.Show("Train must contain 3 diffrent elements of personnel.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var trains = JsonDataHandler.LoadDataFromJson<TrainDTO>("src/KolejeStudenckie/Data/trains.json");
                trains.Add(NewTrain);
                JsonDataHandler.SaveDataToJson("src/KolejeStudenckie/Data/trains.json", trains);
                window.DialogResult = true;
                window.Close();
            }
        }

        private void Cancel(object? parameter)
        {
            if (parameter is Window window)
            {
                window.DialogResult = false;
                window.Close();
            }
        }
    }
}
