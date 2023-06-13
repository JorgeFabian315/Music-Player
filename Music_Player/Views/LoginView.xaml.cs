﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Music_Player.Views
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void pwb1_LostFocus(object sender, RoutedEventArgs e)
        {
            txtPassword.Text = "";
            txtPassword.Text = pwb1.Password;
        }

        private void pwb1_Loaded(object sender, RoutedEventArgs e)
        {
            pwb1.Clear();
        }
    }
}
