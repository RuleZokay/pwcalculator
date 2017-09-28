using System;
using Android.Content;

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
            set { TextBoxNumber.Text = value; }
            get { return TextBoxNumber.Text; }
        }

        private void Berechnen_Click(object sender, EventArgs args)
		{
            TextBoxPassword.Text = GetPassword();	
		}

		public string GetPassword()
		{
            if(!(InputText == null)){
                
				var password = Math.Round(Math.Sqrt(Convert.ToInt32(InputText)) * 9965) % 10000;
                InputText = null;
                return password.ToString();

			}


            else{
            return TextBoxPassword.Text = "Bitte eine Zahl eingeben!!!";
			}

         }

        public void EnableAllObjects(){
            TextBoxNumber.IsEnabled = true;
            ButtonCalc.IsEnabled = true;
		}
    }
}