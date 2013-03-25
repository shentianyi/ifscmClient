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
using Brilliantech.MonoScmPrinter.ClientCL.Model;
using Brilliantech.MonoScmPrinter.ClientCL.IRestApis;
using Brilliantech.MonoScmPrinter.ClientCL.RestApis;
using Brilliantech.MonoScmPrinter.ClientCL.Enums;
using Brilliantech.MonoScmPrinter.ClientCL.CusExceptions;
using System.ComponentModel;
using Brilliantech.MonoScmPrinter.BaseCL.Utilities.AliOssUtil;

namespace Brilliantech.MonoScmPrinter.Client
{
    /// <summary>
    /// Operator.xaml 的交互逻辑
    /// </summary>
    public partial class Operator : MetroWindow
    {
        LoginInfo loginInfo;
        IRestDelivery restDelivery;
        IRestFile restFile;
        BackgroundWorker backWorker = new BackgroundWorker();

        public Operator()
        {
            InitializeComponent();
            loginInfo = Session.Get("LoginInfo") as LoginInfo;
            user_tb.Text = loginInfo.staffNr;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            restDelivery = new RestDelivery();
            restFile = new RestFile();
            RefreshDnList();
            print_btn.IsEnabled = false;
            print_btn.Content = "检测模版更新...";
            backWorker.DoWork += new DoWorkEventHandler(CheckPrintTemplateUpdate);
            backWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CheckPrintTemplateUpdateCompleted);
            backWorker.RunWorkerAsync();
        }


        private void ref_btn_Click(object sender, RoutedEventArgs e)
        {
            RefreshDnList();
        }


        private void del_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = list_lbx.SelectedIndex;
                if (index > -1)
                {
                    MsgBox mbox = new MsgBox(MsgLevel.Question, "确定删除？");
                    if ((bool)mbox.ShowDialog())
                    {
                        string dnKey = list_lbx.SelectedValue.ToString();
                        ReturnMsg<string> msg = restDelivery.RemoveFromPrintQueue(dnKey);
                        if (msg.result)
                        {
                            RemoveListBoxItem(dnKey);
                        }
                        else
                        {
                            new MsgBox(MsgLevel.Warning, msg.content);
                        }
                    }
                }
            }
            catch (RestHostMissingException ex)
            {
                new MsgBox(MsgLevel.Warning, ex.Message);
            }
        }


        private void bird_img_MouseEnter(object sender, MouseEventArgs e)
        {
            bird_img.Source = new BitmapImage(new Uri("Images\\bird-thunder.png", UriKind.Relative));
        }

        private void bird_img_MouseLeave(object sender, MouseEventArgs e)
        {
            bird_img.Source = new BitmapImage(new Uri("Images\\bird.png", UriKind.Relative));
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
            new Setting().ShowDialog();
        }

        private void RefreshDnList()
        {
            try
            {
                data_dg.ItemsSource = null;
                list_lbx.ItemsSource = restDelivery.DnList(loginInfo.staffId);
                list_lbx.SelectedIndex = -1;
            }
            catch (RestHostMissingException ex)
            {
                new MsgBox(MsgLevel.Warning, ex.Message);
            }
        }

        private void logout_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            Application.Current.MainWindow = login;
            Session.Set("LoginInfo", null);
            this.Close();
            login.Show();
        }

        private void ListBoxItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ListBoxItem item = sender as ListBoxItem;
                string dnKey = item.Content.ToString();
                List<DeliveryItem> items = restDelivery.DnItemList(dnKey);
                if (items.Count == 0)
                {
                    new MsgBox(MsgLevel.Warning, dnKey + "已经被取消").ShowDialog();
                    RemoveListBoxItem(dnKey);
                }
                else
                {
                    data_dg.ItemsSource = restDelivery.DnItemList(dnKey);
                }
            }
            catch (RestHostMissingException ex)
            {
                new MsgBox(MsgLevel.Warning, ex.Message);
            }
        }

        private void print_btn_Click(object sender, RoutedEventArgs e)
        {
            if(template_combo.SelectedIndex>-1)
            if ((bool)print_cb.IsChecked)
            {
                PrintSelectedDeliveryItem();
            }
            else
            {
                PrintAllDeliveryItem();
            }
        }

        private void PrintAllDeliveryItem()
        {
            try
            {
                string dnKey = string.Empty;
                int selectedIndex = -1;
                if (inputnumber_tb.Text.Trim().Length > 0)
                {
                    dnKey = inputnumber_tb.Text.Trim();
                }
                else
                {
                    selectedIndex = list_lbx.SelectedIndex;
                    if (selectedIndex > -1)
                        dnKey = list_lbx.SelectedValue.ToString();
                }
                if (dnKey.Length > 0)
                {
                    PrintData data = restDelivery.DnItemPrintData(dnKey,int.Parse(template_combo.SelectedValue.ToString()));
                    if (data != null)
                    {
                        DoDnPackPrint(data);
                    }
                    else
                    {
                        new MsgBox(MsgLevel.Warning, dnKey + "不存在或已经被取消").ShowDialog();
                        if (selectedIndex > -1)
                            RemoveListBoxItem(dnKey);
                    }
                }
            }
            catch (RestHostMissingException ex)
            {
                new MsgBox(MsgLevel.Warning, ex.Message);
            }
        }

        private void PrintSelectedDeliveryItem()
        {
            try
            {
                if (data_dg.SelectedItems.Count > 0)
                {
                    string[] diKeys = new string[data_dg.SelectedItems.Count];
                    for (int i = 0; i < data_dg.SelectedItems.Count; i++)
                    {
                        diKeys[i] = (data_dg.SelectedItems[i] as DeliveryItem).key;
                    }
                    PrintData data = restDelivery.DnItemPrintData(diKeys, int.Parse(template_combo.SelectedValue.ToString()));
                    if (data != null)
                    {
                        DoDnPackPrint(data);
                    }
                    else
                    {
                        new MsgBox(MsgLevel.Warning, "运单已经被取消").ShowDialog();
                    }
                }
            }
            catch (RestHostMissingException ex)
            {
                new MsgBox(MsgLevel.Warning, ex.Message);
            }
        }

        private void DoDnPackPrint(PrintData data){
            if (data.result)
            {
                ReturnMsg<string> msg = Printer.Print(data);
                new MsgBox(msg.level, msg.content).ShowDialog();
            }
            else
            {
                new MsgBox(MsgLevel.Mistake, data.content).ShowDialog();
            }
        }

        private void RemoveListBoxItem(string item)
        {
            (list_lbx.ItemsSource as List<string>).Remove(item);
            list_lbx.Items.Refresh();
            data_dg.ItemsSource = null;
            list_lbx.SelectedIndex = -1;
            restDelivery.RemoveFromPrintQueue(item);
        }

        private void inputnumber_tb_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (inputnumber_tb.Text.Trim().Length > 0 && e.Key == Key.Enter)
                {
                    string dnKey = inputnumber_tb.Text.Trim();
                    List<DeliveryItem> items = restDelivery.DnItemList(dnKey);
                    if (items.Count == 0)
                    {
                        new MsgBox(MsgLevel.Warning, dnKey + "不存在或已经被取消").ShowDialog();
                        data_dg.ItemsSource = null;
                    }
                    else
                    {
                        data_dg.ItemsSource = restDelivery.DnItemList(dnKey);
                    }
                }
            }
            catch (RestHostMissingException ex)
            {
                new MsgBox(MsgLevel.Warning, ex.Message);
            }
        }

        private void CheckPrintTemplateUpdate(object sender, DoWorkEventArgs e)
        {
            string[] files = restFile.GetUpdatedTemplate((Session.Get("LoginInfo") as LoginInfo).orgId);
            if (files.Length > 0) {
                Downloader.DownLoadTemplate(files);
            }
        }

        private void CheckPrintTemplateUpdateCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            template_combo.ItemsSource = restDelivery.ClientPackTemplate();
            print_btn.IsEnabled = true;
            print_btn.Content = "打印";
        }
    }
}
