using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak
{
    public partial class App : Application
    {
        public static AppViewModel ViewModel { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            AppViewModel viewModel = new();
            Application.Current.Resources["AppViewModel"] = viewModel;
        }
    }
}
