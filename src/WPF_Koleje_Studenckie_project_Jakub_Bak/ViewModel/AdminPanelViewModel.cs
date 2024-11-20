using System.Windows.Input;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AdminPanelViewModel : BaseViewModel
    {
        public ICommand OpenTrainManagementCommand { get; }
        public ICommand OpenCargoManagementCommand { get; }
        public ICommand OpenPersonnelManagementCommand { get; }
        public ICommand OpenScheduleManagementCommand { get; }

        public AdminPanelViewModel()
        {
            OpenTrainManagementCommand = new RelayCommand(OpenTrainManagement);
            OpenCargoManagementCommand = new RelayCommand(OpenCargoManagement);
            OpenPersonnelManagementCommand = new RelayCommand(OpenPersonnelManagement);
            OpenScheduleManagementCommand = new RelayCommand(OpenScheduleManagement);
        }

        private void OpenTrainManagement()
        {
            var trainManagementWindow = new TrainManagementWindow();
            trainManagementWindow.Show();
        }

        private void OpenCargoManagement()
        { 
        }

        private void OpenPersonnelManagement()
        {
        }

        private void OpenScheduleManagement()
        {
        }
    }
}
