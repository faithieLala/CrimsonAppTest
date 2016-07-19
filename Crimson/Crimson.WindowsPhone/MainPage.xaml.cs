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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Crimson
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
        private void statusclick(object sender, RoutedEventArgs e)
        {
            Maintext.Text = "changed";
            this.Frame.Navigate(typeof(Checkstat));
        }

        private void quickfactsclicked(object sender, RoutedEventArgs e)
        {
            Maintext.Text = "quickfacts";
            this.Frame.Navigate(typeof(QuickFacts));
        }

        private void Analysisclicked(object sender, RoutedEventArgs e)
        {
            Maintext.Text = "Analysis";
            this.Frame.Navigate(typeof(Analysis));
        }

        private void aboutclicked(object sender, RoutedEventArgs e)
        {
            Maintext.Text = "about";
            this.Frame.Navigate(typeof(AboutPage));
        }

        private void signin_clicked(object sender, RoutedEventArgs e)
        {
            Maintext.Text = "Sign in";
            this.Frame.Navigate(typeof(Signin_page));
        }

        private void MapClicked(object sender, RoutedEventArgs e)
        {
            Maintext.Text = "Maps";
            this.Frame.Navigate(typeof(Location));
        }

        private void TravelClicked(object sender, RoutedEventArgs e)
        {
            Maintext.Text = "Travel";
            this.Frame.Navigate(typeof(Travel));
        }
    }
}
