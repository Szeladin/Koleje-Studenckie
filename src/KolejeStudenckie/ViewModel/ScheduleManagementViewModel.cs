﻿using KolejeStudenckie.Commands;
using KolejeStudenckie.DTO;
using KolejeStudenckie.DTO.Interfaces;
using KolejeStudenckie.Utilities;
using KolejeStudenckie.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace KolejeStudenckie.ViewModel
{
    internal class ScheduleManagementViewModel : BaseViewModel
    {
        public static event EventHandler SchedulesChanged;
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

        private readonly DispatcherTimer _archiveTimer;

        public ScheduleManagementViewModel()
        {
            Schedules = new ObservableCollection<IDTO>();
            _selectedSchedule = null;
            AddScheduleCommand = new RelayCommand(AddSchedule);
            RemoveScheduleCommand = new RelayCommand(RemoveSchedule, CanExecuteRemoveOrUpdate);
            UpdateScheduleCommand = new RelayCommand(UpdateSchedule, CanExecuteRemoveOrUpdate);
            _ = ArchiveOldSchedulesAsync();
            RefreshSchedules();

            _archiveTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMinutes(1)
            };
            _archiveTimer.Tick += async (sender, args) =>
            {
                await ArchiveOldSchedulesAsync();
                RefreshSchedules();
            };
            _archiveTimer.Start();
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
                OnSchedulesChanged();
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
                OnSchedulesChanged();
            }
        }

        private void UpdateSchedule(object? parameter)
        {
            var updateScheduleWindow = new UpdateScheduleWindow(SelectedSchedule);
            if (updateScheduleWindow.ShowDialog() == true)
            {
                RefreshSchedules();
                OnSchedulesChanged();
            }
        }

        private void RefreshSchedules()
        {
            _ = ArchiveOldSchedulesAsync();
            var schedules = JsonDataHandler.LoadDataFromJson<ScheduleDTO>("src/KolejeStudenckie/Data/schedules.json");
            Schedules = new ObservableCollection<IDTO>(schedules);
            OnPropertyChanged(nameof(Schedules));
        }

        private async Task ArchiveOldSchedulesAsync()
        {
            await JsonDataHandler.ArchiveOldSchedulesAsync("src/KolejeStudenckie/Data/schedules.json", "src/KolejeStudenckie/Data/archive_schedules.json", DateTime.Now);
        }

        private void OnSchedulesChanged()
        {
            SchedulesChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
