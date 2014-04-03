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
using ClearInsight.MES.ViewModel;
using Infragistics;
using Infragistics.Controls.Charts;


namespace ClearInsight.MES
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            init();
            InitializeCharts();
        }

        private void init() {
            BranchFactoryCB.ItemsSource = BranchFactory.GetSource();
            WorkshopCB.ItemsSource = Workshop.GetSource((int)BranchFactoryCB.SelectedValue);
            StartDP.SelectedDate = DateTime.Now.AddDays(-6);
        }

        private void BranchFactoryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WorkshopCB.ItemsSource = Workshop.GetSource((int)BranchFactoryCB.SelectedValue);
            WorkshopCB.SelectedIndex = 0;
        }


        private void InitializeCharts()
        {
            BrushCollection brushes = this.Resources["ChartBrushes"] as BrushCollection;
            BrushCollection outlines = this.Resources["ChartOutlines"] as BrushCollection;

            this.DataChart.Brushes = brushes;
            this.DataChart.Outlines = outlines;
            this.DataChart.MarkerBrushes = brushes;
            this.DataChart.MarkerOutlines = outlines;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new ScheduleAnalyse().ShowDialog();
        }

      

        private void StackedColumnSeries_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            new ContractDetail().ShowDialog();
        }

        private void ScheduleBT_Click(object sender, RoutedEventArgs e)
        {
            new Schedule().ShowDialog();
        }

        private void AnalyseBT_Click(object sender, RoutedEventArgs e)
        {
            new AnalyseMain().ShowDialog();
        }
    }
}
