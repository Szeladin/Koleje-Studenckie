using System.Windows.Input;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AdminPanelViewModel : BaseViewModel
    {
        public ICommand OpenTrainManagementCommand { get; }
        public ICommand OpenPersonnelManagementCommand { get; }
        public ICommand OpenScheduleManagementCommand { get; }

        public AdminPanelViewModel()
        {
            OpenTrainManagementCommand = new RelayCommand(OpenTrainManagement);
            OpenPersonnelManagementCommand = new RelayCommand(OpenPersonnelManagement);
            OpenScheduleManagementCommand = new RelayCommand(OpenScheduleManagement);
        }

        private void OpenTrainManagement()
        {
            var trainManagementWindow = new TrainManagementWindow();
            trainManagementWindow.Show();
        }
        private void OpenPersonnelManagement()
        {
            var personelManagementWindow = new PersonelManagementWindow();
            personelManagementWindow.Show();
        }

        private void OpenScheduleManagement()
        {
            var scheduleManagementWindow = new ScheduleManagementWindow();
            scheduleManagementWindow.Show();
        }
    }
}
