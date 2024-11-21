using System.Windows.Input;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class RelayCommand(Action execute, Func<bool> canExecute = null) : ICommand
    {
        private readonly Action _execute = execute;
        private readonly Func<bool> _canExecute = canExecute;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

        public void Execute(object parameter) => _execute();

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
