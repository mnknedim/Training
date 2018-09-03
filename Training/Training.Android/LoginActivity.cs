using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Training.Pages;



namespace Training.Droid
{
    [Activity(Label = "" , Theme = "@style/Theme.Splash")]
    public class LoginActivity : Activity, GoogleApiClient.IConnectionCallbacks, IResultCallback,
        GoogleApiClient.IOnConnectionFailedListener
    {
        private GoogleApiClient mGoogleApiClient;
        private GoogleSignInResult result;

        //FirebaseClient firebase = new FirebaseClient("https://evradiezkar-f43d2.firebaseio.com/");

       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.Window.AddFlags(WindowManagerFlags.Fullscreen);
            var gSo = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
               .RequestEmail()
               .Build();

            mGoogleApiClient = new GoogleApiClient.Builder(this)
                .AddConnectionCallbacks(this)
                .AddOnConnectionFailedListener(this)
                .AddApi(Auth.GOOGLE_SIGN_IN_API, gSo)
                .Build();

            var signIntent = Auth.GoogleSignInApi.GetSignInIntent(mGoogleApiClient);

            StartActivityForResult(signIntent, 9001);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            var s = mGoogleApiClient.IsConnected;
            if (!s)
                mGoogleApiClient.Connect();

            result = Auth.GoogleSignInApi.GetSignInResultFromIntent(data);
            //mGoogleAccount.Add(mGoogleApiClient);
            this.Finish();
            App.Current.MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            base.OnStart();
            mGoogleApiClient.Connect();
        }

        protected override void OnStop()
        {
            base.OnStop();
            if (mGoogleApiClient.IsConnected)
                mGoogleApiClient.Disconnect();
        }

        public void CheckAccount()
        {

        }

        public void OnConnected(Bundle connectionHint)
        {
         
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
           
        }

        public void OnConnectionSuspended(int cause)
        {
         
        }

        public void OnResult(Java.Lang.Object result)
        {
           
        }
    }
}