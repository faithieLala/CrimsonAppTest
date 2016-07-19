using Crimson.Common;
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

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Crimson
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class QuickFacts : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public QuickFacts()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="Common.NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="Common.SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="Common.NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="Common.NavigationHelper.LoadState"/>
        /// and <see cref="Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
            setquickfacttext();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        public void setquickfacttext(TextBlock text0, TextBlock text1, TextBlock text2, TextBlock text3, TextBlock text4)
        {
            TextBlock[] quickblock = new TextBlock[5];
            quickblock[0] = text0;
            quickblock[1] = text1;
            quickblock[2] = text2;
            quickblock[3] = text3;
            quickblock[4] = text4;
            string[] Quickfact = new string[10];
            Quickfact[0] = "quickfact0";
            Quickfact[1] = "quickfact1";
            Quickfact[2] = "quickfact2";
            Quickfact[3] = "quickfact3";
            Quickfact[4] = "quickfact4";
            Quickfact[5] = "quickfact5";
            Quickfact[6] = "quickfact6";
            Quickfact[7] = "quickfact7";
            Quickfact[8] = "quickfact8";
            Quickfact[9] = "quickfact9";
            /* rand = number.Next(0, 9);
             1.Text = Quickfact[rand];
             rand = number.Next(0, 9);
             2.Text = Quickfact[rand];
             rand = number.Next(0, 9);
             3.Text = Quickfact[rand];
             rand = number.Next(0, 9);
             4.Text = Quickfact[rand];
             rand = number.Next(0, 9);
             5.Text = Quickfact[rand];

             for (int i=0;i<=4;i++)
             {
                 quickblock[i].Text = Quickfact[randnumber(j)];
               }   */



        }
        public int randnumber(int rand)
        {
            Random number = new Random();
            int j = number.Next(0, 9);
            if (j == rand)
                randnumber(rand);
            else rand = j;
            return rand;
        }
        public void setquickfacttext()
        {
            Random rand = new Random();
            string[] Quickfact = new string[10];
            Quickfact[0] = "quickfact0";
            Quickfact[1] = "quickfact1";
            Quickfact[2] = "quickfact2";
            Quickfact[3] = "quickfact3";
            Quickfact[4] = "quickfact4";
            Quickfact[5] = "quickfact5";
            Quickfact[6] = "quickfact6";
            Quickfact[7] = "quickfact7";
            Quickfact[8] = "quickfact8";
            Quickfact[9] = "quickfact9";
            int j = rand.Next(0, 9);
            int i = rand.Next(0, 9);
            QuickFactsText0.Text = Quickfact[j];
            while (j == i)
            {
                i = rand.Next(0, 9);
                if (j != i)
                {
                    j = i;
                    break;
                }
            }
            j = i;
            QuickFactsText1.Text = Quickfact[j];


        }

        #endregion
    }
}
