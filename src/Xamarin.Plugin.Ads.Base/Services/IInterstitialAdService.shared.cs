using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Plugin.Ads.AdMob.Services
{
    public interface IInterstitialService
    {
        void PrepareAd(string adUnitId);

        void PrepareAd();

        void ShowAd();
    }
}
