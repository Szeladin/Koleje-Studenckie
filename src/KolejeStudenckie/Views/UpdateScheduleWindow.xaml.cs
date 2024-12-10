using Domain.Entities;
using KolejeStudenckie.DTO;
using System.Windows;

namespace KolejeStudenckie.Views
{
    public partial class UpdateScheduleWindow : Window
    {
        private readonly ViewModel.UpdateScheduleViewModel _viewModel;
        public UpdateScheduleWindow(ScheduleDTO schedule)
        {
            InitializeComponent();
            _viewModel = new ViewModel.UpdateScheduleViewModel(schedule);
            DataContext = _viewModel;
        }
    }
}
