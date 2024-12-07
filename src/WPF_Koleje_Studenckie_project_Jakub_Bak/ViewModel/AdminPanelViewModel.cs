using System.Windows.Input;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Views;

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
            var trainManagement = new TrainManagement();
            trainManagement.Show();
        }
        private void OpenPersonnelManagement()
        {
            var personelManagement = new PersonnelManagement();
            personelManagement.Show();
        }

        private void OpenScheduleManagement()
        {
            var scheduleManagement = new ScheduleManagement();
            scheduleManagement.Show();
        }
    }
}
