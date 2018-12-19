using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Plugin.Ads
{
    public static class AdConfig
    {
        private static List<string> _testDevices;

        public static IReadOnlyCollection<string> TestDevices => _testDevices.AsReadOnly();

        public static bool TestingModeEnabled { get; set; }

        static AdConfig()
        {
            _testDevices = new List<string>();
        }

        public static void AddTestDevice(string deviceId)
        {
            _testDevices.Add(deviceId);
        }
    }
}
