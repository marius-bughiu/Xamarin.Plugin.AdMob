using Android.Content;
using Android.Gms.Ads;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Plugin.AdMob;
using Xamarin.Plugin.Ads;

[assembly: ExportRenderer(typeof(BannerAd), typeof(AdMobBannerAdRenderer))]
namespace Xamarin.Plugin.AdMob
{
    public class AdMobBannerAdRenderer : ViewRenderer
    {
        public AdMobBannerAdRenderer(Context context) : base(context)
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
                    AdUnitId = (e.NewElement as BannerAd).AdUnitId
                };

                var requestbuilder = new AdRequest.Builder();

                ad.LoadAd(requestbuilder.Build());
                e.NewElement.HeightRequest = GetSmartBannerDpHeight();

                SetNativeControl(ad);
            }
        }

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }
    }
}
