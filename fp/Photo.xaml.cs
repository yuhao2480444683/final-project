using fp.Models;
using Microsoft.EntityFrameworkCore;
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
    public sealed partial class Photo : Page
    {
        public Photo()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            myName.Text = App.thisuser.UserName;
            myPassward.Password = App.thisuser.Password;

        }


        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if(myPassward.Password != App.thisuser.Password && myPassword2.Password == myPassward.Password)
            {
                var Announcement = await Database.Context.Users.SingleOrDefaultAsync(m => m.Id == App.thisuser.Id);
                if (Announcement != null)
                {
                    Announcement.Password = myPassword2.Password;
                    await Database.Context.SaveChangesAsync();
                }
                PhotoFrame.Navigate(typeof(Photo));
            }


        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            PhotoFrame.Navigate(typeof(MainPage));
        }
    }
}
