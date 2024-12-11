using System.Windows;

namespace KolejeStudenckie.Views
{
    public partial class AddTrainWindow : Window
    {
        public AddTrainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel.AddTrainViewModel();
        }
    }
}
