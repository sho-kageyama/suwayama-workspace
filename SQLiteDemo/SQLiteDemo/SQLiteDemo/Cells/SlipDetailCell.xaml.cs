using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteDemo.Cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SlipDetailCell : ViewCell
    {
        public SlipDetailCell()
        {
            InitializeComponent();
            CreateCell();
        }

        void CreateCell()
        {
            Label guest = new Label();
            Label menu = new Label();
            Label count = new Label();
            Label back = new Label();
            Label total = new Label();
            StackLayout cellWraper = new StackLayout();
            StackLayout horizontalLayout = new StackLayout();

            guest.SetBinding(Label.TextProperty, "GuestId");
            menu.SetBinding(Label.TextProperty, "MenuId");
            count.SetBinding(Label.TextProperty, "Count");
            back.SetBinding(Label.TextProperty, "Back");
            total.SetBinding(Label.TextProperty, new Binding("Sum", stringFormat:"{0:C}"));

            cellWraper.BackgroundColor = Color.FloralWhite;
            horizontalLayout.Orientation = StackOrientation.Horizontal;
            guest.HorizontalOptions = LayoutOptions.Start;
            menu.HorizontalOptions = LayoutOptions.CenterAndExpand;
            count.HorizontalOptions = LayoutOptions.CenterAndExpand;
            back.HorizontalOptions = LayoutOptions.CenterAndExpand;
            total.HorizontalOptions = LayoutOptions.EndAndExpand;
            guest.TextColor = Color.BlueViolet;
            total.TextColor = Color.Red;

            horizontalLayout.Children.Add(guest);
            horizontalLayout.Children.Add(menu);
            horizontalLayout.Children.Add(count);
            horizontalLayout.Children.Add(back);
            horizontalLayout.Children.Add(total);
            cellWraper.Children.Add(horizontalLayout);

            View = cellWraper;

        }
    }
}