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
using MahApps.Metro.Controls;
using Brilliantech.MonoScmPrinter.ClientCL.Enums;

namespace Brilliantech.MonoScmPrinter.Client
{
    /// <summary>
    /// MsgBox.xaml 的交互逻辑
    /// </summary>
    public partial class MsgBox : MetroWindow
    {
        private static readonly string infoImage = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\info.png");
        private static readonly string warningImage = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\exclamation.png");
        private static readonly string successImage = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\right.png");
        private static readonly string errorImage = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\wrong.png");
        private static readonly string questionImage = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\question.png");

        private System.Timers.Timer timer;


        public MsgBox()
        {
            InitializeComponent();
        }

        public MsgBox(MsgLevel msgLevel, string message)
        {
            InitializeComponent();
            ShowCancelBtn(msgLevel);
            info_tbox.Text = message;
            AssignPicture(msgLevel);
        }

        public void AssignPicture(MsgLevel level)
        {
            string imagePath = "";
            switch (level)
            {
                case MsgLevel.Info:
                    imagePath = infoImage;
                    break;
                case MsgLevel.Mistake:
                    imagePath = errorImage;
                    break;
                case MsgLevel.Successful:
                    imagePath = successImage;
                    break;
                case MsgLevel.Warning:
                    imagePath = warningImage;
                    break;
                case MsgLevel.Question:
                    imagePath = questionImage;
                    break;
            }
            this.info_img.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
        }

        private void confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close(); 
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close(); 
        }

        private void ShowCancelBtn(MsgLevel level)
        {
            if (level == MsgLevel.Question)
            {
                cancel_btn.Visibility = Visibility.Visible;
                confirm_btn.SetValue(Canvas.LeftProperty, 270.0);
                cancel_btn.Content = "否";
                confirm_btn.Content = "是";
            }
        }
    }
}
