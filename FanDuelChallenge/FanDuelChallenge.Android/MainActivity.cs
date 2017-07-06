using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FanDuelChallenge.Droid
{
	[Activity (Label = "FanDuelChallenge.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            ImageButton FirstPlayerButton = FindViewById<ImageButton>(Resource.Id.FirstPlayerImageButton);
            TextView FirstPlayerNameTextView = FindViewById<TextView>(Resource.Id.FirstPlayerNameTextView);
            ImageButton SecondPlayerButton = FindViewById<ImageButton>(Resource.Id.SecondPlayerImageButton);
            TextView SecondPlayerNameTextView = FindViewById<TextView>(Resource.Id.SecondPlayerNameTextView);


            
		}
	}
}


