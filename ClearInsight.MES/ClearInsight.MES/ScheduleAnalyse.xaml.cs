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
using Infragistics.Controls.Charts;

namespace ClearInsight.MES
{
    /// <summary>
    /// ScheduleAnalyse.xaml 的交互逻辑
    /// </summary>
    public partial class ScheduleAnalyse : Window
    {
        public ScheduleAnalyse()
        {
            InitializeComponent();
            init();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void init() {

            StartDP.SelectedDate = DateTime.Now.AddDays(-6);
            ScheduleDG.ItemsSource = new ScheduleFailCollection();
            List<ScheduleFailReason> reasons=ScheduleFailReason.GetSource();
            reasons.Insert(0, new ScheduleFailReason());
            ReasonCB.ItemsSource = reasons;
        }

        private void ReasonCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReasonCB.SelectedIndex > 0) {
             
              
            } else{
                //int count = DataChart.Series.Count;
                //for (int i = 0; i < count; i++)
                //    DataChart.Series.RemoveAt(0);
                //List<ScheduleFailReason> reasons = ScheduleFailReason.GetSource();
            }
        }
    }
}
