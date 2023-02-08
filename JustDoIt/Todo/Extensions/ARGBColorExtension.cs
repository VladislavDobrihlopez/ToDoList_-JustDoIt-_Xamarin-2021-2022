using System;
using System.Drawing;
using Xamarin.Forms.Xaml;

namespace JustDoIt.Extensions
{
    public class ARGBColorExtension : IMarkupExtension
    {
        public int alpha;

        public int red;

        public int green;

        public int blue;

        public object ProvideValue(IServiceProvider serviceProvider)
        {
           return Color.FromArgb(alpha, red, green, blue);
        }
    }
}
