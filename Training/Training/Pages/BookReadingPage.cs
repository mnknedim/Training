using LabelHtml.Forms.Plugin.Abstractions;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
//using Syncfusion.DocIO;
//using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Training.Ex;
using Training.Renderer;
using Xamarin.Forms;

namespace Training.Pages
{
	public class BookReadingPage : ContentPage
	{
        public string htmlString
        {
            get => (string)GetValue(htmlStringProperty);
            set => SetValue(htmlStringProperty, value);
        }
        public static readonly BindableProperty htmlStringProperty = BindableProperty.Create("HtmlView", typeof(string), typeof(BookReadingPage), default(string));
      
        FormattedString BookText = new FormattedString();

		public BookReadingPage ()
		{
            BindingContext = this;
            
            Assembly assembly = typeof(BookReadingPage).GetTypeInfo().Assembly;
            Stream inputStream =
                assembly.GetManifestResourceStream("Training.Templates.read.html");
            StreamReader reader = new StreamReader(inputStream);
            htmlString = reader.ReadToEnd();

            var HtmlLabelText = new HtmlFormattedLabel() {
                FontSize = Device.GetNamedSize(NamedSize.Medium,typeof(HtmlFormattedLabel))
            };
            HtmlLabelText.SetBinding(HtmlFormattedLabel.FormattedTextProperty, new Binding { Path ="htmlString", Converter = new HtmlLabelConverter()});

            var st_layout = new StackLayout
            {
                Children =
                {
                    HtmlLabelText
                }
            };

            Content = new ScrollView { Content = st_layout };
        }

        public class HtmlLabelConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var formatteds = new FormattedString();
                var HtmlLabelString = (String)value;

                foreach (var item in HtmlLabelString.Split(' ').ToList())
                {
                    formatteds.Spans.Add(CreateSpan(new StringSection
                    {
                        Text = item,
                        Link = item +" "+ formatteds.Spans.Count(),
                    }));
                }

                return formatteds;
            }

            

            private Span CreateSpan(StringSection section)
            {
                var span = new Span()
                {
                    Text = section.Text + " "
                };

                span.GestureRecognizers.Add(new TapGestureRecognizer()
                {
                    Command = _navigationCommand,
                    CommandParameter = section.Link
                });
                span.TextColor = Color.Black;

                return span;

            }
            public class StringSection
            {
                public string Text { get; set; }
                public string Link { get; set; }
            }

            private ICommand _navigationCommand = new Command<string>((url) =>
            {
                var ClickedString = url.Substring(0, url.IndexOf(' '));
                App.Current.MainPage.DisplayAlert("Tıklanan Kelime", ClickedString, "Tamam");
               
            });

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}





