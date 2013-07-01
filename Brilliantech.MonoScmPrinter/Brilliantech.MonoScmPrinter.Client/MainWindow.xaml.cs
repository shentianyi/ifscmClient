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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Brilliantech.MonoScmPrinter.ClientCL.Model;
using Brilliantech.MonoScmPrinter.ClientCL.RestApis;
using Brilliantech.MonoScmPrinter.ClientCL.IRestApis;
using Brilliantech.MonoScmPrinter.ClientCL.Enums;
using System.ComponentModel;
using Brilliantech.MonoScmPrinter.ClientCL;
using Brilliantech.MonoScmPrinter.ClientCL.CusExceptions;
using System.Net;

namespace Brilliantech.MonoScmPrinter.Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        BackgroundWorker backWorker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();
            backWorker.DoWork += new DoWorkEventHandler(backWorker_DoWork);
            backWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backWorker_RunWorkerCompleted);            
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Login()
        {
            try
            {
                if (name_tb.Text.Length > 0 && password_pb.Password.Length > 0)
                {
                    EnableLoginInput(false);
                    backWorker.RunWorkerAsync(new string[] { name_tb.Text, password_pb.Password });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                IRestAuther auther = new RestAuther();
                string[] args = e.Argument as string[];
                e.Result = auther.Login(args[0], args[1]);
            }
            catch (RestHostMissingException ex)
            {
                e.Result = new ReturnMsg<LoginInfo>() { result = false, content = ex.Message };
            }
        } 
        private void backWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableLoginInput(true);
            ReturnMsg<LoginInfo> info = e.Result as ReturnMsg<LoginInfo>;
            if (info.result)
            {
                Session.Set("LoginInfo", info.@object);
                NaviWindow navi = new NaviWindow();
                Application.Current.MainWindow = navi;
                this.Close();
                navi.Show();
            }
            else
            {
                this.Show();
                new MsgBox(MsgLevel.Mistake, info.content).ShowDialog();
            }
        }

        private void EnableLoginInput(bool enable)
        {
            name_tb.IsEnabled = enable;
            password_pb.IsEnabled = enable;
            login_btn.IsEnabled = enable;
            login_probar.Visibility = enable ? Visibility.Hidden : Visibility.Visible;
        }

        private void setting_btn_Click(object sender, RoutedEventArgs e)
        {
            ShowSettigDialog();
        }


        private void setting_lb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ShowSettigDialog();
        }

        private void ShowSettigDialog()
        {
            new PreSetting().ShowDialog();
        }
    }
}
