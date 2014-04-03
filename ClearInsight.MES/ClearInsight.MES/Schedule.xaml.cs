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

        private void PrePublishBT_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int i = r.Next(0, 3);
            if (i == 0)
            {
                MessageBox.Show("试排无警告，可进行发布");
            }
            else if (i == 1)
            {
                MessageBox.Show("库存不足，请核实数据");
            }
            else {

                MessageBox.Show("产能不足，请核实数据");
            }
        }
    }
}
