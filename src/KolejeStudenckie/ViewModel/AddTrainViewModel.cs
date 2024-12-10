using KolejeStudenckie.Commands;
using KolejeStudenckie.DTO;
using KolejeStudenckie.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KolejeStudenckie.ViewModel
{
    internal class AddTrainViewModel : BaseViewModel
    {
        public TrainDTO NewTrain { get; set; }

        public ICommand AddTrainCommand { get; }
        public ICommand CancelCommand { get; }

        public AddTrainViewModel()
        {
            string newTrainId = ShortGuidHandler.GenerateUniqueShortGuid("Trains-");
            NewTrain = new TrainDTO(newTrainId, "", 0, new MovementDTO(), new CarriageDTO());

            AddTrainCommand = new RelayCommand(AddTrain);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void AddTrain(object? parameter)
        {
            if (parameter is Window window)
            {
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
