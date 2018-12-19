using System;
using System.Collections.Generic;
using System.Text;
using Android.Gms.Ads;
using Xamarin.Forms;

using CurrentActivity = Plugin.CurrentActivity;

[assembly: Dependency(typeof(Xamarin.Plugin.Ads.AdMob.Services.AdMobInterstitialAdService))]
namespace Xamarin.Plugin.Ads.AdMob.Services
{
    public class AdMobInterstitialAdService : IInterstitialService
    {
        InterstitialAd ad;

        public void PrepareAd(string adUnitId)
        {
            if (ad != null)
            {
                if (!ad.IsLoaded && !ad.IsLoading)
                {
                    RequestAd();
                }

                return;
            }

            var context = CurrentActivity.CrossCurrentActivity.Current.Activity;
            ad = new InterstitialAd(context);
            ad.AdUnitId = adUnitId;

            var listener = new MyAdListener();
            listener.AdClosed += () =>
            {
                RequestAd();
            };

            ad.AdListener = listener;
            RequestAd();
        }

        private void RequestAd()
        {
            var requestbuilder = new AdRequest.Builder();
            ad.LoadAd(requestbuilder.Build());
        }

        private void Listener_AdClosed()
        {

        }

        public void ShowAd()
        {
            if (ad.IsLoaded)
            {
                ad.Show();
            }
        }
    }

    class MyAdListener : AdListener
    {
        public delegate void AdLoadedEvent();
        public delegate void AdClosedEvent();
        public delegate void AdOpenedEvent();

        public event AdLoadedEvent AdLoaded;
        public event AdClosedEvent AdClosed;
        public event AdOpenedEvent AdOpened;

        public override void OnAdLoaded()
        {
            if (AdLoaded != null) this.AdLoaded();
            base.OnAdLoaded();
        }

        public override void OnAdClosed()
        {
            if (AdClosed != null) this.AdClosed();
            base.OnAdClosed();
        }

        public override void OnAdOpened()
        {
            if (AdOpened != null) this.AdOpened();
            base.OnAdOpened();
        }

        public override void OnAdFailedToLoad(int errorCode)
        {
            base.OnAdFailedToLoad(errorCode);
        }
    }
}
