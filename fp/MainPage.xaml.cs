using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace fp
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

       // private ObservableCollection<String> suggestions;
        private void AutoSuggestBox1_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

            if (args.ChosenSuggestion != null)

                AutoSuggestBox1.Text = args.ChosenSuggestion.ToString();

            else

                AutoSuggestBox1.Text = sender.Text;
        }

        private void AutoSuggestBox1_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            AutoSuggestBox1.Text = "Choosen";
        }

        private void AutoSuggestBox1_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
           /* if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)

            {

                suggestions.Clear();

                suggestions.Add(sender.Text + "1");


                sender.ItemsSource = suggestions;

            }*/
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            SigninFrame.Navigate(typeof(Signup));
        }

        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            //AutoSuggestBox1.Text.ToString();
            //Passwordbox1.Password;
            using (var db = new MyDatabaseContext())
            {
                if (AutoSuggestBox1.Text == null)
                {
                    AutoSuggestBox1.Text = "用户名不能为空";
                }
                else if (Passwordbox1.Password == null)
                {
                    AutoSuggestBox1.Text = "密码不能为空";
                }
                    else
                    {
                        var Announcement = await db.Users.FirstOrDefaultAsync(m => m.UserName == AutoSuggestBox1.Text);

                        if (Announcement == null)
                        {
                            AutoSuggestBox1.Text = "不存在的用户名！";

                        }
                        else if (Announcement.Password != Passwordbox1.Password)
                        {
                                AutoSuggestBox1.Text = "密码输入错误！";
                        }
                            else
                            {
                                 SigninFrame.Navigate(typeof(Navigation));
                            }

                            



                    }

               



             }

        }
    }
}
