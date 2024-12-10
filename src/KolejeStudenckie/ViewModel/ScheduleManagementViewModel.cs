using KolejeStudenckie.Commands;
using KolejeStudenckie.DTO;
using KolejeStudenckie.DTO.Interfaces;
using KolejeStudenckie.Utilities;
using KolejeStudenckie.Views;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KolejeStudenckie.ViewModel
{
    internal class ScheduleManagementViewModel : BaseViewModel
    {
        public ObservableCollection<IDTO> Schedules { get; set; }
        private ScheduleDTO _selectedSchedule;
        public ScheduleDTO SelectedSchedule
        {
            get => _selectedSchedule;
            set
            {
                _selectedSchedule = value;
                OnPropertyChanged();
                ((RelayCommand)RemoveScheduleCommand).RaiseCanExecuteChanged();
                ((RelayCommand)UpdateScheduleCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand AddScheduleCommand { get; }
        public ICommand RemoveScheduleCommand { get; }
        public ICommand UpdateScheduleCommand { get; }

        public ScheduleManagementViewModel()
        {
            Schedules = new ObservableCollection<IDTO>();
            _selectedSchedule = new ScheduleDTO(string.Empty, string.Empty, DateTime.Now, DateTime.Now, string.Empty);
            AddScheduleCommand = new RelayCommand(AddSchedule);
            RemoveScheduleCommand = new RelayCommand(RemoveSchedule, CanExecuteRemoveOrUpdate);
            UpdateScheduleCommand = new RelayCommand(UpdateSchedule, CanExecuteRemoveOrUpdate);
            RefreshSchedules();
        }

        private bool CanExecuteRemoveOrUpdate(object? parameter)
        {
            return SelectedSchedule != null;
        }

        private void AddSchedule(object? parameter)
        {
            var addScheduleWindow = new AddScheduleWindow();
            if (addScheduleWindow.ShowDialog() == true)
            {
                RefreshSchedules();
            }
        }

        private void RemoveSchedule(object? parameter)
        {
            var schedules = JsonDataHandler.LoadDataFromJson<ScheduleDTO>("src/KolejeStudenckie/Data/schedules.json");
            var scheduleToRemove = schedules.FirstOrDefault(s => s.Id == SelectedSchedule.Id);
            if (scheduleToRemove != null)
            {
                schedules.Remove(scheduleToRemove);
                JsonDataHandler.SaveDataToJson("src/KolejeStudenckie/Data/schedules.json", schedules);
                RefreshSchedules();
            }
        }

        private void UpdateSchedule(object? parameter)
        {
            var updateScheduleWindow = new UpdateScheduleWindow(SelectedSchedule);
            if (updateScheduleWindow.ShowDialog() == true)
            {
                RefreshSchedules();
            }
        }

        private void RefreshSchedules()
        {
            var schedules = JsonDataHandler.LoadDataFromJson<ScheduleDTO>("src/KolejeStudenckie/Data/schedules.json");
            Schedules = new ObservableCollection<IDTO>(schedules);
            OnPropertyChanged(nameof(Schedules));
        }
    }
}
