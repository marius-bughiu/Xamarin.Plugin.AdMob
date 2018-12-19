using Xamarin.Forms;

namespace Xamarin.Plugin.Ads
{
    public class BannerAd : ContentView
    {
        public BannerAd()
        {

        }

        public static readonly BindableProperty AdUnitIdProperty =
            BindableProperty.Create("AdUnitId", typeof(string), typeof(BannerAd), null);

        public string AdUnitId
        {
            get { return (string)GetValue(AdUnitIdProperty); }
            set { SetValue(AdUnitIdProperty, value); }
        }

        public static readonly BindableProperty AdSizeProperty =
            BindableProperty.Create("AdSize", typeof(AdSizeEnum), typeof(BannerAd), null);

        public AdSizeEnum? AdSize
        {
            get { return (AdSizeEnum?)GetValue(AdSizeProperty); }
            set { SetValue(AdSizeProperty, value); }
        }

        public static readonly BindableProperty AdHeightProperty =
            BindableProperty.Create("AdHeight", typeof(int), typeof(BannerAd), null);

        public int AdHeight
        {
            get { return (int)GetValue(AdHeightProperty); }
            set { SetValue(AdHeightProperty, value); }
        }

        public static readonly BindableProperty AdWidthProperty =
            BindableProperty.Create("AdWidth", typeof(int), typeof(BannerAd), null);

        public int AdWidth
        {
            get { return (int)GetValue(AdWidthProperty); }
            set { SetValue(AdWidthProperty, value); }
        }
    }
}
