using System;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace pwcalc_andr
{
    public partial class UnlockPage : ContentPage
    {
        public String usermail;
        public Droid.WebService webservice = new Droid.WebService();
        public Droid.Validation validation = new Droid.Validation();
        public String webpin = "";
        public UnlockPage()
        {
            
            InitializeComponent();
        
        }

        private async void unlock_Click(object sender, EventArgs args)
        {
            //CrossImage.Source = "checked.png";
            //ImageText.Text = "Die App ist freigeschaltet!"
            usermail = TextBoxMail.Text;
            webservice.Usermail = usermail;

            if(TextBoxMail.Text == null){
                Console.WriteLine("Die Textbox ist leer!");
                TextBoxMail.Placeholder = "Email darf nicht leer sein!";
            }
            else{
				webpin = await webservice.getWebPin();
				Console.WriteLine("Antwort vom Webservice: " + webpin);
			}    

            if (webpin.Length == 6){
                validation.isValid(webpin);
            }
        }







    }
}
