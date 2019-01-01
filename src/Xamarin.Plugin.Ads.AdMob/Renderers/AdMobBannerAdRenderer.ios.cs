using Google.MobileAds;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Plugin.Ads;
using Xamarin.Plugin.Ads.AdMob;
using Xamarin.Plugin.Ads.AdMob.Helpers;

[assembly: ExportRenderer(typeof(BannerAd), typeof(AdMobBannerAdRenderer))]
namespace Xamarin.Plugin.Ads.AdMob
{
    public class AdMobBannerAdRenderer : ViewRenderer<BannerAd, BannerView>
    {
        private bool _viewOnScreen;

        public BannerAd FormsControl { get; set; }

        protected override void OnElementChanged(ElementChangedEventArgs<BannerAd> e)
        {
            base.OnElementChanged(e);

            if (Control != null || e.NewElement == null)
            {
                return;
            }

            FormsControl = e.NewElement;

            var adView = new BannerView(GetAdSize())
            {
                AdUnitID = FormsControl.AdUnitId,
                RootViewController = GetRootViewController()
            };

            if (string.IsNullOrEmpty(adView.AdUnitID) && !string.IsNullOrEmpty(AdConfig.DefaultBannerAdUnitId))
            {
                adView.AdUnitID = AdConfig.DefaultBannerAdUnitId;
            }

            if (AdConfig.TestingModeEnabled)
            {
                adView.AdUnitID = AdMobTestAdUnits.Banner;
            }

            adView.AdReceived += (sender, args) =>
            {
                if (!_viewOnScreen)
                {
                    AddSubview(adView);
                }

                _viewOnScreen = true;
            };

            var request = Request.GetDefaultRequest();
            if (AdConfig.TestDevices.Any())
            {
                request.TestDevices = AdConfig.TestDevices.ToArray();
            }

            e.NewElement.HeightRequest = GetSmartBannerDpHeight();
            adView.LoadRequest(request);

            SetNativeControl(adView);
        }

        private UIViewController GetRootViewController()
        {
            foreach (UIWindow window in UIApplication.SharedApplication.Windows)
            {
                if (window.RootViewController != null)
                {
                    return window.RootViewController;
                }
            }

            return null;
        }

        private AdSize GetAdSize()
        {
            switch (FormsControl.AdSize)
            {
                case AdSizeEnum.Banner: return AdSizeCons.Banner;
                case AdSizeEnum.LargeBanner: return AdSizeCons.LargeBanner;
                case AdSizeEnum.MediumRectangle: return AdSizeCons.MediumRectangle;
                case AdSizeEnum.FullBanner: return AdSizeCons.FullBanner;
                case AdSizeEnum.Leaderboard: return AdSizeCons.Leaderboard;
                case AdSizeEnum.Custom: return new AdSize { Size = new CoreGraphics.CGSize(FormsControl.Width, FormsControl.Height) };
                default: return AdSizeCons.SmartBannerPortrait;
            }
        }

        private int GetSmartBannerDpHeight()
        {
            var screenHeightDp = (float)UIScreen.MainScreen.Bounds.Height;
            return AdMobAdSizeHelper.GetSmartBannerHeight(screenHeightDp);
        }
    }
}
