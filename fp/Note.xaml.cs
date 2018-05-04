using fp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    public sealed partial class note : Page
    {
        public note()
        {
            this.InitializeComponent();
        }

        private async void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            // Open a text file.
            Windows.Storage.Pickers.FileOpenPicker open =
                new Windows.Storage.Pickers.FileOpenPicker();
            open.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            open.FileTypeFilter.Add(".rtf");

            Windows.Storage.StorageFile file = await open.PickSingleFileAsync();

            if (file != null)
            {
                try
                {
                    Windows.Storage.Streams.IRandomAccessStream randAccStream =
                await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

                    // Load the file into the Document property of the RichEditBox.
                    editor.Document.LoadFromStream(Windows.UI.Text.TextSetOptions.FormatRtf, randAccStream);
                }
                catch (Exception)
                {
                    ContentDialog errorDialog = new ContentDialog()
                    {
                        Title = "File open error",
                        Content = "Sorry, I couldn't open the file.",
                        PrimaryButtonText = "Ok"
                    };

                    await errorDialog.ShowAsync();
                }
            }
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Storage.Pickers.FileSavePicker savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;

            // Dropdown of file types the user can save the file as
            savePicker.FileTypeChoices.Add("Rich Text", new List<string>() { ".rtf" });

            // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = "New Document";

            Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                // Prevent updates to the remote version of the file until we 
                // finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(file);
                // write to file
                Windows.Storage.Streams.IRandomAccessStream randAccStream =
                    await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

                editor.Document.SaveToStream(Windows.UI.Text.TextGetOptions.FormatRtf, randAccStream);

                // Let Windows know that we're finished changing the file so the 
                // other app can update the remote version of the file.
                Windows.Storage.Provider.FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
                if (status != Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    Windows.UI.Popups.MessageDialog errorBox =
                        new Windows.UI.Popups.MessageDialog("File " + file.Name + " couldn't be saved.");
                    await errorBox.ShowAsync();
                }
            }
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
            if (selectedText != null)
            {
                Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                charFormatting.Bold = Windows.UI.Text.FormatEffect.Toggle;
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
            if (selectedText != null)
            {
                Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                charFormatting.Italic = Windows.UI.Text.FormatEffect.Toggle;
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void UnderlineButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
            if (selectedText != null)
            {
                Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                if (charFormatting.Underline == Windows.UI.Text.UnderlineType.None)
                {
                    charFormatting.Underline = Windows.UI.Text.UnderlineType.Single;
                }
                else
                {
                    charFormatting.Underline = Windows.UI.Text.UnderlineType.None;
                }
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }



        private void Fontcolor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
            if (selectedText != null)
            {
                var combo = (ComboBox)sender;
                var item = (ComboBoxItem)combo.SelectedItem;
                var fontcolor = item.Content.ToString();
                Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
               
                if (fontcolor =="red")
                {
                    Color c = Color.Red;
                    charFormatting.ForegroundColor = Windows.UI.Colors.Red;
                }
                if (fontcolor == "yellow")
                {
                    Color c = Color.Red;
                    charFormatting.ForegroundColor = Windows.UI.Colors.Yellow;
                }
                if (fontcolor == "blue")
                {
                    Color c = Color.Red;
                    charFormatting.ForegroundColor = Windows.UI.Colors.Blue;
                }
                if (fontcolor == "black")
                {
                    Color c = Color.Red;
                    charFormatting.ForegroundColor = Windows.UI.Colors.Black;
                }
                if (fontcolor == "pink")
                {
                    Color c = Color.Red;
                    charFormatting.ForegroundColor = Windows.UI.Colors.Pink;
                }






            }





        }




        private void FontsizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
            if (selectedText != null)
            {
                var combo = (ComboBox)sender;
                var item =  (ComboBoxItem)combo.SelectedItem;
                var fontsize = item.Content.ToString();
                Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                if (fontsize == "8")
                {
                   
                    charFormatting.Size = 8;

                }
                else if (fontsize == "10")
                {

                    charFormatting.Size = 10;

                }
                else if (fontsize == "12")
                {

                    charFormatting.Size = 12;

                }
                else if (fontsize == "14")
                {

                    charFormatting.Size = 14;

                }
                else if (fontsize == "16")
                {

                    charFormatting.Size = 16;

                }

                selectedText.CharacterFormat = charFormatting;
            }

        }

        private async void Notes_Click(object sender, RoutedEventArgs e)
        {

            if(title.Text !=null || editor.Document!=null)
            {

                var n = new Note
                {
                    Id = App.NewNoteId,
                    UserId = App.ThisUserId,
                    Title = title.Text,
                    Content = editor.Document.ToString(),

                };

                Database.Context.Notes.Add(n);
                await Database.Context.SaveChangesAsync();

            }

        }

    }
}
