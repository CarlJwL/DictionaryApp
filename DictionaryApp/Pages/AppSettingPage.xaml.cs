﻿using DictionaryApp.Assets.Models;
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
        

        private void ChooseSavingPathButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var picker = new FileSavePicker()
                {
                    SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                    SuggestedFileName = "New Document"
                };
                FilePathTextBlock.Text = picker.SuggestedStartLocation.ToString();
            }
            finally
            {
                FilePathTextBlock.Opacity = 50;
            }
        }
    }
}