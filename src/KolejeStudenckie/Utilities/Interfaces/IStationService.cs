using KolejeStudenckie.DTO;
using System.Collections.ObjectModel;

namespace KolejeStudenckie.Utilities
{
    public interface IStationService
    {
        ObservableCollection<StationDTO> GetStations();
        void RefreshStationTrainList(ObservableCollection<StationDTO> stations);
    }
}