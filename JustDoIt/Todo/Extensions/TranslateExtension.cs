using JustDoIt.Abstractions;
using JustDoIt.Enums;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JustDoIt.Extensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public static CultureInfo CultureInfo { get; private set; }

        private const string ResourceId = "JustDoIt.Resource";

        static TranslateExtension()
        {
            CultureInfo = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        public static void UpdateCultureInfo(AppLanguage language)
        {
            switch (language)
            {
                case AppLanguage.Russian:
                    CultureInfo = new CultureInfo("ru-RU");
                    break;
                case AppLanguage.English:
                    CultureInfo = new CultureInfo("en-US");
                    break;
                default:
                    break;
            }
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
            {
                return "";
            }

            ResourceManager manager = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);

            string translation = manager.GetString(Text, CultureInfo);

            if (translation == null)
            {
                translation = Text;
            }

            return translation;
        }
    }
}