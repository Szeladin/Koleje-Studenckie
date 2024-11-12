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
        }

        public object NewTrain { get; internal set; }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.ValidateInput(NameTextBox.Text, MaxSpeedTextBox.Text, CarriageCountTextBox.Text))
            {
                _viewModel.AddTrain(NameTextBox.Text, int.Parse(MaxSpeedTextBox.Text), int.Parse(CarriageCountTextBox.Text));
                NewTrain = _viewModel.NewTrain;
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
