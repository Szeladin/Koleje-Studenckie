using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;
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
        }

        public object NewTrain { get; internal set; }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.ValidateInput(NameTextBox.Text, MaxSpeedTextBox.Text, CarriageCountTextBox.Text, out string errorMessage))
            {
                _viewModel.AddTrain(ShortGuidHandler.GenerateUniqueShortGuid("Train-"), NameTextBox.Text, int.Parse(MaxSpeedTextBox.Text), int.Parse(CarriageCountTextBox.Text));
                NewTrain = _viewModel.NewTrain;
                this.Close();
            }
            else
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
