using System;


using Xamarin.Forms;


namespace pwcalc_andr
{
    public partial class PwCalcPage : ContentPage
    {
        
        public PwCalcPage()
        {
         InitializeComponent();
        }


		public string InputText
        {
            get { return TextBoxNumber.Text; }
        }

        private void Berechnen_Click(object sender, EventArgs args)
		{
            TextBoxPassword.Text = GetPassword();
		}

		public string GetPassword()
		{
            var password = Math.Round(Math.Sqrt(Convert.ToInt32(InputText)) * 9965) % 10000;
			return password.ToString();
		}



    }
}
