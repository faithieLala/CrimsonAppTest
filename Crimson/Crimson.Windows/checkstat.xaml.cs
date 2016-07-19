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
//
using Windows.Media.Capture;      //For MediaCapture  
using Windows.Media.MediaProperties;  //For Encoding Image in JPEG format  
using Windows.Storage;         //For storing Capture Image in App storage or in Picture Library  
using Windows.UI.Xaml.Media.Imaging;  //For BitmapImage. for showing image on screen we need BitmapImage format.
//
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Crimson
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class checkstat : Page
    {
        //Declare MediaCapture object globally  
        Windows.Media.Capture.MediaCapture captureManager;
        //private DeviceInformation webcamList;
        //private DeviceInformation frontwebcam;
        //private DeviceInformation backwebcam;
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

        public checkstat()
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

            start_Capture();
            
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
           async Task foo()
           {

               await System.Threading.Tasks.Task.Delay(11000);
               this.Frame.Navigate(typeof(MainPage));
           }

           async private void start_Capture()
           {
               imagePreivew.Source = null;
               captureManager = new MediaCapture();    //Define MediaCapture object  
               await captureManager.InitializeAsync();   //Initialize MediaCapture and   
               capturePreview.Source = captureManager;   //Start preiving on CaptureElement  
               await captureManager.StartPreviewAsync();  //Start camera capturing
           }
        async private void stop_Capture()
        {
            await captureManager.StopPreviewAsync();  //stop camera capturing  
        }
           private void Start_Capture_Preview_Click(object sender, RoutedEventArgs e)
         {
            start_Capture();
           } 
           private void Stop_Capture_Preview_Click(object sender, RoutedEventArgs e)
           {
            stop_Capture();  
           }
           async private void Capture_Photo_Click(object sender, RoutedEventArgs e)
           {
               //Create JPEG image Encoding format for storing image in JPEG type  

               ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();
               // create storage file in local app storage  
               StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("Photo.jpg", CreationCollisionOption.ReplaceExisting);
               // take photo and store it on file location.  
               await captureManager.CapturePhotoToStorageFileAsync(imgFormat, file);
               //// create storage file in Picture Library  
               //StorageFile file = await KnownFolders.PicturesLibrary.CreateFileAsync("Photo.jpg",CreationCollisionOption.GenerateUniqueName);  
               // Get photo as a BitmapImage using storage file path.  
               BitmapImage bmpImage = new BitmapImage(new Uri(file.Path));
               // show captured image on Image UIElement.  
               imagePreivew.Source = bmpImage;
               await captureManager.StopPreviewAsync();
         //   stop_Capture();

           }
       
        ///faulty code
     /*   async private void setdevicecam()
        {
            // First need to find all webcams
            webcamList = await DeviceInformation.FindAllAsync(DeviceClass.All);

            // Then I do a query to find the front webcam
            DeviceInformation frontWebcam = (from webcam in webcamList
                                             where webcam.EnclosureLocation != null
                                             && webcam.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Front
                                             select webcam).FirstOrDefault();

            // Same for the back webcam
            DeviceInformation backWebcam = (from webcam in WebcamList
                                            where webcam.EnclosureLocation != null
                                            && webcam.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Back
                                            select webcam).FirstOrDefault();
        }
        // Then you need to initialize your MediaCapture
      MediaCapture newCapture  = new MediaCapture();
        async private void Start_Capture()
        {
            await newCapture.InitializeAsync(new MediaCaptureInitializationSettings
            {
                // Choose the webcam you want
                VideoDeviceId = backWebcam.Id,
                AudioDeviceId = "",
                StreamingCaptureMode = StreamingCaptureMode.Video,
                PhotoCaptureSource = PhotoCaptureSource.VideoPreview
            });

            // Set the source of the CaptureElement to your MediaCapture
            // (In my XAML I called the CaptureElement *Capture*)
        
            imagePreivew.Source = newCapture;

            // Start the preview
            await newCapture.StartPreviewAsync();

        //    Secondly take the picture

//Set the path of the picture you are going to take
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            var picPath = "\\Pictures\\newPic.jpg";

            StorageFile captureFile = await folder.CreateFileAsync(picPath, CreationCollisionOption.GenerateUniqueName);

            ImageEncodingProperties imageProperties = ImageEncodingProperties.CreateJpeg();

            //Capture your picture into the given storage file
            await newCapture.CapturePhotoToStorageFileAsync(imageProperties, captureFile);
        }*/
}
}
