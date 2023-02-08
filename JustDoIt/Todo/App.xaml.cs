using Xamarin.Forms;
using JustDoIt.Views;
using JustDoIt.Abstractions;
using System;
using System.IO;
using JustDoIt.Extensions;
using JustDoIt.Enums;

namespace JustDoIt
{
    public partial class App : Application
    {
        public App()
        {
            App.Current.UserAppTheme = OSAppTheme.Light;

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            if (File.Exists(Path.Combine(folderPath, Constants.FileLanguageName)))
            {
                string text = File.ReadAllText(Path.Combine(folderPath, Constants.FileLanguageName));

                AppLanguage language;

                try
                {
                    language = (AppLanguage)Enum.Parse(typeof(AppLanguage), text);
                }
                catch
                {
                    language = AppLanguage.English;
                }

                TranslateExtension.UpdateCultureInfo(language);
            }

            InitializeComponent();

            MainPage = new NavigationPage(new WelcomePage())
            {
                BarBackgroundColor = (Color)App.Current.Resources["primaryPurple"]
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
