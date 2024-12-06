using System.Windows;
using System.Windows.Input;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak
{
    public partial class MapWindow : Window
    {
        public MapWindow()
        {
            InitializeComponent();
            DataContext = new MapViewModel();
        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (DataContext is MapViewModel viewModel)
            {
                viewModel.MouseWheelCommand.Execute(e);
            }
        }
    }
}
