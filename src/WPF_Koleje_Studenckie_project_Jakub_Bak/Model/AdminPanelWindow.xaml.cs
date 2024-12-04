using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak
{
    public partial class AdminPanelWindow : Window
    {
        public AdminPanelWindow()
        {
            InitializeComponent();
            DataContext = new AdminPanelViewModel();
        }

        private void TrainManagement_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (AdminPanelViewModel)DataContext;
            viewModel.OpenTrainManagementCommand.Execute(null);
        }
        private void PersonnelManagement_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (AdminPanelViewModel)DataContext;
            viewModel.OpenPersonnelManagementCommand.Execute(null);
        }

        private void ScheduleManagement_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (AdminPanelViewModel)DataContext;
            viewModel.OpenScheduleManagementCommand.Execute(null);
        }
    }
}
