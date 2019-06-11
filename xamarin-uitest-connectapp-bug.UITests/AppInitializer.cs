using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace xamarin_uitest_connectapp_bug.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            return ConfigureApp.iOS.StartApp();
        }
    }
}