using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<String> suggestions;
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

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var username = AutoSuggestBox1.Text.ToString();
            var password = Passwordbox1.Text.ToString();

            if (username == "123" && password == "456" )
            {
                SigninFrame.Navigate(typeof(Navigation));
            }
        }
    }
}
