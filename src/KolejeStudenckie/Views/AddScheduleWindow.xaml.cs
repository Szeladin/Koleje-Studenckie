using System.Windows;

namespace KolejeStudenckie.Views
{
    public partial class AddScheduleWindow : Window
    {
        public AddScheduleWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel.AddScheduleViewModel();
        }
    }
}
