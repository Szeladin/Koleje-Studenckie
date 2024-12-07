using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.Views
{
    public partial class ScheduleManagement : Window
    {
        public ScheduleManagement()
        {
            InitializeComponent();
            DataContext = new ScheduleManagementViewModel();
        }
    }
}
