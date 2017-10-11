using System;
using System.Collections.Generic;
using Android.Content;
using Android.Preferences;

namespace pwcalc_andr.Droid
{
    public class AppPreferences
    {
        private ISharedPreferences mSharedPrefs;
        private ISharedPreferencesEditor mPrefsEditor;
        private Context mContext;
        private static String PREFERENCE_WEB_PIN = "PREFERENCE_WEB_PIN";
        private static String PREFERENCE_FIRST_REGISTER = "PREFERENCE_FIRST_REGISTER";
        private static String PREFERENCE_APP_UNLOCKED = "PREFERENCE_APP_UNLOCKED";
        private static String PREFERENCE_USER_EMAIL = "PREFERENCE_USER_EMAIL";

        public AppPreferences(Context context)
        {
            this.mContext = context;
            mSharedPrefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            mPrefsEditor = mSharedPrefs.Edit();
        }

        public void saveUserEmail(string key){
            mPrefsEditor.PutString(PREFERENCE_USER_EMAIL,key);
            mPrefsEditor.Commit();
        }

        public String getUserEmail(){
            return mSharedPrefs.GetString(PREFERENCE_USER_EMAIL, "");
        }


		public void saveAppUnlocked(string key)
		{
            mPrefsEditor.PutString(PREFERENCE_APP_UNLOCKED, key);
			mPrefsEditor.Commit();
		}

		public String getAppUnlocked()
		{
            return mSharedPrefs.GetString(PREFERENCE_APP_UNLOCKED,"");
		}

        public void saveFirstRegister(string key){
            mPrefsEditor.PutString(PREFERENCE_FIRST_REGISTER,key);
            mPrefsEditor.Commit();
        }

		public String getFirstRegister()
		{
            return mSharedPrefs.GetString(PREFERENCE_FIRST_REGISTER,"");
		}

        public void saveWebPin(string key)
        {
            mPrefsEditor.PutString(PREFERENCE_WEB_PIN, key);
            mPrefsEditor.Commit();
        }

        public string getWebPin()
        {
            return mSharedPrefs.GetString(PREFERENCE_WEB_PIN, "");
        }
    }
}