using Domain.Entities;
using System.Windows;
using WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel;

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
            _viewModel.DialogResultChanged += (s, e) =>
            {
                this.DialogResult = _viewModel.DialogResult;
                if (this.DialogResult == true || this.DialogResult == false)
                {
                    this.Close();
                }
            };
        }

        public Personel? NewPersonel => _viewModel.NewPersonel;
    }
}
