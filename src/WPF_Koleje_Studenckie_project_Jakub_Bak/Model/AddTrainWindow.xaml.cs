using Domain.Entities;

using System.Windows;


namespace WPF_Koleje_Studenckie_project_Jakub_Bak
{
    public partial class AddTrainWindow : Window
    {
        public Train NewTrain { get; private set; }

        public AddTrainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                NewTrain = new Train(
                    NameTextBox.Text,
                    int.Parse(MaxSpeedTextBox.Text),
                    int.Parse(CarriageCountTextBox.Text)
                );
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Please enter a name for the train.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!int.TryParse(MaxSpeedTextBox.Text, out int maxSpeed) || maxSpeed <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for Max Speed.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!int.TryParse(CarriageCountTextBox.Text, out int carriageCount) || carriageCount <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for Carriage Count.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
