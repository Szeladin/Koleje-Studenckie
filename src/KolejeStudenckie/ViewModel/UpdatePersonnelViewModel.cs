﻿using KolejeStudenckie.Commands;
using KolejeStudenckie.DTO;
using KolejeStudenckie.Utilities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KolejeStudenckie.ViewModel
{
    internal class UpdatePersonnelViewModel : BaseViewModel
    {
        private PersonnelDTO _personnel;
        public PersonnelDTO Personnel
        {
            get => _personnel;
            set
            {
                _personnel = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdatePersonnelCommand { get; }
        public ICommand CancelCommand { get; }

        public UpdatePersonnelViewModel(PersonnelDTO personnel)
        {
            Personnel = personnel;
            UpdatePersonnelCommand = new RelayCommand(UpdatePersonnel);
            CancelCommand = new RelayCommand(Cancel);
        }

        private static void UpdateBindingSource(Window window, string textBoxName)
        {
            var textBox = window.FindName(textBoxName) as TextBox;
            textBox?.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
        }

        public void UpdatePersonnel(object? parameter)
        {
            if (parameter is Window window)
            {
                UpdateBindingSource(window, "NameTextBox");
                UpdateBindingSource(window, "SurnameTextBox");
                UpdateBindingSource(window, "PositionTextBox");
                UpdateBindingSource(window, "SalaryTextBox");

                var personnels = JsonDataHandler.LoadDataFromJson<PersonnelDTO>("src/KolejeStudenckie/Data/personnels.json");
                var existingPersonnel = personnels.FirstOrDefault(p => p.Id == Personnel.Id);
                if (existingPersonnel != null)
                {
                    existingPersonnel.Name = Personnel.Name;
                    existingPersonnel.Surname = Personnel.Surname;
                    existingPersonnel.Position = Personnel.Position;
                    existingPersonnel.Salary = Personnel.Salary;
                }
                JsonDataHandler.SaveDataToJson("src/KolejeStudenckie/Data/personnels.json", personnels);
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
