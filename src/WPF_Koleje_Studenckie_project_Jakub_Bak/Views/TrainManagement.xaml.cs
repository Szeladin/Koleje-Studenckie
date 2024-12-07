using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.Views
{
    public partial class TrainManagement : Window
    {
        public TrainManagement()
        {
            InitializeComponent();
            DataContext = new TrainManagementViewModel();
        }
    }
}
