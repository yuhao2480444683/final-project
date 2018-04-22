using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UserLibrary;
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
    public sealed partial class Signup : Page
    {
        public Signup()
        {
            this.InitializeComponent();
        }

        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new MyDatabaseContext())
            {

                var user1 = new User { UserName = SignupBox1.Text.ToString() , Password = SignupPasswordBox.Text.ToString() };
                db.Users.Add(user1);
                await db.SaveChangesAsync();
            }





        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            SignupFrame.Navigate(typeof(MainPage));
        }

        private async void QButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new MyDatabaseContext())
            {

                QButton.Content = await db.Users.CountAsync();

            }
        }

        private async void DButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new MyDatabaseContext())
            {
                var user1 = new User { UserName = "123" };
                db.Users.Attach(user1);
                db.Users.Remove(user1);
                await db.SaveChangesAsync();
            }
        }
    }
}
