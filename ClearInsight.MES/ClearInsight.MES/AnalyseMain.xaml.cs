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
    /// AnalyseMain.xaml 的交互逻辑
    /// </summary>
    public partial class AnalyseMain : Window
    {
        public AnalyseMain()
        {
            InitializeComponent();
            init(); 
        }

        private void init()
        {
            StartDP.SelectedDate = DateTime.Now.AddDays(-6);
            BranchFactoryCB.ItemsSource = BranchFactoryCB2.ItemsSource = BranchFactory.GetSource();
            WorkshopCB.ItemsSource = WorkshopCB2.ItemsSource = Workshop.GetSource((int)BranchFactoryCB.SelectedValue);
            pieChart.ItemsSource=dataGrid1.ItemsSource = HumanResouce.GetPieSumData();
            foreach (UIElement child in WorkshopGrid.Children) {
                if (child.GetType().Name == "Button") {
                    ((Button)child).Click += Button_Click;
                }
            }
        }

        private void BranchFactoryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            WorkshopCB.ItemsSource = Workshop.GetSource((int)BranchFactoryCB.SelectedValue);
            WorkshopCB.SelectedIndex = 0;
        }

        private void BranchFactoryCB2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WorkshopCB2.ItemsSource = Workshop.GetSource((int)BranchFactoryCB2.SelectedValue);
            WorkshopCB2.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new OEELine().ShowDialog();
        }
    }
}
