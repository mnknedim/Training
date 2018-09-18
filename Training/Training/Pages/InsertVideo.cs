using Firebase.Xamarin.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Model;
using Xamarin.Forms;

namespace Training.Pages
{
    public class InsertVideo : ContentPage
    {
        FirebaseClient firebase;
        public InsertVideo()
        {
            firebase = new FirebaseClient("https://training-a4c28.firebaseio.com/");
            var btn = new Button { Text = "Ekle" };
            btn.Clicked += async delegate
            {
                var video = new VideoModel
                {
                    Baslik = "Video Başlık",
                    Id = "Video_Id",
                    Link = "adasd.mp4"
                };

                try
                {
                    await firebase.Child("Videolar").PostAsync(video);
                    await DisplayAlert("", "Eklendi", "Tamam");
                }
                catch (Exception)
                {
                    await DisplayAlert("Hata", "Eklenmedi", "Tamam");
                }

                
            };

            

            Content = new StackLayout
            {
                Children = {
                   btn
                }
            };
        }
    }
}