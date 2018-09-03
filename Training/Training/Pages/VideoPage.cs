using Octane.Xamarin.Forms.VideoPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Ex;
using Xamarin.Forms;
using Octane.Xamarin.Forms.VideoPlayer.Constants;
using Training.Components;

namespace Training.Pages
{
	public class VideoPage : ContentPage
	{
		public VideoPage (string result)
		{
            BackgroundColor = Color.FromHex("#0b87a8");
            var BackGroundImage_ = new ImageUpload("arkaplan"); ;

            VideoLayout = new StackLayout
            {
               // BackgroundColor = Color.Blue,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    new VideoPlayer()
                    {
                        Source = result,
                        AutoPlay = true,
                        FillMode = FillMode.ResizeAspectFill,
                    }
                 }
            };
        
            var UnderVideoLabel = new StackLayout
            {
                Children =
                {
                    new ExLabel()
                    {
                        Text = "13 - Gerund Infinitive Konu Anlatımı ve Pratik ",
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(ExLabel)),
                        TextColor = Color.White,
                        VerticalTextAlignment = TextAlignment.End
                    }
                }
            };
            var LabelGrid = new ExGrid() { };

            LabelGrid.Children.Add(new ColorWithOpacity(Color.FromHex("#1a1809")) 
                );
            LabelGrid.Children.Add(UnderVideoLabel);
           


            LabelLayout = new ExStackLayout
            {

                HeightRequest = 50,
                Children =
                {
                    LabelGrid
                }
            };

            ExerciseLayout = new ExStackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    new Exercise("ExerciseTest","Test"),
                    new Exercise("ExerciseReading","Reading"),

                }
            };

            var PageLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    VideoLayout,
                    LabelLayout,
                    ExerciseLayout
                }
            };

            var GridContent = new ExGrid();
            GridContent.Children.Add(BackGroundImage_, 0, 0);
            GridContent.Children.Add(PageLayout, 0, 0);

            Content = GridContent;
        }

        StackLayout VideoLayout;
        ExStackLayout ExerciseLayout;
        ExStackLayout LabelLayout;
      
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); 
            if (width > height)
            {
                LabelLayout.IsVisible = false;
                ExerciseLayout.IsVisible = false;
                VideoLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
                VideoLayout.VerticalOptions = LayoutOptions.FillAndExpand;
            }
            else
            {
                LabelLayout.IsVisible = true;
                ExerciseLayout.IsVisible = true;
                VideoLayout.HeightRequest = (App.Current.MainPage.Height / 2.6);
                VideoLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
                VideoLayout.VerticalOptions = LayoutOptions.Start;
            }
        }
    }
}