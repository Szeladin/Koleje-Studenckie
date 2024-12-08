using KolejeStudenckie.Commands;
using System.Windows.Input;

namespace KolejeStudenckie.ViewModel
{
    internal class AdminPanelViewModel
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
            var trainManagementWindow = new Views.TrainManagementWindow();
            trainManagementWindow.Show();
        }

        private void OpenPersonnelManagement()
        {
            var personnelManagementWindow = new Views.PersonnelManagementWindow();
            personnelManagementWindow.Show();
        }

        private void OpenScheduleManagement()
        {
            var scheduleManagementWindow = new Views.ScheduleManagementWindow();
            scheduleManagementWindow.Show();
        }
    }
}
