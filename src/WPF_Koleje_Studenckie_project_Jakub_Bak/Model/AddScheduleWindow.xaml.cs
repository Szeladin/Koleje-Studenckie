using Domain.Entities;
using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak
{
    public partial class AddScheduleWindow : Window
    {
        private readonly AddScheduleViewModel _viewModel;

        public AddScheduleWindow()
        {
            InitializeComponent();
            _viewModel = new AddScheduleViewModel();
            DataContext = _viewModel;
            _viewModel.DialogResultChanged += (s, e) =>
            {
                this.DialogResult = _viewModel.DialogResult;
                if (this.DialogResult == true || this.DialogResult == false)
                {
                    this.Close();
                }
            };
        }

        public Schedule? NewSchedule => _viewModel.NewSchedule;
    }
}