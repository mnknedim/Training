using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Ex;
using Xamarin.Forms;

namespace Training.Components
{
	public class Exercise : ContentView
	{
		public Exercise (string ResimUrl = "" , string LabelText  = "")
		{
            Margin = new Thickness(15);

            var Image_ = new ImageUpload(ResimUrl);
            var Label_ = new ExLabel() {
                Text = LabelText,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(ExLabel)),
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.FromHex("#e9eae7"),
            };

            Content = new StackLayout {
              HorizontalOptions = LayoutOptions.CenterAndExpand,
              VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    Image_,
                    Label_,
                }
            };
		}
	}
}