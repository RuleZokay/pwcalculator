using System;
using System.Threading.Tasks;
using Android.Content;
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
                    preferences.saveAppUnlocked("true");
                    pwcalcpage.EnableAllObjects();
                    EnableAllObjects();
                }

            }
        }

        public void EnableAllObjects()
        {
			CrossImage.Source = "checked.png";
            ImageText.Text = "Die App ist freigeschaltet!";
            RequestText.IsVisible = false;
		}

    }
}