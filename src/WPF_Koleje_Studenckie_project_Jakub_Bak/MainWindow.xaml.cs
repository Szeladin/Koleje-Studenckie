using System.Windows;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Adm(object sender, RoutedEventArgs e)
        {
            AdminPanelWindow adminPanelWindow = new AdminPanelWindow();
            adminPanelWindow.Show();
        }

        private void Button_Click_Map(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_RoJa(object sender, RoutedEventArgs e)
        {

        }
    }
}