using KolejeStudenckie.Commands;
using System.Windows.Input;

namespace KolejeStudenckie.ViewModel
{
    internal class MainViewModel
    {
        public ICommand OpenMapPanelCommand { get; }
        public ICommand OpenAdminPanelCommand { get; }
        public ICommand OpenSchedulePanelCommand { get; }

        public MainViewModel()
        {
            OpenMapPanelCommand = new RelayCommand(OpenMapPanel);
            OpenAdminPanelCommand = new RelayCommand(OpenAdminPanel);
            OpenSchedulePanelCommand = new RelayCommand(OpenSchedulePanel);
        }

        private void OpenMapPanel()
        {
            var mapWindow = new Views.MapPanelWindow();
            mapWindow.Show();
        }

        private void OpenAdminPanel()
        {
            var adminWindow = new Views.AdminPanelWindow();
            adminWindow.Show();
        }

        private void OpenSchedulePanel()
        {
            var scheduleWindow = new Views.SchedulePanelWindow();
            scheduleWindow.Show();
        }
    }
}