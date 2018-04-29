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
using Microsoft.EntityFrameworkCore;
using fp.Models;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace fp
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Home : Page
    {


        private ObservableCollection<Note> NoteCollection = new ObservableCollection<Note>();


        public Home()
        {
            this.InitializeComponent();
        }

        private async void newButton_Click(object sender, RoutedEventArgs e)
        {
            var n = new Note
            {
                Id = App.NewNoteId,
                UserId = App.ThisUserId,
                Title = textTitle.Text,
                Content = textContent.Text,

            };
            NoteCollection.Add(n);
            Database.Context.Notes.Add(n);
            await Database.Context.SaveChangesAsync();
            

        }
    }
}
