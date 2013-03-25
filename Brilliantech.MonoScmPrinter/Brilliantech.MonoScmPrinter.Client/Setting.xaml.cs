﻿using System;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using Brilliantech.MonoScmPrinter.ClientCL;
using System.Drawing;
using System.Drawing.Printing;
using TECIT.TFORMer;
using Brilliantech.MonoScmPrinter.ClientCL.Enums;
using Microsoft.Win32;
using Brilliantech.MonoScmPrinter.ClientCL.Model;
using System.Runtime.InteropServices;

namespace Brilliantech.MonoScmPrinter.Client
{
    /// <summary>
    /// Setting.xaml 的交互逻辑
    /// </summary>
    public partial class Setting : MetroWindow
    {

        public Setting()
        {
            InitializeComponent();
            LoadDefaultSettings();
        }
        private void LoadDefaultSettings()
        {
            try
            {
                foreach (string printer in PrinterSettings.InstalledPrinters)
                    fax_combo.Items.Add(printer);
                for (int i = 0; i < fax_combo.Items.Count; i++)
                {
                    if (fax_combo.Items[i].Equals(PrinterConfig.PrinterName))
                    {
                        fax_combo.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < faxtype_combo.Items.Count; i++)
                {
                    if (int.Parse((faxtype_combo.Items[i] as ComboBoxItem).Tag.ToString()) == (int)PrinterConfig.PrinterType)
                    {
                        faxtype_combo.SelectedIndex = i;
                        break;
                    }
                }
                number_page.Text = PrinterConfig.Copy.ToString();
            }
            catch (Exception e)
            {
                new MsgBox(MsgLevel.Mistake, e.Message).ShowDialog();
            }
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }


        private void file_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "打印模版文件|*.tff";
            openFileDialog.Title = "选择打印模版";
            //if ((bool)openFileDialog.ShowDialog())
            //{
            //    file_tb.Text = openFileDialog.FileName;
            //}
        }

        private void confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
            CloseWindow();
        }


        private void apply_btn_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }
        private void CloseWindow()
        {
            this.Close();
        }
        private void SaveSettings()
        {
            ReturnMsg<string> msg = new ReturnMsg<string>() { result = false };
            if (tabitem1.IsSelected)
            {
                msg = new ReturnMsg<string>() { result = false };
                try
                {
                    PrinterConfig.PrinterName = fax_combo.SelectedItem.ToString();
                    PrinterConfig.Copy = int.Parse(number_page.Text);
                    PrinterConfig.PrinterType = (PrinterType)int.Parse((faxtype_combo.SelectedItem as ComboBoxItem).Tag.ToString());
                    PrinterConfig.SaveSettings();
                    msg.result = true;
                    msg.@object = "保存成功";
                }
                catch (Exception e)
                {
                    msg.@object = e.Message;
                }
            }
            //else if (tabitem2.IsSelected)
            //{
            //    if (file_tb.Text.Length > 0)
            //    {
            //        msg = PrinterConfig.CopyTemplate(file_tb.Text);
            //    }
            //}
            MsgLevel level = msg.result ? MsgLevel.Successful : MsgLevel.Mistake;
            new MsgBox(level, msg.@object).ShowDialog();
        }
    }
}