using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.ViewModels
{
    public class GenerosViewModel : INotifyPropertyChanged
    {










        public event PropertyChangedEventHandler? PropertyChanged;

        public void PropertyChange(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
