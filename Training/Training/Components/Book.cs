using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Training.Components
{
    public class Book : ContentView
    {
        public Command TappedCommand
        {
            get => (Command)GetValue(TappedCommandProperty);
            set => SetValue(TappedCommandProperty, value);
        }
        public static readonly BindableProperty TappedCommandProperty = BindableProperty.Create("TappedCommand", typeof(Command), typeof(Book), default(Command));

        public object TapSenderObejct {get;set;}

        public Book (string BookUrl = "")
		{
            TapSenderObejct = this;
            Padding = new Thickness(20);
            var BookImage = new ImageUpload($"Books.{BookUrl}");
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;
            GestureRecognizers.Add(Helpers.Gesture.TappedGesture((s, e) => TappedCommand?.Execute(TapSenderObejct)));
            Content = BookImage;
		}


	}
}