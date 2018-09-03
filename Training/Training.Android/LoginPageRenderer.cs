using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Training.Droid;
using Training.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace Training.Droid
{
    public class LoginPageRenderer : PageRenderer
    {
        
        public LoginPageRenderer(Context context) : base(context)
        {
            var intent = new Intent(context, typeof(LoginActivity));
            context.StartActivity(intent);
           
        }
    }
}