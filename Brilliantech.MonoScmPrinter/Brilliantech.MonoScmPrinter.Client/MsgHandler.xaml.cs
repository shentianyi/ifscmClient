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
using MahApps.Metro.Controls;

namespace Brilliantech.MonoScmPrinter.Client
{
    /// <summary>
    /// MsgHandler.xaml 的交互逻辑
    /// </summary>
    public partial class MsgHandler : MetroWindow
    {
        public MsgHandler()
        {
            InitializeComponent();
        }
        public MsgHandler(string message)
        {
            InitializeComponent();
            message_lbl.Content = message;
        }
    }
}
