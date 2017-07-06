using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Graphics;
using Java.IO;
using System.IO;
using Android.Util;
using System.Net;

namespace FanDuelChallenge.Droid
{
	[Activity (Label = "FanDuelChallenge.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        private GuessingGame guessingGame;
        private FanDuelJsonHttpClient jsonClient = new FanDuelJsonHttpClient();

        private IEnumerable<Player> players;

        public ImageButton FirstPlayerButton { get; private set; }
        public TextView FirstPlayerNameTextView { get; private set; }
        public ImageButton SecondPlayerButton { get; private set; }
        public TextView SecondPlayerNameTextView { get; private set; }

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our views from the layout resource,
            FirstPlayerButton = FindViewById<ImageButton>(Resource.Id.FirstPlayerImageButton);
            FirstPlayerNameTextView = FindViewById<TextView>(Resource.Id.FirstPlayerNameTextView);
            SecondPlayerButton = FindViewById<ImageButton>(Resource.Id.SecondPlayerImageButton);
            SecondPlayerNameTextView = FindViewById<TextView>(Resource.Id.SecondPlayerNameTextView);

            FirstPlayerButton.Click += FirstPlayerButton_Click;
            SecondPlayerButton.Click += SecondPlayerButton_Click;

            players = await jsonClient.ReadPlayers();
            guessingGame = new GuessingGame(players);

            SetUpUiForNextRound();

        }

        private void SetUpUiForNextRound()
        {
            if (guessingGame.CanContinue)
            {
                FirstPlayerButton.SetImageBitmap(GetImageBitmapFromUrl(guessingGame.Player1.Images.Default.URL));
                SecondPlayerButton.SetImageBitmap(GetImageBitmapFromUrl(guessingGame.Player2.Images.Default.URL));

                FirstPlayerNameTextView.Text = guessingGame.Player1.FirstName + " " + guessingGame.Player1.LastName;
                SecondPlayerNameTextView.Text = guessingGame.Player2.FirstName + " " + guessingGame.Player2.LastName;
            }
        }
        private void FirstPlayerButton_Click(object sender, EventArgs e)
        {
            CheckGuess(guessingGame.Player1);
        }
        private void SecondPlayerButton_Click(object sender, EventArgs e)
        {
            CheckGuess(guessingGame.Player2);
        }

        private void CheckGuess(Player player)
        {
            string alertTitle = string.Empty;
            if (guessingGame.CheckGuess(player))
            {
                alertTitle = "You are right!";
            }
            else
            {
                alertTitle = "You are wrong...";
            }

            if (guessingGame.CanContinue)
            {

                ShowAlert(alertTitle, $"{player.FirstName} {player.LastName} has {player.FPPG} points.");
                guessingGame.SetUpTurn();
                SetUpUiForNextRound();
            }
            else
            {
                EndGame();
                ShowAlert(alertTitle, $"{player.FirstName} {player.LastName} has {player.FPPG} points.");
            }
        }

        private void EndGame()
        {

            ShowAlert("You Win!", "Close Dialog to try again.");
            guessingGame = new GuessingGame(players);
            SetUpUiForNextRound();
        }



        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;
            try
            {
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }
            }
            catch(Exception ex)
            {
               //TODO add exception handeling
            }

            return imageBitmap;
        }

        public Dialog ShowAlert(string title, string msg, string neuBtn = "OK")
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle(title);
            alert.SetMessage(msg);
            alert.SetNeutralButton(neuBtn, (senderAlert, args) =>
            {
            });
            alert.SetCancelable(false);

            Dialog dialog = alert.Create();
            try
            {
                dialog.Show();
            }
            catch (Exception ex)
            {
            }
            return dialog;
        }
    }
}


