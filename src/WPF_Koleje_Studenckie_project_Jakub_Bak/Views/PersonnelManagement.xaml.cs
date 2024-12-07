using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.Views
{
    public partial class PersonnelManagement : Window
    {
        public PersonnelManagement()
        {
            InitializeComponent();
            DataContext = new PersonnelManagementViewModel();
        }
    }
}
