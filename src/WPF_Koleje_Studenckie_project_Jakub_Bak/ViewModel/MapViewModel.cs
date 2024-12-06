
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;


namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class MapViewModel : BaseViewModel
    {
        private double _zoomFactor = 1.0;
        private const double ZoomIncrement = 0.1;
        private const double MinZoomFactor = 0.1; 
        private ObservableCollection<UIElement> _gridLines;
        public ObservableCollection<UIElement> GridLines
        {
            get => _gridLines;
            set
            {
                _gridLines = value;
                OnPropertyChanged();
            }
        }

        public double ZoomFactor
        {
            get => _zoomFactor;
            set
            {
                if (_zoomFactor != value)
                {
                    _zoomFactor = value;
                    OnPropertyChanged();
                    DrawGrid();
                }
            }
        }

        public ICommand ZoomInCommand { get; }
        public ICommand ZoomOutCommand { get; }
        public ICommand MouseWheelCommand { get; }

        public MapViewModel()
        {
            GridLines = new ObservableCollection<UIElement>();
            ZoomInCommand = new RelayCommand(ZoomIn);
            ZoomOutCommand = new RelayCommand(ZoomOut);
            MouseWheelCommand = new RelayCommand<MouseWheelEventArgs>(OnMouseWheel);
            DrawGrid();
        }

        private void ZoomIn()
        {
            ZoomFactor += ZoomIncrement;
        }

        private void ZoomOut()
        {
            if (ZoomFactor > MinZoomFactor + ZoomIncrement)
            {
                ZoomFactor -= ZoomIncrement;
            }
        }

        private void OnMouseWheel(MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                ZoomIn();
            }
            else if (e.Delta < 0)
            {
                ZoomOut();
            }
        }

        private void DrawGrid()
        {
            GridLines.Clear();
            double gridSize = 50 * ZoomFactor;

            for (double x = 0; x < 800; x += gridSize)
            {
                var line = new Line
                {
                    X1 = x,
                    Y1 = 0,
                    X2 = x,
                    Y2 = 600,
                    Stroke = Brushes.Gray,
                    StrokeThickness = 0.5
                };
                GridLines.Add(line);
            }

            for (double y = 0; y < 600; y += gridSize)
            {
                var line = new Line
                {
                    X1 = 0,
                    Y1 = y,
                    X2 = 800,
                    Y2 = y,
                    Stroke = Brushes.Gray,
                    StrokeThickness = 0.5
                };
                GridLines.Add(line);
            }
        }
    }
}
