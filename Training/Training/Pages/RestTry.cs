using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Training.Pages
{
    
    public class Post
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
    public class RestTry : ContentPage
	{
        private const string url = "https://jsonplaceholder.typicode.com/posts";
        private HttpClient _Client = new HttpClient();
        private ObservableCollection<Post> _post;
        public ListView Post_List = new ListView()
        {
            ItemTemplate = new DataTemplate(typeof(CustomViewCell))
        };
        public RestTry ()
		{
			Content = new StackLayout {
				Children = {
                    Post_List
                }
			};
		}
        protected override async void OnAppearing()
        {
            var content = await _Client.GetStringAsync(url);
            var post = JsonConvert.DeserializeObject<List<Post>>(content);
            _post = new ObservableCollection<Post>(post);
            Post_List.ItemsSource = _post;
            

            base.OnAppearing();
        }

        public class CustomViewCell : ViewCell
        {
            public CustomViewCell()
            {
                var body = new Label();
                body.SetBinding(Label.TextProperty, new Binding("body"));
                View = body;
            }
        }
       
    }
}