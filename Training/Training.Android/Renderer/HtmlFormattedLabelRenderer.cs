using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Training.Droid.Renderer;
using Training.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HtmlFormattedLabel), typeof(HtmlFormattedLabelRenderer))]
namespace Training.Droid.Renderer
{
    public class HtmlFormattedLabelRenderer : LabelRenderer
    {
       public HtmlFormattedLabelRenderer(Context context) : base(context)
        {

        }

       
    }
}
