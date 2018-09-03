using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Components;
using Training.Ex;
using Xamarin.Forms;

namespace Training.Pages
{
	public class ReadingPage : ContentPage
	{

        
        public ReadingPage ()
		{
            BackgroundColor = Color.FromHex("#0b87a8");
            var BackGroundImage_ = new ImageUpload("arkaplan")
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            var BooksGrid = new ExGrid(5, 2);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    var Book_ = new Book("ChildrenImagination") { TappedCommand =  CallBook};
                    BooksGrid.Children.Add(Book_ , j, i);
                }
            }

            var ScrollView_ = new ScrollView() { Content = BooksGrid };

            var ContentGrid = new ExGrid();
            ContentGrid.Children.Add(BackGroundImage_, 0, 0);
            ContentGrid.Children.Add(ScrollView_, 0, 0);

            Content = ContentGrid;
        }

        public Command CallBook = new Command( async () => {

            var page = new BookReadingPage();
            var Navi = App.Current.MainPage.Navigation;
            await Navi.PushModalAsync(page);

        });
       
	}
}