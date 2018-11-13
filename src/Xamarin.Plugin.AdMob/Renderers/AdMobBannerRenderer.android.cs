using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Plugin.AdMob.Controls;
using Xamarin.Plugin.AdMob.Renderers;
using Android.Gms.Ads;
using System.Diagnostics;

[assembly: ExportRenderer(typeof(AdMobBanner), typeof(AdMobBannerRenderer))]
namespace Xamarin.Plugin.AdMob.Renderers
{
    public class AdMobBannerRenderer : ViewRenderer
    {
        public AdMobBannerRenderer(Context context) : base(context)
        {

        }

        private int GetSmartBannerDpHeight()
        {
            var dpHeight = Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density;

            if (dpHeight <= 400) return 32;
            if (dpHeight > 400 && dpHeight <= 720) return 50;
            return 90;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var ad = new AdView(Context)
                {
                    AdSize = AdSize.SmartBanner,
                    AdUnitId = AdMobBanner.AndroidAdUnitId
                };

                var requestbuilder = new AdRequest.Builder();

                if (!Debugger.IsAttached)
                {
                    ad.LoadAd(requestbuilder.Build());
                    e.NewElement.HeightRequest = GetSmartBannerDpHeight();
                }

                SetNativeControl(ad);
            }
        }
    }
}
