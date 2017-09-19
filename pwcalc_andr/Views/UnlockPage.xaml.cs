using System;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace pwcalc_andr
{
    public partial class UnlockPage : ContentPage
    {
        public String usermail;
        public Droid.WebService webservice = new Droid.WebService();
        public UnlockPage()
        {
            
            InitializeComponent();
        
        }

		private void unlock_Click(object sender, EventArgs args)
		{
            //CrossImage.Source = "checked.png";
            //ImageText.Text = "Die App ist freigeschaltet!"
            usermail = TextBoxMail.Text;
            webservice.Usermail = usermail;
            Console.WriteLine("Antwort vom Webservice (PIN): " + webservice.getWebPin()); 

		}



		



    }
}
