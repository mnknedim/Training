using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Training.Ex
{
    public class ExGrid : Grid
    {
        public ExGrid(int row=1,int col=1)
        {
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;

            for (int i = 0; i < row; i++)
                RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            for (int i = 0; i < col; i++)
                ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }
    }
}
