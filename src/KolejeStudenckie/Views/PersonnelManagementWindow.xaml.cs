using KolejeStudenckie.ViewModel;
using System.Windows;

namespace KolejeStudenckie.Views
{
    public partial class PersonnelManagementWindow : Window
    {
        public PersonnelManagementWindow()
        {
            InitializeComponent();
            DataContext = new PersonnelManagementViewModel();
        }
    }
}
