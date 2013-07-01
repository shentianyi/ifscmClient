using System;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using Brilliantech.MonoScmPrinter.ClientCL;
using System.Drawing;
using System.Drawing.Printing;
using TECIT.TFORMer;
using Brilliantech.MonoScmPrinter.ClientCL.Enums;
using Microsoft.Win32;
using Brilliantech.MonoScmPrinter.ClientCL.Model;
using System.Runtime.InteropServices;

namespace Brilliantech.MonoScmPrinter.Client
{
    /// <summary>
    /// Setting.xaml 的交互逻辑
    /// </summary>
    public partial class PreSetting : MetroWindow
    {

        public PreSetting()
        {
            InitializeComponent();
            LoadDefaultSettings();
        }
        private void LoadDefaultSettings()
        {
            try
            {
                // proxy setting
                switch (SettingConfig.NetProxyType) { 
                    case NetProxyType.NoProxy:
                        NoNetProxyRB.IsChecked = true;
                        break;
                    case NetProxyType.WebBrowserSettingProxy:
                        WebBrowserSettingProxyRB.IsChecked = true;
                        break;
                    default:
                        NoNetProxyRB.IsChecked=true;
                        break;
                }
            }
            catch (Exception e)
            {
                new MsgBox(MsgLevel.Mistake, e.Message).ShowDialog();
            }
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }
         
        private void confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            if (SaveSettings())
            {
                CloseWindow();
            }
        }


        private void apply_btn_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }
        private void CloseWindow()
        {
            this.Close();
        }
        private bool SaveSettings()
        {
            ReturnMsg<string> msg = new ReturnMsg<string>() { result = false };
            try
            {
               if (tabitem1.IsSelected)
                {

                    if ((bool)NoNetProxyRB.IsChecked)
                    {
                        SettingConfig.NetProxyType = NetProxyType.NoProxy;
                    }
                    else if ((bool)WebBrowserSettingProxyRB.IsChecked)
                    {
                        SettingConfig.NetProxyType = NetProxyType.WebBrowserSettingProxy;
                    }
                    SettingConfig.SaveProxySettings();
                    msg.result = true;
                    msg.@object = "保存成功";
                }
            }
            catch (Exception e)
            {
                msg.@object = e.Message;
            }
            MsgLevel level = msg.result ? MsgLevel.Successful : MsgLevel.Mistake;
            new MsgBox(level, msg.@object).ShowDialog();
            return msg.result;
        }
    }
}
