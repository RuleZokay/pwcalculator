using System;
using System.Net;

namespace pwcalc_andr.Droid
{
    public class WebService
    {
        
        //Register: Method put : http://de-sg-t2t.technotrans.lan:1903/app/pwcalc/register/<app_id>/schroeder@technotrans.de
        //Isvalid: Method get: http://de-sg-t2t.technotrans.lan:1903/app/pwcalc/isvalid/<app_id>/<app_pin>

        public String getWebPin(){
            UnlockPage SecondPage = new UnlockPage();

            string webpin = "";
            string email = SecondPage.getUserEmail();

            string url = "http://de-sg-t2t.technotrans.lan:1903/app/pwcalc/register/" +"1234567890123456/" + email; // Just a sample url
			WebClient wc = new WebClient();



            //wc.QueryString.Add("parameter2", );

            Console.WriteLine("Das ist die User-Email: " + SecondPage.getUserEmail());
            //Console.WriteLine("Dies ist die URL zum Webservice: "+ url);

			//var data = wc.UploadValues(url, "POST", wc.QueryString);

			// data here is optional, in case we recieve any string data back from the POST request.
			//var responseString = UnicodeEncoding.UTF8.GetString(data);
             


            return webpin;
		}

        //public giveUserMail(string usermail)
        //{
            
        //}
            



	
    }
}
