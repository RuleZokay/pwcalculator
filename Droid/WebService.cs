using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace pwcalc_andr.Droid
{
    public class WebService
    {
        public string usermail = "N/A";
        //Register: Method put : http://de-sg-t2t.technotrans.lan:1903/app/pwcalc/register/<app_id>/schroeder@technotrans.de
        //Isvalid: Method get: http://de-sg-t2t.technotrans.lan:1903/app/pwcalc/isvalid/<app_id>/<app_pin>

        public String getWebPin(){

			UnlockPage SecondPage = new UnlockPage();

			string userName = "test";
			string passWord = "test";

			string webpin = "";
			string email = Usermail;

			string url = "https://ws.technotrans.de/app/pwcalc/register/" + "1234567890123456/" + email; // Just a sample url

			using (var wc = new System.Net.WebClient())
			{
				
				Console.WriteLine("Dies ist die URL zum Webservice: " + url);

				wc.Headers.Add(HttpRequestHeader.ContentType, "application/json");

				string credentials = Convert.ToBase64String(
					Encoding.ASCII.GetBytes(userName + ":" + passWord));
				wc.Headers[HttpRequestHeader.Authorization] = string.Format(
					"Basic {0}", credentials);
                
				ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

				string responseString = wc.UploadString(url, "PUT", "");

				webpin = responseString;
			}

   //         WebClient wc = new WebClient();

			//Console.WriteLine("Dies ist die URL zum Webservice: " + url);

   //         wc.Headers.Add(HttpRequestHeader.ContentType,"application/json");

			//string credentials = Convert.ToBase64String(
			//	Encoding.ASCII.GetBytes(userName + ":" + passWord));
			//wc.Headers[HttpRequestHeader.Authorization] = string.Format(
			//	"Basic {0}", credentials);

			//ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
			//ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

   //         string responseString = wc.UploadString(url, "PUT", "");
			//webpin = responseString;

            return webpin;
        }

        public String getValidation(){
            UnlockPage SecondPage = new UnlockPage();

            string validate = "";
            string url = "https://de-sg-t2t.technotrans.lan/app/pwcalc/isvalid/1234567890123456/" + getWebPin();

            WebClient wc = new WebClient();

            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

            validate = wc.DownloadString(url);

            Console.WriteLine("Ist der User freigeschaltet: " + validate);

            return validate; 
        }

		public string Usermail
		{
			get
			{
				return usermail;
			}

			set
			{
                usermail = value;
			}
		}

		private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
		{
			// If the certificate is a valid, signed certificate, return true.
			if (error == System.Net.Security.SslPolicyErrors.None)
			{
				return true;
			}

			Console.WriteLine("X509Certificate [{0}] Policy Error: '{1}'",
				cert.Subject,
				error.ToString());

			return false;
		}


	}
}
