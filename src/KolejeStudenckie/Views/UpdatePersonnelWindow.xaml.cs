using KolejeStudenckie.DTO;
using System.Windows;

namespace KolejeStudenckie.Views
{
    public partial class UpdatePersonnelWindow : Window
    {
        private readonly ViewModel.UpdatePersonnelViewModel _viewModel;
        public UpdatePersonnelWindow(PersonnelDTO personnel)
        {
            InitializeComponent();
            _viewModel = new ViewModel.UpdatePersonnelViewModel(personnel);
            DataContext = _viewModel;
        }
    }
}
