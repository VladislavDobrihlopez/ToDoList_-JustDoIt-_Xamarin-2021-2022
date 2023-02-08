﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.AppCompat.App;

namespace JustDoIt.Droid
{
    [Activity(Label = "JustDoIt!", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public MainActivity()
        {
            AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightNo;
        }

        protected override void OnResume()
        {
            base.OnResume();
            AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightNo;
        }
    }
}
