using System;
using System.Windows;

/*namespace WPF_Koleje_Studenckie_project_Jakub_Bak
{
    public abstract class BaseDialogWindow<TViewModel> : Window where TViewModel : BaseViewModel
    {
        protected readonly TViewModel _viewModel;

        protected BaseDialogWindow(TViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            _viewModel.DialogResultChanged += OnDialogResultChanged;
        }

        private void OnDialogResultChanged(object? sender, EventArgs e)
        {
            this.DialogResult = _viewModel.DialogResult;
            if (this.DialogResult == true || this.DialogResult == false)
            {
                this.Close();
            }
        }
    }
}
*/