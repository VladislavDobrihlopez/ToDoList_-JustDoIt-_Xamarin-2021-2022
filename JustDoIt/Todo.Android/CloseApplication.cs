using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JustDoIt.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
[assembly: Dependency(typeof(JustDoIt.Droid.CloseApplication))]
namespace JustDoIt.Droid
{
    public class CloseApplication : ICloseApplication
    {
        [Obsolete]
        void ICloseApplication.CloseApplication()
        {
            Activity activity = (Activity)Forms.Context;

            activity.Recreate();
        }
    }
}