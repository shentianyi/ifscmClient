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
using Brilliantech.MonoScmPrinter.ClientCL.Model;
using Brilliantech.MonoScmPrinter.ClientCL.IRestApis;
using Brilliantech.MonoScmPrinter.ClientCL.Enums;
using Brilliantech.MonoScmPrinter.ClientCL.CusExceptions;
using Brilliantech.MonoScmPrinter.ClientCL.RestApis;
using Brilliantech.MonoScmPrinter.Client.ViewModel;

namespace Brilliantech.MonoScmPrinter.Client
{

    /// <summary>
    /// DnCheckPage.xaml 的交互逻辑
    /// </summary>
    public partial class DnCheckPage : Page
    {
        LoginInfo loginInfo;
        IRestDelivery restDelivery;
        List<string> scanedPack;

        public DnCheckPage(LoginInfo loginInfo)
        {
            InitializeComponent();
            this.loginInfo = loginInfo;
            scanedPack = new List<string>();
        }


        private void DnCheckPage_Loaded(object sender, RoutedEventArgs e)
        {
            restDelivery = new RestDelivery();
            DnTB.Focus();
        }

        private void DnTB_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (DnTB.Text.Trim().Length > 0 && e.Key == Key.Enter)
                {
                    string dnKey = DnTB.Text.Trim();
                    List<DeliveryItemViewModel> items = DeliveryItemViewModel.VMConvertor(restDelivery.DnItemList(dnKey));
                    if (items.Count == 0)
                    {
                        new MsgBox(MsgLevel.Warning, dnKey + "不存在或已经被取消").ShowDialog();
                        PackListBox.ItemsSource = null;
                        PackTB.IsEnabled = false;
                    }
                    else
                    {
                        PackListBox.ItemsSource = items;
                        PackNumLab.Text = items.Count.ToString();
                        DnTB.IsEnabled = false;
                        CancelBtn.IsEnabled = CompleteBtn.IsEnabled = PackTB.IsEnabled = !DnTB.IsEnabled;
                    }
                }
            }
            catch (Exception ex)
            {
                new MsgBox(MsgLevel.Warning, ex.Message);
            }
        }

        private void PackTB_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (PackTB.Text.Trim().Length > 0 && e.Key == Key.Enter && !scanedPack.Contains(PackTB.Text))
                {
                    scanedPack.Add(PackTB.Text);
                    List<DeliveryItemViewModel> items = PackListItems();
                    DeliveryItemViewModel item = items.SingleOrDefault(i => i.key.Equals(PackTB.Text));
                    ScanedNumLab.Text = (int.Parse(ScanedNumLab.Text.ToString()) + 1).ToString();
                    if (item != null)
                    {
                        items.Remove(item);
                        item.BorderColor = "#FF1297cf";
                        item.IsScaned = true;
                        item.BorderThickness = 2;
                        items.Add(item);
                        items.Sort();
                        PackListBox.ItemsSource = null;
                        PackListBox.ItemsSource = items;
                        CorrectNumLab.Text = (int.Parse(CorrectNumLab.Text.ToString()) + 1).ToString();
                    }
                    else
                    {
                        WrongNumLab.Text = (int.Parse(WrongNumLab.Text.ToString()) + 1).ToString();
                    }
                    PackTB.Text = "";
                }
            }
            catch (Exception ex)
            {
                new MsgBox(MsgLevel.Warning, ex.Message).ShowDialog();
            }
        }

        private List<DeliveryItemViewModel> PackListItems()
        {
            return (PackListBox.ItemsSource as List<DeliveryItemViewModel>);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)new MsgBox(MsgLevel.Question, "确定取消？").ShowDialog())
            {
                RestControls();
            }
        }

        private void CompleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(CorrectNumLab.Text) == int.Parse(PackNumLab.Text))
            {
                if ((bool)new MsgBox(MsgLevel.Question, "确认运单到达？").ShowDialog())
                {
                    DoDnArrive();
                }
            }
            else if ((bool)new MsgBox(MsgLevel.Question, "核对数量不符，确认运单到达？").ShowDialog())
            {
                DoDnArrive();
            }
        }

        private void DoDnArrive()
        {
            try
            {
                ReturnMsg<string> msg = restDelivery.DnArrive(loginInfo.orgId, DnTB.Text);
                if (!msg.result)
                {
                    new MsgBox(MsgLevel.Mistake, msg.content).ShowDialog();
                }
                else
                {
                    new MsgBox(MsgLevel.Successful, "操作成功！").ShowDialog();
                    RestControls();
                }
            }
            catch (Exception ex)
            {
                new MsgBox(MsgLevel.Warning, ex.Message).ShowDialog();
            }
        }
        private void RestControls()
        {
            PackListBox.ItemsSource = null;
            PackTB.Text = DnTB.Text = "";
            DnTB.IsEnabled = true;
            CompleteBtn.IsEnabled = CancelBtn.IsEnabled = PackTB.IsEnabled = !DnTB.IsEnabled;
            scanedPack.Clear();
            ScanedNumLab.Text = PackNumLab.Text = CorrectNumLab.Text = WrongNumLab.Text = "0";
        }
    }
}
