using KolejeStudenckie.DTO;
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
        public ObservableCollection<ScheduleDTO> Schedules { get; set; }

        public SchedulePanelViewModel()
        {
            Schedules = new ObservableCollection<ScheduleDTO>(JsonDataHandler.LoadDataFromJson<ScheduleDTO>("src/KolejeStudenckie/Data/schedules.json"));
        }
    }
}
