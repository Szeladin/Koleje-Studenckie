﻿using Domain.Entities;
using System.Windows;
using System.Windows.Input;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AddTrainViewModel : BaseViewModel
    {
        public event EventHandler? DialogResultChanged;

        private bool? _dialogResult;
        public bool? DialogResult
        {
            get => _dialogResult;
            set
            {
                if (_dialogResult != value)
                {
                    _dialogResult = value;
                    OnPropertyChanged();
                    DialogResultChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public Train NewTrain { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int CarriageCount { get; set; }

        public AddTrainViewModel()
        {
            SaveCommand = new RelayCommand(AddTrain);
            CancelCommand = new RelayCommand(Cancel);
            NewTrain = new Train(string.Empty, string.Empty, 0, 0); 
            Name = string.Empty;
        }
        private void AddTrain()
        {
            if (ValidateInput(Name, MaxSpeed, CarriageCount, out string errorMessage))
            {
                NewTrain = new Train(ShortGuidHandler.GenerateUniqueShortGuid("Train-"), Name, MaxSpeed, CarriageCount);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel()
        {
            DialogResult = false;
        }

        public static bool ValidateInput(string name, int maxSpeed, int carriageCount, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                errorMessage = "Please enter a name for the train.";
                return false;
            }

            if (maxSpeed <= 0)
            {
                errorMessage = "Please enter a valid maximum speed for the train.";
                return false;
            }

            if (carriageCount <= 0)
            {
                errorMessage = "Please enter a valid carriage count for the train.";
                return false;
            }

            return true;
        }
    }
}