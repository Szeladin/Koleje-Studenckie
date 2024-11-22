using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Handlers;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public PersonelHandler _personelHandler;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
