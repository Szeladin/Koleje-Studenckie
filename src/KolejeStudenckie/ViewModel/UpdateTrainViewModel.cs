using KolejeStudenckie.Commands;
using KolejeStudenckie.DTO;
using KolejeStudenckie.Utilities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KolejeStudenckie.ViewModel
{
    internal class UpdateTrainViewModel : BaseViewModel
    {
        private TrainDTO _train;
        public TrainDTO Train
        {
            get => _train;
            set
            {
                _train = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PersonnelDTO> AvailablePersonnel { get; set; }
        public List<string> SelectedPersonnel { get; set; }

        public ICommand UpdateTrainCommand { get; }
        public ICommand CancelCommand { get; }

        public UpdateTrainViewModel(TrainDTO train)
        {
            Train = train;
            SelectedPersonnel = new List<string>(train.Personnel);
            AvailablePersonnel = new ObservableCollection<PersonnelDTO>(JsonDataHandler.LoadDataFromJson<PersonnelDTO>("src/KolejeStudenckie/Data/personnels.json"));

            UpdateTrainCommand = new RelayCommand(UpdateTrain);
            CancelCommand = new RelayCommand(Cancel);
        }

        private static void UpdateBindingSource(Window window, string textBoxName)
        {
            var textBox = window.FindName(textBoxName) as TextBox;
            textBox?.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
        }

        public void UpdateTrain(object? parameter)
        {
            if (parameter is Window window)
            {
                UpdateBindingSource(window, "NameTextBox");
                UpdateBindingSource(window, "MaxSpeedTextBox");
                UpdateBindingSource(window, "CarriageCountTextBox");

                if (SelectedPersonnel.Distinct().Count() != 3 || SelectedPersonnel.Any(p => string.IsNullOrEmpty(p)))
                {
                    MessageBox.Show("Train must have three diffrent elements of personnel.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var trains = JsonDataHandler.LoadDataFromJson<TrainDTO>("src/KolejeStudenckie/Data/trains.json");
                var existingTrain = trains.FirstOrDefault(t => t.Id == Train.Id);
                if (existingTrain != null)
                {
                    existingTrain.Name = Train.Name;
                    existingTrain.MaxSpeed = Train.MaxSpeed;
                    existingTrain.Movement = Train.Movement;
                    existingTrain.Carriage = Train.Carriage;
                    existingTrain.LastUpdated = DateTime.Now;
                    existingTrain.Personnel = new List<string>(SelectedPersonnel);
                }
                JsonDataHandler.SaveDataToJson("src/KolejeStudenckie/Data/trains.json", trains);
                window.DialogResult = true;
                window.Close();
            }
        }

        public void Cancel(object? parameter)
        {
            if (parameter is Window window)
            {
                window.DialogResult = false;
                window.Close();
            }
        }
    }
}
