using KolejeStudenckie.DTO;
using KolejeStudenckie.Utilities;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace KolejeStudenckie.ViewModel
{
    internal class MapPanelViewModel : BaseViewModel
    {
        public ObservableCollection<StationDTO> Stations { get; set; }
        public ObservableCollection<UIElement> StationElements { get; set; }
        public ObservableCollection<UIElement> GridLines { get; set; }
        public ObservableCollection<string> StationInfoList { get; set; }

        private string _currentDateTime;
        public string CurrentDateTime
        {
            get => _currentDateTime;
            set
            {
                _currentDateTime = value;
                OnPropertyChanged();
            }
        }

        public MapPanelViewModel()
        {
            Stations = new ObservableCollection<StationDTO>(JsonDataHandler.LoadDataFromJson<StationDTO>("src/KolejeStudenckie/Data/stations.json"));
            StationElements = new ObservableCollection<UIElement>();
            GridLines = new ObservableCollection<UIElement>();
            StationInfoList = new ObservableCollection<string>();
            CreateGridLines();
            CreateStationElements();
            PopulateStationInfoList();
            StartDateTimeUpdater();
            RefreshStationTrainList();
        }

        private void CreateGridLines()
        {
            for (int i = 0; i <= 400; i += 10)
            {
                var verticalLine = new Line
                {
                    X1 = i,
                    Y1 = 0,
                    X2 = i,
                    Y2 = 400,
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 0.5
                };
                GridLines.Add(verticalLine);

                var horizontalLine = new Line
                {
                    X1 = 0,
                    Y1 = i,
                    X2 = 400,
                    Y2 = i,
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 0.5
                };
                GridLines.Add(horizontalLine);
            }
        }

        private void CreateStationElements()
        {
            foreach (var station in Stations)
            {
                var ellipse = new Ellipse
                {
                    Width = 10,
                    Height = 10,
                    Fill = Brushes.Blue,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                Canvas.SetLeft(ellipse, station.X - 15); // Przesunięcie 
                Canvas.SetTop(ellipse, station.Y - 15);

                var label = new TextBlock
                {
                    Text = station.Name,
                    Foreground = Brushes.Black,
                    Background = Brushes.White
                };

                Canvas.SetLeft(label, station.X - 10);
                Canvas.SetTop(label, station.Y - 30);

                StationElements.Add(ellipse);
                StationElements.Add(label);
            }
        }

        private void PopulateStationInfoList()
        {
            foreach (var station in Stations)
            {
                StationInfoList.Add($"Name: {station.Name}\n Trains: {string.Join(",\n ", station.TrainIds)}");
            }
        }

        private void StartDateTimeUpdater()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += (sender, args) =>
            {
                CurrentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                RefreshStationTrainList();
            };
            timer.Start();
        }

        private void RefreshStationTrainList()
        {
            var schedules = JsonDataHandler.LoadDataFromJson<ScheduleDTO>("src/KolejeStudenckie/Data/schedules.json");
            var trains = JsonDataHandler.LoadDataFromJson<TrainDTO>("src/KolejeStudenckie/Data/trains.json");
            var currentTime = DateTime.Now;

            foreach (var station in Stations)
            {
                station.TrainIds.Clear();
                var stationSchedules = schedules.Where(s => s.Station == station.Name);
                foreach (var schedule in stationSchedules)
                {
                    if (schedule.ArrivalTime <= currentTime && schedule.DepartureTime > currentTime)
                    {
                        var train = trains.FirstOrDefault(t => t.Id == schedule.TrainId);
                        if (train != null)
                        {
                            station.TrainIds.Add(train.Id);
                        }
                    }
                }
            }
            JsonDataHandler.SaveDataToJson("src/KolejeStudenckie/Data/stations.json", Stations);

            StationInfoList.Clear();
            PopulateStationInfoList();
        }
    }
}
