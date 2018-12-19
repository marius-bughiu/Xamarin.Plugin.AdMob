using Android.Content;
using Android.Gms.Ads;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Plugin.Ads.AdMob;
using Xamarin.Plugin.Ads;
using Xamarin.Plugin.Ads.AdMob.Helpers;

[assembly: ExportRenderer(typeof(BannerAd), typeof(AdMobBannerAdRenderer))]
namespace Xamarin.Plugin.Ads.AdMob
{
    public class AdMobBannerAdRenderer : ViewRenderer<BannerAd, AdView>
    {
        public BannerAd FormsControl { get; set; }

        public AdMobBannerAdRenderer(Context context) : base(context)
        {

        }

        private int GetSmartBannerHeightDp()
        {
            var screenHeightDp = Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density;
            return AdMobAdSizeHelper.GetSmartBannerHeight(screenHeightDp);
        }

        private AdSize GetAdSize()
        {
            switch (FormsControl.AdSize)
            {
                case AdSizeEnum.Banner: return AdSize.Banner;
                case AdSizeEnum.LargeBanner: return AdSize.LargeBanner;
                case AdSizeEnum.MediumRectangle: return AdSize.MediumRectangle;
                case AdSizeEnum.FullBanner: return AdSize.FullBanner;
                case AdSizeEnum.Leaderboard: return AdSize.Leaderboard;
                case AdSizeEnum.Custom: return new AdSize(FormsControl.AdWidth, FormsControl.AdHeight);
                default: return AdSize.SmartBanner;
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<BannerAd> e)
        {
            base.OnElementChanged(e);

            if (Control != null || e.NewElement == null)
            {
                return;
            }

            FormsControl = e.NewElement;

            var adView = new AdView(Context)
            {
                AdSize = GetAdSize(),
                AdUnitId = Control.AdUnitId
            };

            if (AdConfig.TestingModeEnabled)
            {
                adView.AdUnitId = AdMobTestAdUnits.Banner;
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

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }
    }
}
