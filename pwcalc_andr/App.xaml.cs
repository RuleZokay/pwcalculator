using System;
using Android.Content;
using Xamarin.Forms;

namespace pwcalc_andr
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";
      
        public App()
        {
            


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