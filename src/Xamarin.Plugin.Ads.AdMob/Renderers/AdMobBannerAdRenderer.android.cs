using Android.Content;
using Android.Gms.Ads;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Plugin.Ads.AdMob;
using Xamarin.Plugin.Ads;
using Xamarin.Plugin.Ads.AdMob.Helpers;
using Xamarin.Plugin.Ads.Base;

[assembly: ExportRenderer(typeof(BannerAd), typeof(AdMobBannerAdRenderer))]
namespace Xamarin.Plugin.Ads.AdMob
{
    public class AdMobBannerAdRenderer : ViewRenderer
    {
        public AdMobBannerAdRenderer(Context context) : base(context)
        {

        }

        private int GetSmartBannerHeightDp()
        {
            var screenHeightDp = Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density;
            return AdMobAdSizeHelper.GetSmartBannerHeight(screenHeightDp);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var adView = new AdView(Context)
                {
                    AdSize = AdSize.SmartBanner,
                    AdUnitId = (e.NewElement as BannerAd).AdUnitId
                };

                if (AdConfig.TestingModeEnabled)
                {
                    adView.AdUnitId = "ca-app-pub-3940256099942544/6300978111";
                }

                var requestBuilder = new AdRequest.Builder();
                foreach (var testDeviceId in AdConfig.TestDevices)
                {
                    requestBuilder.AddTestDevice(testDeviceId);
                }

                adView.LoadAd(requestBuilder.Build());
                e.NewElement.HeightRequest = GetSmartBannerHeightDp();

                SetNativeControl(adView);
            }
        }

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }
    }
}
