using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;

namespace LoginSystem
{
    [Activity(Label = "LoginSystem", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button mbtnSignUp;
        private ProgressBar mProgressBar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mbtnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            mProgressBar = FindViewById <ProgressBar> (Resource.Id.progressBar);

            //This is an event that we subscribe to
            mbtnSignUp.Click += (object sender, EventArgs args) =>
                { 
                    //Pull up dialog
                    FragmentTransaction transaction = FragmentManager.BeginTransaction();
                    dialog_SignUp signUpDialog = new dialog_SignUp();
                    signUpDialog.Show(transaction, "Dialog Fragment");

                    //Calling the event we created in the Dialog_signUp class
                    signUpDialog.mOnSignUpComplete += signUpDialog_mOnSignUpComplete;
                };
            
        }

        //The custom event we created is passed in this method
        void signUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            mProgressBar.Visibility = ViewStates.Visible;
            Thread thread = new Thread(AddLikeRequest);
            thread.Start();
        }

        //Dummy Method
        private void AddLikeRequest() {
            Thread.Sleep(3000);
            RunOnUiThread(() =>
                {
                    mProgressBar.Visibility = ViewStates.Invisible;
                });
        }
    }
}

