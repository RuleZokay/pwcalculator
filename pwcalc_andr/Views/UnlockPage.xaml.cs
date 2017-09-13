using System;


using Xamarin.Forms;


namespace pwcalc_andr
{
    public partial class UnlockPage : ContentPage
    {
        public Droid.WebService webservice = new Droid.WebService();
        public UnlockPage()
        {
            
            InitializeComponent();
        
        }

		private void unlock_Click(object sender, EventArgs args)
		{
            //CrossImage.Source = "checked.png";
            //ImageText.Text = "Die App ist freigeschaltet!"
            String usermail = TextBoxMail.Text;
            webservice.giveUserMail(usermail);
            webservice.getWebPin();

		}



		



    }
}
