using KolejeStudenckie.Commands;
using System.Windows.Input;

namespace KolejeStudenckie.ViewModel
{
    internal class MainViewModel : BaseViewModel
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

        private void OpenMapPanel(object? paremeter)
        {
            var mapWindow = new Views.MapPanelWindow();
            mapWindow.Show();
        }

        private void OpenAdminPanel(object? paremeter)
        {
            var adminWindow = new Views.AdminPanelWindow();
            adminWindow.Show();
        }

        private void OpenSchedulePanel(object? paremeter)
        {
            var scheduleWindow = new Views.SchedulePanelWindow();
            scheduleWindow.Show();
        }
    }
}