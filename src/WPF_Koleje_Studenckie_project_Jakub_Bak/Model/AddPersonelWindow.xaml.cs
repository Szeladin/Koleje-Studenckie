using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;
using Domain.Entities;
namespace WPF_Koleje_Studenckie_project_Jakub_Bak
{
    public partial class AddPersonelWindow : Window
    {
        private readonly AddPersonelViewModel _viewModel;

        public AddPersonelWindow()
        {
            InitializeComponent();
            _viewModel = new AddPersonelViewModel();
            DataContext = _viewModel;
        }

        public Personel? NewPersonel { get; internal set; }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddPersonelViewModel.ValidateInput(NameTextBox.Text, SurnameTextBox.Text, PositionTextBox.Text, SalaryTextBox.Text, out string errorMessage))
            {
                _viewModel.AddPersonel(ShortGuidHandler.GenerateUniqueShortGuid("Personel-"), NameTextBox.Text, SurnameTextBox.Text, PositionTextBox.Text, int.Parse(SalaryTextBox.Text));
                NewPersonel = _viewModel.NewPersonel;
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
