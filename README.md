# Xamarin.Plugin.AdMob
Cross-platform ads for your Xamarin Forms app.

*This project has no affiliation with the Microsoft or the Xamarin teams.*

## Android setup

In order to register the renderers, you must call their `Init` method in the `OnCreate` method of your `MainActivity`.

```
Xamarin.Plugin.Ads.AdMob.AdMobBannerRenderer.Init();
```

Also, for the ads to work, you need to update your app's manifest to include the `AdActivity` and the `ACCESS_NETWORK_STATE` and `INTERNET` permissions. Like so:

```
<?xml version="1.0" encoding="utf-8"?>
<manifest ...>
  <application ...>
    <activity android:name="com.google.android.gms.ads.AdActivity" android:configChanges="keyboard|keyboardHidden|orientation|screenLayout|uiMode|screenSize|smallestScreenSize" android:theme="@android:style/Theme.Translucent" />
  </application>
  <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
  <uses-permission android:name="android.permission.INTERNET" />
</manifest>
```

## Displaying a banner ad

Configure your default ad unit ID in your `App`'s constructor in `App.xaml.cs`.

```
AdMobBanner.AndroidAdUnitId = "ca-app-pub-xxxxxxxxxxxxxxxx/xxxxxxxxxx";
```

### XAML

Add the controls namespace at the top of your page:

```
xmlns:admob="clr-namespace:Xamarin.Plugin.AdMob.Controls;assembly=Xamarin.Plugin.AdMob"
```

and then place the banned in your page.

```
<admob:AdMobBanner />
```

### C#

```
var bannerAd = new AdMobBanner();
```