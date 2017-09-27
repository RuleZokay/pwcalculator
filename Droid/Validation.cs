using System;
using Android.Content;

namespace pwcalc_andr.Droid
{
    public class Validation
    {
        String validation = "";

        public String isValid(String webpin)
        {
            Context mContext = Android.App.Application.Context;
            WebService webservice = new WebService();
            AppPreferences preferences = new AppPreferences(mContext);
            PwCalcPage pwcalc = new PwCalcPage();

            validation = webservice.getValidation(webpin);

            if(validation.Equals("true")){
                preferences.saveAppUnlocked("true");

            }

            return validation;
        }
    }
}
