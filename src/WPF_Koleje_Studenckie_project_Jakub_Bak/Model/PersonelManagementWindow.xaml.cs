using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak
{
    public partial class PersonelManagementWindow : Window
    {
        public PersonelManagementWindow()
        {
            InitializeComponent();
            DataContext = new PersonelManagementViewModel();
        }
    }
}
