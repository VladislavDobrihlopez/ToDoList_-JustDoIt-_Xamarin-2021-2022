using System;
using System.Globalization;
using Xamarin.Forms;

namespace JustDoIt.Converters
{
    public class DoneToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isDone = (bool)value;

            string source;

            if (isDone)
            {
                source = "Heart.png";
            }
            else
            {
                source = "EmptyHeart.png";
            }

            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
