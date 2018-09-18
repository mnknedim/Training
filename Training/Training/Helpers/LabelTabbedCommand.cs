using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Training.Helpers
{
    public static partial class LabelTabbedCommand
    {

        public static TapGestureRecognizer TappedGesture(string Link)
        {
            var tp = new TapGestureRecognizer()
            {
                Command = NavigationCommand,
                CommandParameter = Link
            };
            return tp;
        }


        public static Command NavigationCommand = new Command<string>((url) =>
        {
            var ClickedString = url.Substring(0, url.IndexOf(' '));
            App.Current.MainPage.DisplayAlert("", ClickedString, "Ok");

        });

        //public static Command ReadingCommand = new Command(async () => {
        //    var page = new ReadingPage();
        //    var Navi = App.Current.MainPage.Navigation;
        //    await Navi.PushModalAsync(page);
        //});
    }

    
}
