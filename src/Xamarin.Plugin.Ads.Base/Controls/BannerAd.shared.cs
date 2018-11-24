using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
