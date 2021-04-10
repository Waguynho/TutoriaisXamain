using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.App;
using Android.Util;

using System;

namespace Phoneword.Droid
{
    [Activity(MainLauncher = false, NoHistory = true)]
    public class SplashActivity : Activity, ActivityCompat.IOnRequestPermissionsResultCallback
    {
        public SplashActivity()
        {

        }
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.SplashScreen);
            }
            catch (Exception e)
            {

                Log.Debug(TAG, "SplashActivity.OnCreate ==> " + e.Message);
            }

        }

        protected override void OnStart()
        {
            base.OnStart();
            Log.Debug(TAG, "SplashActivity.OnStart");
            VerifyPermissions();
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }

        #region Permissions
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            if (requestCode == 0)
            {
                // Received permission result for camera permission.
                Log.Info(TAG, "Received response for Location permission request.");

                // Check if the only required permission has been granted
                if ((grantResults.Length == 1) && (grantResults[0] == Permission.Granted))
                {
                    // Location permission has been granted, okay to retrieve the location of the device.
                    Log.Info(TAG, "Location permission has now been granted.");
                    StartApp();
                }
                else
                {
                    Log.Info(TAG, "Location permission was NOT granted.");
                    RunOnUiThread(() =>
                    {
                        this.RequestPermissions(new String[] { Manifest.Permission.BluetoothPrivileged, }, 0);
                    });
                }
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }

        private void StartApp()
        {
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        private void VerifyPermissions()
        {
            if (this.ApplicationContext.CheckSelfPermission(Manifest.Permission.BluetoothPrivileged) == (int)Permission.Granted)
            {
                StartApp();
            }
            else
            {
                RunOnUiThread(() =>
                {
                    ActivityCompat.RequestPermissions(this ,new String[] { Manifest.Permission.BluetoothPrivileged }, 0);
                });
            }
        }
        #endregion
    }
}