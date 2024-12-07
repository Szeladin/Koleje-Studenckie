using Domain.Entities;
using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak
{
    public partial class AddTrainWindow : Window
    {
        private readonly AddTrainViewModel _viewModel;

        public AddTrainWindow()
        {
            InitializeComponent();
            _viewModel = new AddTrainViewModel();
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
        public Train? NewTrain => _viewModel.NewTrain;
    }
}