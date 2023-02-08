using JustDoIt.Abstractions;
using JustDoIt.Enums;
using JustDoIt.Extensions;
using System;
using System.IO;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JustDoIt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizerRussian_Tapped(object sender, EventArgs e)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            if (!File.Exists(Path.Combine(folderPath, Constants.FileLanguageName)))
            {
                File.Create(Path.Combine(folderPath, Constants.FileLanguageName)).Close();
            }

            File.WriteAllText(Path.Combine(folderPath, Constants.FileLanguageName), AppLanguage.Russian.ToString());

            ResourceManager manager = new ResourceManager("JustDoIt.Resource", typeof(TranslateExtension).GetTypeInfo().Assembly);

            await DisplayAlert(manager.GetString("Warning", TranslateExtension.CultureInfo), manager.GetString("Success", TranslateExtension.CultureInfo), "OK");

            bool result = await DisplayAlert(manager.GetString("ConfirmAction", TranslateExtension.CultureInfo), manager.GetString("ChangeLanguageNowMessage", TranslateExtension.CultureInfo), manager.GetString("Yes", TranslateExtension.CultureInfo), manager.GetString("No", TranslateExtension.CultureInfo));

            TranslateExtension.UpdateCultureInfo(AppLanguage.Russian);

            if (result)
            {
                ICloseApplication closeApp = DependencyService.Get<ICloseApplication>();

                closeApp.CloseApplication();
            }
        }

        private async void TapGestureRecognizerEnglish_Tapped(object sender, EventArgs e)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            if (!File.Exists(Path.Combine(folderPath, Constants.FileLanguageName)))
            {
                File.Create(Path.Combine(folderPath, Constants.FileLanguageName)).Close();
            }

            File.WriteAllText(Path.Combine(folderPath, Constants.FileLanguageName), AppLanguage.English.ToString());

            ResourceManager manager = new ResourceManager("JustDoIt.Resource", typeof(TranslateExtension).GetTypeInfo().Assembly);

            await DisplayAlert(manager.GetString("Warning", TranslateExtension.CultureInfo), manager.GetString("Success", TranslateExtension.CultureInfo), "OK");

            bool result = await DisplayAlert(manager.GetString("ConfirmAction", TranslateExtension.CultureInfo), manager.GetString("ChangeLanguageNowMessage", TranslateExtension.CultureInfo), manager.GetString("Yes", TranslateExtension.CultureInfo), manager.GetString("No", TranslateExtension.CultureInfo));

            TranslateExtension.UpdateCultureInfo(AppLanguage.English);

            if (result)
            {
                ICloseApplication closeApp = DependencyService.Get<ICloseApplication>();

                closeApp.CloseApplication();
            }
        }
    }
}