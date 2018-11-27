using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Plugin.Ads.AdMob.Helpers
{
    internal class AdMobAdSizeHelper
    {
        internal static int GetSmartBannerHeight(float screenHeightDp)
        {
            if (screenHeightDp <= 400)
            {
                return 32;
            }

            if (screenHeightDp <= 720)
            {
                return 50;
            }

            return 90;
        }
    }
}
