using System.Windows;

namespace KolejeStudenckie.Views
{
    public partial class AddPersonnelWindow : Window
    {
        public AddPersonnelWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel.AddPersonnelViewModel();
        }
    }
}
