using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak
{
    public partial class PersonelManagmentWindow : Window
    {
        public PersonelManagmentWindow()
        {
            InitializeComponent();
            DataContext = new PersonelManagmentViewModel();
        }
    }
}
