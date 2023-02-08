using JustDoIt.Abstractions;
using Xamarin.Forms;
[assembly: Dependency(typeof(JustDoIt.Droid.Localize))]
namespace JustDoIt.Droid
{
    public class Localize : ILocalize
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;

            var netLanguage = androidLocale.ToString().Replace("_", "-");

            return new System.Globalization.CultureInfo(netLanguage);
        }
    }
}