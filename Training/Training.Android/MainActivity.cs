using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ZXing;
using Octane.Xamarin.Forms.VideoPlayer.Android;
using Android.Content;
using Octane.Xamarin.Forms.VideoPlayer;

namespace Training.Droid
{
    [Activity(Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
           
            this.Window.AddFlags(WindowManagerFlags.Fullscreen);
            global::Xamarin.Forms.Forms.Init(this, bundle);
           //z FormsVideoPlayer.Init();
            LoadApplication(new App());
        }

        public override void OnBackPressed()
        {
            if (App.Current.MainPage.Navigation.ModalStack.Count == 0)
            {
                var dlgAlert = (new AlertDialog.Builder(this)).Create();
                dlgAlert.SetMessage("Uygulamadan çıkmak istiyor musun?");
                dlgAlert.SetTitle("Çıkış");
                dlgAlert.SetButton("Hayır", HandllerNotingButton);
                dlgAlert.SetButton2("", HandllerNotingButton);
                dlgAlert.SetButton3("Evet", HandllerNotingButton);
                dlgAlert.Show();
            }
            else
                base.OnBackPressed();
        }

        void HandllerNotingButton(object sender, DialogClickEventArgs e)
        {
            AlertDialog objAlertDialog = sender as AlertDialog;
            Button btnClicked = objAlertDialog.GetButton(e.Which);
            if (btnClicked.Text == "Evet")
                base.OnBackPressed();

        }
    }
}

