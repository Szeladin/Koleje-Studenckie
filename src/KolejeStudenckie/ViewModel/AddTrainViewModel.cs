using KolejeStudenckie.Commands;
using KolejeStudenckie.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KolejeStudenckie.ViewModel
{
    internal class AddTrainViewModel
    {
        public TrainDTO NewTrain { get; set; } = new TrainDTO("", "", 0, new MovementDTO(), new CarriageDTO());

        public ICommand AddTrainCommand { get; }
        public ICommand CancelCommand { get; }

        public AddTrainViewModel()
        {
            AddTrainCommand = new RelayCommand(AddTrain);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void AddTrain(object parameter)
        {
            if (parameter is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }
        }

        private void Cancel(object parameter)
        {
            if (parameter is Window window)
            {
                window.DialogResult = false;
                window.Close();
            }
        }
    }
}
