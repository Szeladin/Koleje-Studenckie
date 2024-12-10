using KolejeStudenckie.DTO;
using System.Windows;

namespace KolejeStudenckie.Views
{
    public partial class UpdateTrainWindow : Window
    {
        private readonly ViewModel.UpdateTrainViewModel _viewModel;

        public UpdateTrainWindow(TrainDTO train)
        {
            InitializeComponent();
            _viewModel = new ViewModel.UpdateTrainViewModel(train);
            DataContext = _viewModel;
        }
    }
}
