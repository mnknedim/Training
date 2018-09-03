using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Components;
using Xamarin.Forms;

namespace Training.Ex
{
	public class ExButton : ContentView
	{
        public Command TappedCommand
        {
            get => (Command)GetValue(TappedCommandProperty);
            set => SetValue(TappedCommandProperty, value);
        }
        public static readonly BindableProperty TappedCommandProperty = BindableProperty.Create("TappedCommand", typeof(Command), typeof(ExButton), default(Command));


        public object TapSenderObejct { get; set; }

        public ExButton (string ButtonUrl)
		{
            TapSenderObejct = this;
            var BtnImage = new ImageUpload(ButtonUrl);

            Margin = new Thickness(20);
            Content = new StackLayout
            {
                Children = { BtnImage }
            };

            GestureRecognizers.Add(Helpers.Gesture.TappedGesture((s, e) => TappedCommand?.Execute(TapSenderObejct)));
		}

        public TapGestureRecognizer Tikla()
        {
            var tappedRegGes = new TapGestureRecognizer();
            tappedRegGes.Tapped += (s, e) =>
            {

            };

            return tappedRegGes;
        }
	}
}