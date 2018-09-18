using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;


namespace Training.Droid.Activities
{
    [Activity(Label = "BookReadingActivity")]
    public class BookReadingActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //WebView webView = new WebView(this);
            //webView.Settings.JavaScriptEnabled = true;
            //webView.SetWebChromeClient(new WebChromeClient());
            //var htmls = "";
            //var assetManager = this.Assets;

            //webView.LoadDataWithBaseURL("", htmls, "text/html", "UTF-8", "");

            //webView.LoadDataWithBaseURL("file:///android_asset/", html, "text/html", "UTF-8", null);

            //var js = "alert('test');";
            //webView.LoadUrl("javascript:" + js);

            ////var html = "<html><h1>Hello</h1><p>World</p></html>";
        }
    }

    //public class MyJSInterface : Java.Lang.Object
    //{
    //    Context context;

    //    public MyJSInterface(Context context)
    //    {
    //        this.context = context;
    //    }

    //    public void ShowToast()
    //    {
    //        Toast.MakeText(context, "Hello from C#", ToastLength.Short).Show();
    //    }
    //}
}