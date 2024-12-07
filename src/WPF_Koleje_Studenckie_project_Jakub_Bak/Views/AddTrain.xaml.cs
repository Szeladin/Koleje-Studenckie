using Domain.Entities;
using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;
namespace WPF_Koleje_Studenckie_project_Jakub_Bak.Views
{
    public partial class AddTrain : Window
    {
        private readonly AddTrainViewModel _viewModel;

        public AddTrain()
        {
            InitializeComponent();
            _viewModel = new AddTrainViewModel();
            _viewModel.OnRequestClose += (s, e) => this.Close();
            DataContext = _viewModel;
        }

        public Train? NewTrain { get; internal set; }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new object[] { NameTextBox.Text, MaxSpeedTextBox.Text, CarriageCountTextBox.Text };
            _viewModel.AddTrainCommand.Execute(parameters);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CancelCommand.Execute(null);
        }
    }
}
