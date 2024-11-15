using System.Windows;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak
{
    public partial class AdminPanelWindow : Window
    {
        public AdminPanelWindow()
        {
            InitializeComponent();
        }

        private void TrainManagement_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow trainManagementWindow = new AdminWindow();
            trainManagementWindow.Show();
        }

        private void CargoManagement_Click(object sender, RoutedEventArgs e)
        {
            // Open Cargo Management Window (to be implemented)
            MessageBox.Show("Cargo Management functionality is not yet implemented.");
        }

        private void PersonnelManagement_Click(object sender, RoutedEventArgs e)
        {
            // Open Personnel Management Window (to be implemented)
            MessageBox.Show("Personnel Management functionality is not yet implemented.");
        }

        private void ScheduleManagement_Click(object sender, RoutedEventArgs e)
        {
            // Open Schedule Management Window (to be implemented)
            MessageBox.Show("Schedule Management functionality is not yet implemented.");
        }
    }
}
