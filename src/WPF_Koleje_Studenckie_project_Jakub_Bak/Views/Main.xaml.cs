using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main: Window
    {
        public Main()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}