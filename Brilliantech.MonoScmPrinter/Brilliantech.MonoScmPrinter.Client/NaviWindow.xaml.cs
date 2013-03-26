using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace Brilliantech.MonoScmPrinter.Client
{
    /// <summary>
    /// NaviWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NaviWindow : MetroWindow
    {
        public NaviWindow()
        {
            InitializeComponent();
        }

        private void MainPageTB_MouseUp(object sender, MouseButtonEventArgs e)
        { 
            BodyFrame.Navigate(new DnCheckPage());
        }

        private void logout_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            Application.Current.MainWindow = login;
            Session.Set("LoginInfo", null);
            this.Close();
            login.Show();
        }
        private void bird_img_MouseEnter(object sender, MouseEventArgs e)
        {
            bird_img.Source = new BitmapImage(new Uri("Images\\bird-thunder.png", UriKind.Relative));
        }

        private void bird_img_MouseLeave(object sender, MouseEventArgs e)
        {
            bird_img.Source = new BitmapImage(new Uri("Images\\bird.png", UriKind.Relative));
        }


    }
}
