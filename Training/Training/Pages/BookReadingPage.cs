using Acr.UserDialogs;
using LabelHtml.Forms.Plugin.Abstractions;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
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
       
        public Command TapCommand
        {
            get => (Command)GetValue(TapCommandProperty);
            set => SetValue(TapCommandProperty, value);
        }
        public static readonly BindableProperty TapCommandProperty = BindableProperty.Create("TapCommand", typeof(Command), typeof(BookReadingPage), default(Command));

        public FormattedString formatteds;

        public StackLayout stLayout;
        public BookReadingPage()
        {
            BindingContext = this;
             formatteds = new FormattedString();

            Assembly assembly = typeof(BookReadingPage).GetTypeInfo().Assembly;
            Stream inputStream =
                assembly.GetManifestResourceStream("Training.Templates.read.html");
            StreamReader reader = new StreamReader(inputStream);
            htmlString = reader.ReadToEnd();

            var HtmlLabelText = new HtmlFormattedLabel()
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(HtmlFormattedLabel)),
                FormattedText = Convert(htmlString)
            };

            stLayout = new StackLayout
            {
                Margin = new Thickness(10,0,0,0),
                Children =
                {
                    HtmlLabelText,
                }
            };
            Content = new ScrollView {

                BackgroundColor = Color.Bisque,
                Content = stLayout
            };

            formatteds = Convert(htmlString);
        }

      

        public FormattedString Convert(string value)
        {
            var HtmlLabelString = (String)value;

            foreach (var item in HtmlLabelString.Split(' ','\n').ToList())
            {
                formatteds.Spans.Add(CreateSpan(new StringSection
                {
                    Text = item,
                    Link = item + " " + formatteds.Spans.Count() + ".",
                }));
            }

            return formatteds;
        }

    
        private Span CreateSpan(StringSection section)
        {
            var ret = new Span
            {
                Text = section.Text + " ",
                TextColor = Color.Black,
            };
            
            ret.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = TapCommand,
                CommandParameter = section.Link,
            });

            TapCommand = new Command<string>( (url) =>
            {

                var webClient = new WebClient(){ Encoding = System.Text.Encoding.GetEncoding("ISO-8859-9")};
                var ClickedString = url.Substring(0, url.IndexOf(' ')).Trim('.',',','!','?','"');
                string res = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF-8&text={0}&langpair={1}", ClickedString, "en|tr");
                string result = webClient.DownloadString(res);

                result = result.Substring(result.IndexOf("<span title=\"") + "<span title=\"".Length);
                result = result.Substring(result.IndexOf(">") + 1);
                result = result.Substring(0, result.IndexOf("</span>"));
                
                var sss = result.Trim();

                App.Current.MainPage.DisplayAlert(ClickedString +" =" , sss, "OK");

                stLayout.Children.Add(new Label { Text = ClickedString + " -> " + sss , FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))});

            });

            return ret;
        }


        public class StringSection
        {
            public string Text { get; set; }
            public string Link { get; set; }
        }

    }
}





