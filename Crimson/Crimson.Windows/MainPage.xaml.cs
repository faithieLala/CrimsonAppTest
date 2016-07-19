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
        }

        private void statusclick(object sender, RoutedEventArgs e)
        {
            Maintext.Text = "changed";
            this.Frame.Navigate(typeof(checkstat));
        }

        private void quickfactsclicked(object sender, RoutedEventArgs e)
        {
            Maintext.Text = "quickfacts";
            this.Frame.Navigate(typeof(QuickFacts));
        }

        private void Travelclicked(object sender, RoutedEventArgs e)
        {
            Maintext.Text = "Travel";
            this.Frame.Navigate(typeof(Travel));
        }
        private void Analysisclicked(object sender, RoutedEventArgs e)
        {
            Maintext.Text = "Analysis";
            this.Frame.Navigate(typeof(Travel));
        }

        private void aboutclicked(object sender, RoutedEventArgs e)
        {
            Maintext.Text = "about";
            this.Frame.Navigate(typeof(AboutPage));
        }

        private void signin_clicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
