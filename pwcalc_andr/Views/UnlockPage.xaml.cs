using System;

using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using pwcalc_andr.Droid.Resources.values;
using Xamarin.Forms;


namespace pwcalc_andr
{
    public partial class UnlockPage : ContentPage
    {
        public String usermail;
        public Droid.WebService webservice = new Droid.WebService();
        public Droid.Validation validation = new Droid.Validation();
        public PwCalcPage pwcalcpage = new PwCalcPage();
        public String webpin = "";
        String unlocked;
       
        public UnlockPage()
        {
            InitializeComponent();
            Title = AppResources.UnlockTitle;
			Context mContext = Android.App.Application.Context;
			Droid.AppPreferences preferences = new Droid.AppPreferences(mContext);
            if (preferences.getFirstRegister().Equals("true")){
                TextBoxMail.Text = preferences.getUserEmail();
                TextBoxMail.IsEnabled = false;
            }
			if (preferences.getAppUnlocked().Equals("true"))
			{
                TextBoxMail.Text = preferences.getUserEmail();
                CrossImage.Source = "checked.png";
				ImageText.Text = "Die App ist freigeschaltet!";
				RequestText.IsVisible = false;
				
			}
		}

        private async void unlock_Click(object sender, EventArgs args)
        {
            Context mContext = Android.App.Application.Context;
            Droid.AppPreferences preferences = new Droid.AppPreferences(mContext);

            usermail = TextBoxMail.Text;
            webservice.Usermail = usermail;

            if(TextBoxMail.Text == null){
                Console.WriteLine("Die Textbox ist leer!");
                TextBoxMail.Placeholder = "Email darf nicht leer sein!";
            }
            else{
                RequestText.IsVisible = true;
                Console.WriteLine("Wurde die App schon einmal registriert:" + preferences.getFirstRegister());
                if (!(preferences.getFirstRegister().Equals("true"))){
                    preferences.saveUserEmail(usermail);
					TextBoxMail.IsEnabled = false;
                    webpin = await webservice.getWebPin();
					Console.WriteLine("Antwort vom Webservice: " + webpin);
                    unlocked = webservice.getValidation(webpin);

                }
                else{
                    TextBoxMail.Text = preferences.getUserEmail();
                    TextBoxMail.IsEnabled = false;
                    webpin = preferences.getWebPin();
                }
				
			}    

            if (webpin.Length == 6){
                preferences.saveFirstRegister("true");
                preferences.saveWebPin(webpin);
                unlocked = validation.isValid(webpin);

                if(unlocked.Equals("true")){
                    App app = new App();
                    app.MainPage = new NavigationPage(new PwCalcPage());
                    app.SwitchPage();

                    //restartActivity(app);

                    preferences.saveAppUnlocked("true");

                    EnableAllObjects();
                }

            }
        }

        public static void restartActivity(Activity activity)
        {
            activity.Recreate();
        }

        public void EnableAllObjects()
        {
            App app = new App();
			CrossImage.Source = "checked.png";
            ImageText.Text = AppResources.Activated;
            RequestText.IsVisible = false;
            app.MainPage = new NavigationPage(new PwCalcPage());		
        }

    }
}