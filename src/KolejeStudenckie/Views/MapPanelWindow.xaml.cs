using System.Windows;

namespace KolejeStudenckie.Views
{
    public partial class MapPanelWindow : Window
    {
        public MapPanelWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel.MapPanelViewModel();
        }
    }
}
