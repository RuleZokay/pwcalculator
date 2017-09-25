using System;
namespace pwcalc_andr.Droid
{
    public class Validation
    {
        String validation = "";
        public String isValid(String webpin)
        {
            
            WebService webservice = new WebService();


            //Sharedpreferences um den WebPin abzuspeichern


            validation = webservice.getValidation(webpin);


            return validation;
        }
    }
}
