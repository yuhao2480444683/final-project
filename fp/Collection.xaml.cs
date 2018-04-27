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
        int i = 0;
        public Collection()
        {
            this.InitializeComponent();
        }
        public void New_Button()
        {
            i++;
            StackPanel ST1 = new StackPanel();//新建StackPanel
            Button b1 = new Button();//新建Button
            TextBlock t1 = new TextBlock();
            b1.Name = "b" + i;       //设置Button的名字
            ST1.Name = "ST" + i;     //设置StackPanel的名字
            t1.Text = "I am TextBlock,The Button Name is " + b1.Name + " and the StackPanel name is " + ST1.Name;
            b1.Content = "Button";
            b1.HorizontalAlignment = HorizontalAlignment.Right;
            ST1.Orientation = Orientation.Horizontal;
            /*Double x = 50;
            b1.Height = x;
            ST1.Height = x;
            int num=0;
            num = 5 + 50 * i;
            b1.Margin = new Thickness(num);*/
            b1.Click += new RoutedEventHandler(Btn_Click);
            ST1.Children.Add(t1);
            ST1.Children.Add(b1);
            StackPanel.Children.Add(ST1);
            //Grid.Children.Remove(b1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            New_Button();
        }

        /*public static T FindControl<T>(UIElement parent, Type targetType, string ControlName) where T : FrameworkElement
        {

            if (parent == null) return null;

            if (parent.GetType() == targetType && ((T)parent).Name == ControlName)
            {
                return (T)parent;
            }
            T result = null;
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                UIElement child = (UIElement)VisualTreeHelper.GetChild(parent, i);

                if (FindControl<T>(child, targetType, ControlName) != null)
                {
                    result = FindControl<T>(child, targetType, ControlName);
                    break;
                }
            }
            return result;
        }*/

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            string s = "ST" + (sender as Button).Name.Substring(1);
            //(sender as Button).Content = "Button" + s;
            //var combo = ControlHelper.FindControl<ComboBox>(this, typeof(ComboBox), "ComboBox123");
            //StackPanel.Children.Remove(StackPanel.FindName(s));
            foreach (StackPanel chk in this.StackPanel.Children.OfType<StackPanel>())
            {
                if (chk.Name == s)
                {
                    StackPanel.Children.Remove(chk);
                }
            }
            //b1.Content = "JButton";
        }
    }
}
