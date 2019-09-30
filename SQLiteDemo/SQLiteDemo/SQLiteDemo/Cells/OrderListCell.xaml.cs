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
    public partial class OrderListCell : ViewCell
    {
        public OrderListCell()
        {
            InitializeComponent();
            CreateCell();
        }

        void CreateCell()
        {
            Label menu = new Label();
            Label guest = new Label();
            Label target = new Label();
            Label count = new Label();
            Label total = new Label();
            StackLayout cellWraper = new StackLayout();
            StackLayout horizontaLayout = new StackLayout();


            menu.SetBinding(Label.TextProperty, "MenuId");
            guest.SetBinding(Label.TextProperty, "GuestId");
            target.SetBinding(Label.TextProperty, "TargetId");
            count.SetBinding(Label.TextProperty, "Count");
            total.SetBinding(Label.TextProperty, new Binding("Sum", stringFormat:"{0:C}"));
            cellWraper.BackgroundColor = Color.GhostWhite;
            horizontaLayout.Orientation = StackOrientation.Horizontal;
            menu.TextColor = Color.Aqua;
            total.TextColor = Color.Red;
            menu.HorizontalOptions = LayoutOptions.Start;
            guest.HorizontalOptions = LayoutOptions.Fill;
            target.HorizontalOptions = LayoutOptions.Fill;
            count.HorizontalOptions = LayoutOptions.CenterAndExpand;
            total.HorizontalOptions = LayoutOptions.EndAndExpand;

            horizontaLayout.Children.Add(guest);
            horizontaLayout.Children.Add(menu);
            horizontaLayout.Children.Add(target);
            horizontaLayout.Children.Add(count);
            horizontaLayout.Children.Add(total);

            cellWraper.Children.Add(horizontaLayout);

            View = cellWraper;



        }

    }
}