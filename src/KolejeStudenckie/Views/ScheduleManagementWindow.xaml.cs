using System.Windows;

namespace KolejeStudenckie.Views
{
    public partial class ScheduleManagementWindow : Window
    {
        public ScheduleManagementWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel.ScheduleManagementViewModel();
        }
    }
}
