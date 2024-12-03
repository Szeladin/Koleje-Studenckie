using Domain.Entities;
using System.Windows;
using System.Windows.Controls;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;
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
        }

        public Schedule? NewSchedule { get; internal set; }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.ValidateInput((string)SelectedTrainIdComboBox.SelectedValue, DepartureTimePicker.Text, ArrivalTimePicker.Text, StationTextBox.Text, out string errorMessage))
            {
                _viewModel.AddSchedule(ShortGuidHandler.GenerateUniqueShortGuid("Schedule-"), (string)SelectedTrainIdComboBox.SelectedValue, DateTime.Parse(DepartureTimePicker.Text), DateTime.Parse(ArrivalTimePicker.Text), StationTextBox.Text);
                NewSchedule = _viewModel.NewSchedule;
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
