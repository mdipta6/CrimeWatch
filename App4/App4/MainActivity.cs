using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using Xamarin.Android;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;

namespace App4
{
    [Activity(Label = "App4", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        public static async System.Threading.Tasks.Task getLocAsync()
        {

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(new TimeSpan(0, 5, 0));

            Console.WriteLine(position.Longitude.ToString());
            Console.WriteLine(position.Latitude.ToString());
           
        }

   
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            getLocAsync();
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };


        }
    }
}

