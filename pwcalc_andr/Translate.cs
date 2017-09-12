using System;
namespace pwcalc_andr
{
	public static class Translate
	{
		public static string Calculate { get; private set; }

		public static string NowInThreeLanguages { get; private set; }

		public static void Initialize(string languageCode)
		{
			switch (languageCode)
			{
				case "en":
					Calculate = "Calculate";
					NowInThreeLanguages = "Now in three languages!";
					break;
				case "de":
					Calculate = "Berechnen";
					NowInThreeLanguages = "Jetzt in drei Sprachen!";
					break;
				default:
					Initialize("en");
					break;
			}
		}
	}
}
