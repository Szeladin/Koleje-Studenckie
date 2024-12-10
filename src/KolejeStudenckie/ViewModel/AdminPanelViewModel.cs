using KolejeStudenckie.Commands;
using System.Windows.Input;

namespace KolejeStudenckie.ViewModel
{
    internal class AdminPanelViewModel : BaseViewModel
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

        private void OpenTrainManagement(object? paremeter)
        {
            var trainManagementWindow = new Views.TrainManagementWindow();
            trainManagementWindow.Show();
        }

        private void OpenPersonnelManagement(object? paremeter)
        {
            var personnelManagementWindow = new Views.PersonnelManagementWindow();
            personnelManagementWindow.Show();
        }

        private void OpenScheduleManagement(object? paremeter)
        {
            var scheduleManagementWindow = new Views.ScheduleManagementWindow();
            scheduleManagementWindow.Show();
        }
    }
}
