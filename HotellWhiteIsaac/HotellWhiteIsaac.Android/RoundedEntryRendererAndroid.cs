using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HotellWhiteIsaac;
using HotellWhiteIsaac.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


//Denna klass skapar en ny version av XAMLS "Entry" så att man kan använda rundade kanter

[assembly: ExportRenderer(typeof(RoundedEntry), typeof(RoundedEntryRendererAndroid))]
namespace HotellWhiteIsaac.Droid
{
    public class RoundedEntryRendererAndroid : EntryRenderer
    {
        public RoundedEntryRendererAndroid(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(5f); //Anger hur mycket hörnen ska vara rundade
                gradientDrawable.SetStroke(2, Android.Graphics.Color.Black);
                gradientDrawable.SetColor(Android.Graphics.Color.White);
                Control.SetBackground(gradientDrawable);

                Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
            }

        }
    }
}