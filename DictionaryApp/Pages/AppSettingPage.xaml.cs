using DictionaryApp.Assets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DictionaryApp.Assets.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppSettingPage : Page
    {
        public AppSettingPage()
        {
            this.InitializeComponent();
        }
        

        private async System.Threading.Tasks.Task ChooseSavingPathButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                var picker = new FileSavePicker()
                {
                    SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                    SuggestedFileName="New Document",
                };
                picker.FileTypeChoices.Add("file", new List<string>() { ".txt", ".sec" });
                Windows.Storage.StorageFile file = await picker.PickSaveFileAsync();
                if (file != null)
                {
                    Windows.Storage.CachedFileManager.DeferUpdates(file);
                    await Windows.Storage.FileIO.WriteTextAsync(file, "japanese");
                    Windows.Storage.Provider.FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
                    if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                    {
                        FilePathTextBlock.Text = picker.SuggestedStartLocation.ToString();
                    }
                    else
                    {
                        FilePathTextBlock.Text = "error, cannot add the file path";
                    }
                }
                else
                {
                    FilePathTextBlock.Text = "error, cannot select the file";
                }
            }
            finally
            {
                FilePathTextBlock.Opacity = 50;
            }
        }

        private async void ChooseSavingPathButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            await ChooseSavingPathButton_ClickAsync(sender, e);
        }
    }
}
