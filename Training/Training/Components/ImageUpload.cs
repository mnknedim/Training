using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Training.Components
{
    public class ImageUpload : Image
    {
        public ImageUpload(string url)
        {

         
            if (string.IsNullOrWhiteSpace(url))
                return;
            Source = ImageSource.FromResource($"Training.Images.{url}.png",typeof(ImageUpload).Assembly);
        }
    }
}
