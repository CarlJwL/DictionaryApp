using DictionaryApp.Assets.Models;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DictionaryApp.Assets.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public string currentTime => DateTime.Now.ToString("dd MMM YYYY HH:mm:ss");
        public ObservableCollection<Word> words;
        public HomePage()
        {
            this.InitializeComponent();
            words = new ObservableCollection<Word>
            {
                new Word { Name = "ROLL", Explanation = "滚动" }
            };
        }

        private void AddWordButton_Click(object sender, RoutedEventArgs e)
        {
            String selectedLanguage;
            if (LanguageCheckBox.IsSelectionBoxHighlighted)
                selectedLanguage = LanguageCheckBox.SelectionBoxItem.ToString();
            else
                selectedLanguage = "日语";
            words.Add(new Word { Name = (String)AddWordTextBox.Text, Explanation = (String)AddExplantionTextBox.Text, Language = selectedLanguage });
        }
    }
}
