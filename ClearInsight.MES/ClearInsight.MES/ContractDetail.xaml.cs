﻿using System;
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
using Infragistics.Controls.Timelines;

namespace ClearInsight.MES
{
    /// <summary>
    /// ContractDetail.xaml 的交互逻辑
    /// </summary>
    public partial class ContractDetail : Window
    {
        public ContractDetail()
        {
            InitializeComponent();
            ContractLB.ItemsSource = Contract.GetSource();
            this.Loaded += OnSampleLoaded;
        }

        private void ContractLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ContractLB.SelectedIndex != -1) {
                Contract contract = ContractLB.SelectedItem as Contract;
                StateL.Content = contract.State;
                ArrangeStaffL.Content = contract.ArrangeStaff;
                TimeL.Content = contract.Time;
                OnSampleLoaded(sender,e);
            }
        }
         

        void OnSampleLoaded(object sender, RoutedEventArgs e)
        {
            this.timeline.Series.Clear();
            DateTimeSeries series = new DateTimeSeries();
            series.Title = "排产记录";
            Random r = new Random();
            DateTime time = DateTime.Today;
            series.Entries.Add(new DateTimeEntry { Time = time.AddHours(r.Next(10, 30)),  Title = "首次排单：30W" });
            series.Entries.Add(new DateTimeEntry { Time = time.AddHours(r.Next(10, 30)),  Title = "推单:3.5W" });
            series.Entries.Add(new DateTimeEntry { Time = time.AddHours(r.Next(10, 30)), Title = "推单:2W" }); 
            series.Entries.Add(new DateTimeEntry { Time = time.AddHours(r.Next(10, 30)).AddMinutes(15), Title = "提单:5W" });
            this.timeline.Series.Add(series); 
 
        }
    }
}
