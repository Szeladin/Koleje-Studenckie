using KolejeStudenckie.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KolejeStudenckie.Views
{
    /// <summary>
    /// Logika interakcji dla klasy UpdateTrainWindow.xaml
    /// </summary>
    public partial class UpdateTrainWindow : Window
    {
        private readonly ViewModel.UpdateTrainViewModel _viewModel;

        public UpdateTrainWindow(TrainDTO train)
        {
            InitializeComponent();
            _viewModel = new ViewModel.UpdateTrainViewModel(train);
            DataContext = _viewModel;
        }
    }
}
