using System;

using Xamarin.Forms;

namespace pwcalc_andr
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page pwcalcPage = null; 
            Page unlockPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    pwcalcPage = new NavigationPage(new PwCalcPage())
                    {
                        Title = "Password-Calculator"
                    };

                    unlockPage = new NavigationPage(new UnlockPage()){
                        Title = "Unlock App"
                    };
                    pwcalcPage.Icon = "tab_feed.png";
                    unlockPage.Icon = "tab_about.png";
                    break;
                default:
                    pwcalcPage = new PwCalcPage()
                    {
                        Title = "Password-Calculator"
                    };

                    unlockPage = new UnlockPage()
                    {
                        Title = "Unlock App"
                    };
                    break;
            }

            Children.Add(pwcalcPage);
            Children.Add(unlockPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}