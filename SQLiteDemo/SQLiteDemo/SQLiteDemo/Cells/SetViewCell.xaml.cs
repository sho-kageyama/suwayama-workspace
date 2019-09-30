using SQLiteDemo.Entyties;
using SQLiteDemo.Repository;
using SQLiteDemo.Views;
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
    public partial class SetViewCell : ViewCell
    {
        readonly SetRepository _set = new SetRepository();
        private List<string> timeList = new List<string>();
        private List<string> priceList = new List<string>();
        public SetViewCell(SetFeeView setview)
        {
            InitializeComponent();
            MakeList();
            CreateCell(setview);
        }

        void CreateCell(SetFeeView setview)
        {
            var name = new Label();
            var table = new Label();
            var time = new Picker();
            var price = new Picker();
            var horizonal = new StackLayout();
            var cellWraper = new StackLayout();

            name.SetBinding(Label.TextProperty, "Name");
            table.SetBinding(Label.TextProperty, "TableId");
            time.ItemsSource = this.timeList;
            
            time.SelectedIndex = 0;
            time.SelectedIndexChanged += (s, e) => 
            {
                var t = time.SelectedItem;
               
                

            };

            price.ItemsSource = this.priceList;
            price.SelectedIndex = 0;
            price.SelectedIndexChanged += (s, e) =>
            {

                var place = cellWraper.Children;
                Console.WriteLine(place);
                var p = price.SelectedItem;
                Console.WriteLine(p);
            };

            name.HorizontalOptions = LayoutOptions.Start;
            table.HorizontalOptions = LayoutOptions.CenterAndExpand;
            time.HorizontalOptions = LayoutOptions.CenterAndExpand;
            price.HorizontalOptions = LayoutOptions.EndAndExpand;
            horizonal.Orientation = StackOrientation.Horizontal;

            horizonal.Children.Add(name);
            horizonal.Children.Add(table);
            horizonal.Children.Add(time);
            horizonal.Children.Add(price);

            cellWraper.Children.Add(horizonal);

            View = cellWraper;

        }


        void MakeList()
        {
            var set = _set.FindAll();
            foreach(Set s in set)
            {
                this.timeList.Add(s.Time.ToString());
                this.priceList.Add(s.Price.ToString());
            }
        }
    }
}