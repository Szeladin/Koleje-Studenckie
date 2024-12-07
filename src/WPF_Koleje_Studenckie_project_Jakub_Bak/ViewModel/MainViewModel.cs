using System.Windows.Input;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Views;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand OpenAdminPanelCommand { get; }
        public ICommand OpenMapCommand { get; }

        public MainViewModel()
        {
            OpenAdminPanelCommand = new RelayCommand(OpenAdminPanel);
            OpenMapCommand = new RelayCommand(OpenMap);
        }

        private void OpenAdminPanel()
        {
            var adminPanel = new AdminPanel();
            adminPanel.Show();
        }

        private void OpenMap()
        {
            //var mapWindow = new MapWindow();
            //mapWindow.Show();
        }
    }
}
