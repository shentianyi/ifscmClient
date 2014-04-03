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
using Infragistics.Controls.Maps;

namespace ClearInsight.MES
{
    /// <summary>
    /// BomSet.xaml 的交互逻辑
    /// </summary>
    public partial class BomSet : Window
    {
        public BomSet()
        {
            InitializeComponent();
            OrgChart.ZoomIn();
        }

      

        private void OrgChart_SelectedNodesCollectionChanged(object sender, OrgChartNodeSelectionEventArgs e)
        {
            if (e != null && e.CurrentSelectedNodes != null && e.CurrentSelectedNodes.FirstOrDefault() != null)
            {
                string name = (e.CurrentSelectedNodes.FirstOrDefault().Data as ZipProcess).Name;
                List<ZipProcessDetail> details = ZipProcessDetail.GetResource(name);
                if (details != null) {
                    if (details.Count==1)
                    {
                        ValueLabel.Visibility = Visibility.Visible;
                        ValueLabel.Content = "数量：" + details[0].Value.ToString();
                        ProcessDetailDG.Visibility = Visibility.Hidden;
                    }
                    else {
                        ProcessDetailDG.Visibility = Visibility.Visible;
                        ValueLabel.Visibility = Visibility.Hidden;
                        ProcessDetailDG.ItemsSource = details;
                    }
                }
            }
        }
    }
}
