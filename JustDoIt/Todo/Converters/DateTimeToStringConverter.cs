using JustDoIt.Extensions;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace JustDoIt.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }

            DateTime dateTime = (DateTime)value;

            if (TranslateExtension.CultureInfo.Name == "ru-RU")
            {
                return dateTime.ToString("dd/MM/yy");
            }
            else
            {
                return dateTime.ToString("MM/dd/yyyy");
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
