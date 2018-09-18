using Acr.UserDialogs;
using Firebase.Xamarin.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Training.Components;
using Training.Dependency;
using Training.Ex;
using Training.Model;
using Training.Pages;
using Xamarin.Forms;


namespace Training
{
	public class MainPage : ContentPage
	{
        public MainPage ()
		{
            BackgroundColor = Color.FromHex("#0b87a8");
            var BackGroundImage_ = new ImageUpload("arkaplan")
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            var UserPanel = new ExButton("icon_user") { TappedCommand = UserCommand };
            var QrPanel = new ExButton("icon_qr") { TappedCommand = ScannerCommand };
            var StFirst = new ExStackLayout();
            StFirst.Children.Add(UserPanel);
            StFirst.Children.Add(QrPanel);

            var ListeningPanel = new ExButton("icon_music") { TappedCommand = InsertFirebaseCommand };
            var ReadingPanel = new ExButton("icon_reading") { TappedCommand = ReadingCommand};
            var StSecond = new ExStackLayout();
            StSecond.Children.Add(ListeningPanel);
            StSecond.Children.Add(ReadingPanel);

            var ExContent = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,

                Children =
                {
                    StFirst,
                    StSecond
                }
            };

            var ExGridContent = new ExGrid();

            ExGridContent.Children.Add(BackGroundImage_ , 0, 0);
            ExGridContent.Children.Add(ExContent, 0, 0);

            Content = ExGridContent;
        }

        public Command ScannerCommand = new Command(async () => {

            UserDialogs.Instance.ShowLoading("Açılıyor...", MaskType.Black);

            FirebaseClient firebase = new FirebaseClient("https://training-a4c28.firebaseio.com/");
            VideoModel GelenVideo;
            
            try
            {
                var scanner = DependencyService.Get<IQrReaderService>();
                var result = await scanner.ScannAsync();

                var aa =(await firebase.Child("Videolar").OnceAsync<VideoModel>()).Where(s=>s.Object.Id == result).Single();
                GelenVideo = new VideoModel
                {
                    Baslik = aa.Object.Baslik,
                    Link = aa.Object.Link,
                };


                if (result != null)
                {
                    var page = new VideoPage(GelenVideo);
                    var Navi = App.Current.MainPage.Navigation;
                    await Navi.PushModalAsync(page);
                }
            }
            catch (Exception ex)
            {
                var cc = ex;
                var aa = App.Current.MainPage;
                aa = new MainPage();
                await App.Current.MainPage.DisplayAlert("QR Kode Uuyarı!","Qr Okunamadı.","Tamam");
            }
        });

        public Command ReadingCommand = new Command( async () => {
            var page = new ReadingPage();
            var Navi = App.Current.MainPage.Navigation;
            await Navi.PushModalAsync(page);
        });

        public Command UserCommand = new Command(async () => {
            var page = new RestTry();
            var Navi = App.Current.MainPage.Navigation;
            await Navi.PushModalAsync(page);
        });

        public Command InsertFirebaseCommand = new Command(async () => {
            var page = new InsertVideo();
            var Navi = App.Current.MainPage.Navigation;
            await Navi.PushModalAsync(page);
        });
    }
}