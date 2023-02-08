using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JustDoIt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilteringPage : ContentPage
    {
        public FilteringPage()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Send<FilteringPage>(this, "FilteringPage");
        }

        private void OnButtonResetFavUnfavClicked(object sender, EventArgs e)
        {
            Constants.ForSql[0] = new List<string>()
            {
                "0",
                "1",
            };

            checkBoxOnlyFavourites.IsToggled = false;
        }

        private void OnButtonResetDoneUndoneClicked(object sender, EventArgs e)
        {
            Constants.ForSql[1] = new List<string>()
            {
                "0",
                "1",
            };

            checkBoxOnlyDone.IsToggled = false;
        }

        private void OnButtonResetPrioritiesClicked(object sender, EventArgs e)
        {
            checkBoxHighPriority.IsChecked = true;

            checkBoxMediumPriority.IsChecked = true;

            checkBoxLowPriority.IsChecked = true;

            OnPriorityCheckBox_CheckedChanged(sender, new CheckedChangedEventArgs(true));
        }

        private void OnFavouriteCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Constants.ForSql[0] = new List<string>
            {
                Convert.ToString(Convert.ToInt32(checkBoxOnlyFavourites.IsToggled)),
            };
        }

        private void OnOnlyDoneCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Constants.ForSql[1] = new List<string>
            {
                Convert.ToString(Convert.ToInt32(checkBoxOnlyDone.IsToggled)),
            };
        }

        private void OnPriorityCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Constants.ForSql[2] = new List<string>();

            if (checkBoxHighPriority.IsChecked)
            {
                Constants.ForSql[2].Add("0");
            }

            if (checkBoxMediumPriority.IsChecked)
            {
                Constants.ForSql[2].Add("1");
            }

            if (checkBoxLowPriority.IsChecked)
            {
                Constants.ForSql[2].Add("2");
            }
        }

        private void OnFindButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void OnByDefaultButtonClicked(object sender, EventArgs e)
        {
            OnButtonResetFavUnfavClicked(sender, e);

            OnButtonResetDoneUndoneClicked(sender, e);

            OnButtonResetPrioritiesClicked(sender, e);
        }
    }
}