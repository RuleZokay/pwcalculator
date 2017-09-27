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

        public static string username = "test";
        public static string password = "test";
        public static String resultpin = "";

        public async Task<string> getWebPin()
        {
            {

            //UnlockPage SecondPage = new UnlockPage();

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
                string url = "https://ws.technotrans.de/app/pwcalc/register/8234567890123456/" + Usermail ;

                resultpin = await wc.UploadStringTaskAsync(url,"Put","");

            wc.Dispose();
        }
            return resultpin;
        
    
        }

        public String getValidation(String webpin){
            UnlockPage SecondPage = new UnlockPage();

            string validate = "";
            string url = "https://ws.technotrans.de/app/pwcalc/isvalid/8234567890123456/"+webpin;

            WebClient wc = new WebClient();

            System.Net.ServicePointManager.DefaultConnectionLimit = 100;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            validate = wc.DownloadString(url);

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
