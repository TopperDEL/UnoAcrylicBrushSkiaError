using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnoAcrylicBrushSkiaError
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadSampleImageAsync();
        }

        private async void LoadSampleImageAsync()
        {
            var innerHandler = new HttpClientHandler();
            var client = new HttpClient(innerHandler);

            var guid = Guid.NewGuid().ToString();
            //var myFilter = new Windows.Web.Http.Filters.HttpBaseProtocolFilter();
            //myFilter.AllowUI = false;
            //Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient(myFilter);
            var result = await client.GetAsync(new Uri("https://picsum.photos/seed/" + guid + "/4000/3000"));
            MemoryStream mstream = new MemoryStream();
            await result.Content.CopyToAsync(mstream);
            mstream.Position = 0;
            sampleImage1.ShowImage(mstream.ToArray());
            sampleImage2.ShowImage(mstream.ToArray());
            sampleImage3.ShowImage(mstream.ToArray());
        }
    }
}
