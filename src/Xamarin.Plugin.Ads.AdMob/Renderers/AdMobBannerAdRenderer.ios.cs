using Google.MobileAds;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Plugin.Ads;
using Xamarin.Plugin.Ads.AdMob;
using Xamarin.Plugin.Ads.AdMob.Helpers;
using Xamarin.Plugin.Ads.Base;

[assembly: ExportRenderer(typeof(BannerAd), typeof(AdMobBannerAdRenderer))]
namespace Xamarin.Plugin.Ads.AdMob
{
    public class AdMobBannerAdRenderer : ViewRenderer
    {
        BannerView adView;
        bool viewOnScreen;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            if (e.OldElement == null)
            {
                var formsView = e.NewElement as BannerAd;

                adView = new BannerView(AdSizeCons.SmartBannerPortrait)
                {
                    AdUnitID = formsView.AdUnitId,
                    RootViewController = GetRootViewController()
                };

                if (AdConfig.TestingModeEnabled)
                {
                    adView.AdUnitID = "ca-app-pub-3940256099942544/6300978111";
                }

                adView.AdReceived += (sender, args) =>
                {
                    if (!viewOnScreen) this.AddSubview(adView);
                    viewOnScreen = true;
                };

                var request = Request.GetDefaultRequest();
                if (AdConfig.TestDevices.Any())
                {
                    request.TestDevices = AdConfig.TestDevices.ToArray();
                }

                e.NewElement.HeightRequest = GetSmartBannerDpHeight();
                adView.LoadRequest(request);

                base.SetNativeControl(adView);
            }
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

        private int GetSmartBannerDpHeight()
        {
            var screenHeightDp = (float)UIScreen.MainScreen.Bounds.Height;
            return AdMobAdSizeHelper.GetSmartBannerHeight(screenHeightDp);
        }
    }
}
