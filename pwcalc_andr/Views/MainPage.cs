using System;

using Xamarin.Forms;

namespace pwcalc_andr
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page pwcalcPage = null; 
            Page aboutPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    pwcalcPage = new NavigationPage(new PwCalcPage())
                    {
                        Title = "Password-Calc"
                    };

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    pwcalcPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    break;
                default:
                    pwcalcPage = new PwCalcPage()
                    {
                        Title = "Password-Calc"
                    };

                    aboutPage = new AboutPage()
                    {
                        Title = "About"
                    };
                    break;
            }

            Children.Add(pwcalcPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
