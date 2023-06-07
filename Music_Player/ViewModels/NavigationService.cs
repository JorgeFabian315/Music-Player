using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Music_Player.ViewModels
{
    public class NavigationService : INotifyPropertyChanged

    {
        private NavigationService()

        {

        }

        private static NavigationService instance;

        private UserControl currentView;

        public UserControl CurrentView

        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }
        public static NavigationService Instance
        {
            get
            {
                if (instance == null)
                    instance = new NavigationService();
                return instance;

            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
  
        public void NavigateTo(UserControl userControl)
        {
            CurrentView = userControl;
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }

}
