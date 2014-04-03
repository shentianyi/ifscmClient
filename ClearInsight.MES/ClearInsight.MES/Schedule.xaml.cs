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
using ClearInsight.MES.ViewModel;

namespace ClearInsight.MES
{
    /// <summary>
    /// Schedule.xaml 的交互逻辑
    /// </summary>
    public partial class Schedule : Window
    {
        public Schedule()
        {
            InitializeComponent();
            init(); 
        }

        private void init()
        {
            ContractDG.ItemsSource = ContractProduct.GetSource();
            BranchFactoryCB.ItemsSource = BranchFactory.GetSource();
            WorkshopCB.ItemsSource = Workshop.GetSource((int)BranchFactoryCB.SelectedValue);
           
        }

        private void ShowContractDetailBT_Click(object sender, RoutedEventArgs e)
        {
            new ContractDetail().ShowDialog();
        }

        private void BranchFactoryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WorkshopCB.ItemsSource = Workshop.GetSource((int)BranchFactoryCB.SelectedValue);
            WorkshopCB.SelectedIndex = 0;
        }

        private void PublishBT_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("发布成功！");
        }
    }
}
