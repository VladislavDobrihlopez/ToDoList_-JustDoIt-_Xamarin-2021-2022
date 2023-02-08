using System.Globalization;

namespace JustDoIt.Abstractions
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }
}
