using KolejeStudenckie.DTO;
using KolejeStudenckie.DTO.Interfaces;
using KolejeStudenckie.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejeStudenckie.ViewModel
{
    internal class SchedulePanelViewModel : BaseViewModel
    {
        public ObservableCollection<IDTO> Schedules { get; set; }

        public SchedulePanelViewModel()
        {
            Schedules = new ObservableCollection<IDTO>();
            RefreshSchedules();
            ScheduleManagementViewModel.SchedulesChanged += OnSchedulesChanged;
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
        }
    }
}
