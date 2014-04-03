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
            BranchFactoryCB.ItemsSource = BranchFactory.GetSource();
            WorkshopCB.ItemsSource = Workshop.GetSource((int)BranchFactoryCB.SelectedValue);
            pieChart.ItemsSource=dataGrid1.ItemsSource = HumanResouce.GetPieSumData();
        }

        private void BranchFactoryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            WorkshopCB.ItemsSource = Workshop.GetSource((int)BranchFactoryCB.SelectedValue);
            WorkshopCB.SelectedIndex = 0;
        }
    }
}
