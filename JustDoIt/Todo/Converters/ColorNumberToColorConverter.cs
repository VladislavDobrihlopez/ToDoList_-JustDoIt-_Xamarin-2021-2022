using JustDoIt.Enums;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace JustDoIt.Converters
{
    public class ColorNumberToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Priority taskPriority = (Priority)value;

            Color color;

            switch(taskPriority)
            {
                case Priority.Low:
                    color = Constants.LowPriority;
                    break;
                case Priority.Medium:
                    color = Constants.MediumPriority;
                    break;
                default:
                    color = Constants.HighPriority;
                    break;
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
