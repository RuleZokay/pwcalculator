using System;


using Xamarin.Forms;

namespace pwcalc_andr
{
    public partial class PwCalcPage : ContentPage
    {
        
        public PwCalcPage()
        {







			var basicNumber = new Entry()
			{
				Keyboard = Keyboard.Numeric,
			};
			var result = new Entry();
			var calculate = new Button { Text = Translate.Calculate };

			var errorMessage = new Label
			{
				TextColor = Color.Red,
				Text = " ",
			};

			var list = new StackLayout
			{
				Children = {
					new Label{ Text = "Password number:" },
					basicNumber,
					errorMessage,
					calculate,
					new Label { Text = "calculated Password:" },
					result,
				}
			};

			calculate.Clicked += delegate {
				try
				{
					result.Text = GetPassword(int.Parse(basicNumber.Text));
					errorMessage.Text = " ";
					basicNumber.TextColor = Color.Black;
				}
				catch (Exception)
				{
					errorMessage.Text = "falsches Format";
					basicNumber.TextColor = Color.Red;
				}
			};

			






            InitializeComponent();
        }

		static string GetPassword(int basicNumber)
		{
			var password = Math.Round(Math.Sqrt(basicNumber) * 9965) % 10000;
			return password.ToString();
		}



    }
}
