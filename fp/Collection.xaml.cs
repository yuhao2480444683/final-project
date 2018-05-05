using System;
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
    public sealed partial class Collection : Page
    {
        public Collection()
        {
            this.InitializeComponent();
        }
        public void New_Button(string s)
        {
            StackPanel ST1 = new StackPanel();//新建StackPanel
            Button b1 = new Button();//新建Button
            TextBlock t1 = new TextBlock();
            GridView GV1 = new GridView();
            b1.Name = "b" + s;       //设置Button的名字
            ST1.Name = "ST" + s;     //设置StackPanel的名字
            GV1.Name = "GV" + s;
            t1.Text = "I am TextBlock,The Button Name is " + b1.Name + " and the StackPanel name is " + ST1.Name;
            t1.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            b1.Content = "Button";
            b1.HorizontalAlignment = HorizontalAlignment.Right;
            ST1.Orientation = Orientation.Horizontal; //水平放置
            GV1.IsItemClickEnabled = true;
            b1.Click += new RoutedEventHandler(Btn_Click);
            GV1.ItemClick += new ItemClickEventHandler(GridView_Click);
            GV1.Items.Add(t1);
            ST1.Children.Add(GV1);
            ST1.Children.Add(b1);
            StackPanel.Children.Add(ST1);
        }

        private void GridView_Click(Object sender, ItemClickEventArgs e)
        {
            CollectionFrame.Navigate(typeof(Home));
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            string s = "ST" + (sender as Button).Name.Substring(1);
            foreach (StackPanel chk in this.StackPanel.Children.OfType<StackPanel>())
            {
                if (chk.Name == s)
                {
                    StackPanel.Children.Remove(chk);
                }
            }
        }
    }
}
