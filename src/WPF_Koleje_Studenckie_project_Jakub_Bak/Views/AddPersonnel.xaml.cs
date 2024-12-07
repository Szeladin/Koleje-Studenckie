using Domain.Entities;
using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.Views
{
    public partial class AddPersonnel : Window
    {
        private readonly AddPersonnelViewModel _viewModel;

        public AddPersonnel()
        {
            InitializeComponent();
            _viewModel = new AddPersonnelViewModel();
            _viewModel.OnRequestClose += (s, e) => this.Close();
            DataContext = _viewModel;
        }

        public Personnel? NewPersonnel { get; internal set; }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new object[] { NameTextBox.Text, SurnameTextBox.Text, PositionTextBox.Text, SalaryTextBox.Text };
            _viewModel.AddPersonnelCommand.Execute(parameters);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CancelCommand.Execute(null);
        }
    }
}
