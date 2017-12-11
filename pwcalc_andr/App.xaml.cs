using System;
using System.Globalization;
using Android.Content;
using pwcalc_andr.Droid.Resources.values;
using Xamarin.Forms;

namespace pwcalc_andr
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";
      

        public interface ILocalize
        {
            CultureInfo GetCurrentCultureInfo();
            void SetLocale(CultureInfo ci);
        }

        public App()
        {
            
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                AppResources.Culture = ci; // set the RESX for resource localization
                DependencyService.Get<ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
              
            }

            InitializeComponent();

            Context mContext = Android.App.Application.Context;
            Droid.AppPreferences preferences = new Droid.AppPreferences(mContext);


           

            if (Device.RuntimePlatform == Device.iOS)
            {
                MainPage = new MainPage();
            }   
                
            else
            {
                if (preferences.getAppUnlocked().Equals("true")){
                    MainPage = new NavigationPage(new PwCalcPage());
                }
                else{
                    MainPage = new NavigationPage(new UnlockPage());
                }

            }
                
        }

        public void SwitchPage()
        {
            MainPage = new NavigationPage(new PwCalcPage());
        
        }
    }
}