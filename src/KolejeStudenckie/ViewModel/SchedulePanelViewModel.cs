using KolejeStudenckie.DTO;
using KolejeStudenckie.DTO.Interfaces;
using KolejeStudenckie.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace KolejeStudenckie.ViewModel
{
    internal class SchedulePanelViewModel : BaseViewModel
    {
        public ObservableCollection<IDTO> Schedules { get; set; }
        public ObservableCollection<IDTO> ArchivedSchedules { get; set; }
        private readonly DispatcherTimer _archiveTimer;

        public SchedulePanelViewModel()
        {
            Schedules = new ObservableCollection<IDTO>();
            ArchivedSchedules = new ObservableCollection<IDTO>();
            RefreshSchedules();
            ScheduleManagementViewModel.SchedulesChanged += OnSchedulesChanged;

            _archiveTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _archiveTimer.Tick += (sender, args) =>
            {
                ArchiveOldSchedules();
                RefreshSchedules();
            };
            _archiveTimer.Start();
        }

        private void OnSchedulesChanged(object? sender, EventArgs e)
        {
            RefreshSchedules();
        }

        private void RefreshSchedules()
        {
            Schedules.Clear();
            var schedules = JsonDataHandler.LoadDataFromJson<ScheduleDTO>("src/KolejeStudenckie/Data/schedules.json");
            foreach (var schedule in schedules)
            {
                Schedules.Add(schedule);
            }

            ArchivedSchedules.Clear();
            var archivedSchedules = JsonDataHandler.LoadDataFromJson<ScheduleDTO>("src/KolejeStudenckie/Data/archive_schedules.json");
            foreach (var archivedSchedule in archivedSchedules)
            {
                ArchivedSchedules.Add(archivedSchedule);
            }
        }

        private void ArchiveOldSchedules()
        {
            JsonDataHandler.ArchiveOldSchedules("src/KolejeStudenckie/Data/schedules.json", "src/KolejeStudenckie/Data/archive_schedules.json", DateTime.Now);
        }
    }
}
