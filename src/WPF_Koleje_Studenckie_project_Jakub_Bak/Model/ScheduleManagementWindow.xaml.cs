using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak
{
    public partial class ScheduleManagementWindow : Window
    {
        public ScheduleManagementWindow()
        {
            InitializeComponent();
            DataContext = new ScheduleManagementViewModel();
        }
    }
}
