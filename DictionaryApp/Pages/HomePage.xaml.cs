using DictionaryApp.Assets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
        public string CurrentTime => DateTime.Now.ToString("dd MMM YYYY HH:mm:ss");
        public ObservableCollection<Word> words;

        public HomePage()
        {
            this.InitializeComponent();
            DispatcherTimer dispatcherTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            dispatcherTimer.Tick += (s, e) => this.TimeTextBlock.Text=CurrentTime;
            dispatcherTimer.Start();
            words = new ObservableCollection<Word>
            {
                new Word { Name = "ROLL", Explanation = "滚动" }
            };
            GetLocationForWeather();
        }

        private async Task GetLocationForWeather()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:
                    HomePage.NotifyUser("Waiting for update...", NotifyType.StatusMessage);

                    // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is 0), DesiredAccuracy.Default is used.
                    Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = _desireAccuracyInMetersValue };

                    // Subscribe to the StatusChanged event to get updates of location status changes.
                    _geolocator.StatusChanged += OnStatusChanged;

                    // Carry out the operation.
                    Geoposition pos = await geolocator.GetGeopositionAsync();

                    UpdateLocationData(pos);
                    HomePage.NotifyUser("Location updated.", NotifyType.StatusMessage);
                    break;

                case GeolocationAccessStatus.Denied:
                    HomePage.NotifyUser("Access to location is denied.", NotifyType.ErrorMessage);
                    LocationDisabledMessage.Visibility = Visibility.Visible;
                    UpdateLocationData(null);
                    break;

                case GeolocationAccessStatus.Unspecified:
                    HomePage.NotifyUser("Unspecified error.", NotifyType.ErrorMessage);
                    UpdateLocationData(null);
                    break;
            }
        }


        async private void OnStatusChanged(Geolocator sender, StatusChangedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                // Show the location setting message only if status is disabled.
                LocationDisabledMessage.Visibility = Visibility.Collapsed;

                switch (e.Status)
                {
                    case PositionStatus.Ready:
                        // Location platform is providing valid data.
                        ScenarioOutput_Status.Text = "Ready";
                        HomePage.NotifyUser("Location platform is ready.", NotifyType.StatusMessage);
                        break;

                    case PositionStatus.Initializing:
                        // Location platform is attempting to acquire a fix.
                        ScenarioOutput_Status.Text = "Initializing";
                        HomePage.NotifyUser("Location platform is attempting to obtain a position.", NotifyType.StatusMessage);
                        break;

                    case PositionStatus.NoData:
                        // Location platform could not obtain location data.
                        ScenarioOutput_Status.Text = "No data";
                        HomePage.NotifyUser("Not able to determine the location.", NotifyType.ErrorMessage);
                        break;

                    case PositionStatus.Disabled:
                        // The permission to access location data is denied by the user or other policies.
                        ScenarioOutput_Status.Text = "Disabled";
                        HomePage.NotifyUser("Access to location is denied.", NotifyType.ErrorMessage);

                        // Show message to the user to go to location settings.
                        LocationDisabledMessage.Visibility = Visibility.Visible;

                        // Clear any cached location data.
                        UpdateLocationData(null);
                        break;

                    case PositionStatus.NotInitialized:
                        // The location platform is not initialized. This indicates that the application
                        // has not made a request for location data.
                        ScenarioOutput_Status.Text = "Not initialized";
                        HomePage.NotifyUser("No request for location is made yet.", NotifyType.StatusMessage);
                        break;

                    case PositionStatus.NotAvailable:
                        // The location platform is not available on this version of the OS.
                        ScenarioOutput_Status.Text = "Not available";
                        HomePage.NotifyUser("Location is not available on this version of the OS.", NotifyType.ErrorMessage);
                        break;

                    default:
                        ScenarioOutput_Status.Text = "Unknown";
                        HomePage.NotifyUser(string.Empty, NotifyType.StatusMessage);
                        break;
                }
            });
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
