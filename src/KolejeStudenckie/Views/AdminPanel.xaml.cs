using System.Windows;

namespace KolejeStudenckie.Views
{
    public partial class AdminPanelWindow : Window
    {
        public AdminPanelWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel.AdminPanelViewModel();
        }
    }
}
