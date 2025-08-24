using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace СinemaApp.MVVM.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
