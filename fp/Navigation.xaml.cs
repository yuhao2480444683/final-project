﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace fp
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Navigation : Page
    {
        public Navigation()
        {
            this.InitializeComponent();
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(Home));
        }
    

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
             //   contentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                //选中项的内容
                switch (args.InvokedItem)
                {
                    case "New":
                        contentFrame.Navigate(typeof(note));
                        break;
                    case "Search":
                        contentFrame.Navigate(typeof(Search));
                        break;
                    case "Collect":
                        contentFrame.Navigate(typeof(Collection));
                        break;
                    case "Home":
                        contentFrame.Navigate(typeof(Home));
                        break;
                    case "Photo":
                        contentFrame.Navigate(typeof(Photo));
                        break;
                }
            }


        }
    }
}
