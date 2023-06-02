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

namespace Music_Player.Views
{
    /// <summary>
    /// Lógica de interacción para MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            double height = SystemParameters.FullPrimaryScreenHeight;
            double width = SystemParameters.FullPrimaryScreenWidth;
            double resolution = height * width;
            Ventana.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Ventana.Height = height * .95;
            Ventana.Width = width * .90;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
