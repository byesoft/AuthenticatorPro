﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using ProAuth.Utilities;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ProAuth
{
    [Activity(Label = "LoginActivity")]
    public class ActivityLogin : AppCompatActivity
    {
        private const int RequestConfirmDeviceCredentials = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activityLogin);

            KeyguardManager keyguardManager = (KeyguardManager) GetSystemService(KeyguardService);
            Intent loginIntent = keyguardManager.CreateConfirmDeviceCredentialIntent(GetString(Resource.String.login), GetString(Resource.String.loginMessage));
            StartActivityForResult(loginIntent, RequestConfirmDeviceCredentials);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Android.App.Result resultCode, Intent data)
        {
            if(requestCode == RequestConfirmDeviceCredentials)
            {
                switch(resultCode)
                {
                    case Result.Canceled:
                        FinishAffinity();
                        break;

                    case Result.Ok:
                        Finish();
                        break;
                }
            }
        }


        public override bool OnSupportNavigateUp()
        {
            return false;
        }

        public override void OnBackPressed()
        {

        }
    }
}