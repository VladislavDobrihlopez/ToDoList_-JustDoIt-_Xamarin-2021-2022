using JustDoIt.Extensions;
using System;
using System.Linq;
using Xamarin.Forms;

namespace JustDoIt.Views
{
    public partial class WelcomePage : ContentPage
    {
        private MainPage mainPage;

        public WelcomePage()
        {
            InitializeComponent();

            mainPage = new MainPage();

            NavigationPage.SetHasNavigationBar(mainPage, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Random random = new Random();

            if (TranslateExtension.CultureInfo.Name == "ru-RU")
            {
                MotivatingSlogan.Text = Constants.MotivatingQuotes[random.Next(0, Constants.MotivatingQuotes.Length)];
            }
            else
            {
                MotivatingSlogan.Text = Constants.MotivatingQuotesEng[random.Next(0, Constants.MotivatingQuotes.Length)];
            }
        }

        private async void OnButtonClicked(Object sender, EventArgs e)
        {
            if (Navigation.NavigationStack.Last().GetType().Name != "MainPage")
            {
                await Navigation.PushAsync(mainPage);
            }
        }
    }
}