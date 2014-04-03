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
    /// ScheduleAnalyse.xaml 的交互逻辑
    /// </summary>
    public partial class ScheduleAnalyse : Window
    {
        public ScheduleAnalyse()
        {
            InitializeComponent();
            StartDP.SelectedDate = DateTime.Now.AddDays(-6);
            ScheduleDG.ItemsSource =new ScheduleFailCollection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
