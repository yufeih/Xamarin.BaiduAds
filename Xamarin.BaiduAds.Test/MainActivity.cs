using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Baidu.Appx;

namespace Xamarin.BaiduAds.Test
{
    [Activity(Label = "Xamarin.BaiduAds.Test", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            var group = FindViewById<ViewGroup>(Resource.Id.ad_container);

            ShowBaiduAdIn(group);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }

        private void ShowBaiduAdIn(ViewGroup adContainer)
        {
            BDBannerAd banner = new BDBannerAd(this, "Z03uBILZVtfZ0NxKfgc6yFDT", "QLD7hWvVAxEYCKNwDSCanemk");
            banner.SetAdSize(BDBannerAd.Size320x50);
            banner.AdvertisementViewDidShow += (a, b) => 
            {
                System.Diagnostics.Debug.WriteLine(nameof(BDBannerAd.AdvertisementViewDidShow));
            };
            banner.AdvertisementDataDidLoadFailure += (a, b) =>
            {
                System.Diagnostics.Debug.WriteLine(nameof(BDBannerAd.AdvertisementDataDidLoadFailure));
            };
            banner.AdvertisementDataDidLoadSuccess += (a, b) =>
            {
                System.Diagnostics.Debug.WriteLine(nameof(BDBannerAd.AdvertisementDataDidLoadSuccess));
            };
            banner.AdvertisementViewDidClick += (a, b) =>
            {
                System.Diagnostics.Debug.WriteLine(nameof(BDBannerAd.AdvertisementViewDidClick));
            };
            banner.AdvertisementViewWillStartNewIntent += (a, b) =>
            {
                System.Diagnostics.Debug.WriteLine(nameof(BDBannerAd.AdvertisementViewWillStartNewIntent));
            };

            adContainer.AddView(banner);
        }
    }
}

