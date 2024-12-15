
using System.Windows;


namespace KolejeStudenckie.Views
{
    public partial class TrainManagementWindow : Window
    {
        public TrainManagementWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel.TrainManagementViewModel();
        }
    }
}
