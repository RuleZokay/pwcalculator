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
        string reply = "";
        string username = "test";
        string password = "test";
        String resultpin = "";
        public String getWebPin()
        {
            {

            UnlockPage SecondPage = new UnlockPage();



            System.Net.ServicePointManager.DefaultConnectionLimit = 100;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            WebClient wc = new WebClient();
            wc.UseDefaultCredentials = true;

            string credentials = Convert.ToBase64String(
            Encoding.ASCII.GetBytes(username + ":" + password));
            wc.Headers[HttpRequestHeader.Authorization] = string.Format(
            "Basic {0}", credentials);

            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            string url = "https://ws.technotrans.de/app/pwcalc/register/123456789/jonathanios@technotrans.de";

            resultpin = wc.UploadString(url, "Put", "");

            System.Console.WriteLine("Antwort vom Webservice: " + resultpin);

            wc.Dispose();
        }

        return resultpin;
    
        }

        public String getValidation(){
            UnlockPage SecondPage = new UnlockPage();

            string validate = "";
            string url = "https://de-sg-t2t.technotrans.lan/app/pwcalc/isvalid/1234567890123456/" + getWebPin();

            WebClient wc = new WebClient();


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

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

        


    }
}
