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
using DictionaryApp.Assets.Models;
using System.Collections.ObjectModel;
using DictionaryApp.Assets.Pages;
using DictionaryApp.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DictionaryApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage Current=null;
        private List<NavMenuItem> navlist = new List<NavMenuItem>(
            new[]
            {
                new NavMenuItem()
                {
                    Symbol = Symbol.Home,
                    Label = "Home Page",
                    DestinationPage = typeof(HomePage)
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.Library,
                    Label = "Recite Words Page",
                    DestinationPage = typeof(ReciteWordPage)
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.Setting,
                    Label = "Setting Page",
                    DestinationPage = typeof(AppSettingPage)
                },
            });

        public MainPage()
        {
            this.InitializeComponent();
            Current = this;
        }

        private void HamburgerMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuSplitView.IsPaneOpen = !MenuSplitView.IsPaneOpen;
        }

        

        private void HomeBoxItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MenuSplitView.IsPaneOpen = !MenuSplitView.IsPaneOpen;
        }

        private void ReciteBoxItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MenuSplitView.IsPaneOpen = !MenuSplitView.IsPaneOpen;
        }

        private void SettingBoxItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MenuSplitView.IsPaneOpen = !MenuSplitView.IsPaneOpen;
        }

        private void NavMenuItemContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            String name;
            //TODO ss
        }

        private void NavMenuList_ItemInvoked(object sender, ListViewItem e)
        {
            //TODO ss
            String name;
        }
    }
}
