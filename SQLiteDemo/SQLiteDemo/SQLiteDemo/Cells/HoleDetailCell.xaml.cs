using SQLiteDemo.Entyties;
using SQLiteDemo.Models;
using SQLiteDemo.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteDemo.Cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HoleDetailCell : ViewCell
    {

        readonly GestRepository _guest = new GestRepository();
        readonly SlipRepository _slip = new SlipRepository();
        private int _remaining;
        public Label remain;
        public  Label alert = new Label();
        


        public static readonly BindableProperty AlertProperty = BindableProperty.Create("Alert", typeof(string), typeof(HoleDetailCell), "");

        public string Alert
        {
            get { return (string)GetValue(AlertProperty); }
            set { SetValue(AlertProperty, value); }
        }
        
        public HoleDetailCell(MainPage main)
        {
            InitializeComponent();
            
            SetMenuItem(main);
            CreateCell(main);

        }

       


        void CreateCell(MainPage main)
        {
           
            var tableName = new Label();
            var table = new Label();
            var count = new Label();
            var visitTime = new Label();
            remain = new Label();
            Grid grid = new Grid();
            StackLayout cellWraper = new StackLayout();

            tableName.SetBinding(Label.TextProperty, "TableName");
            visitTime.SetBinding(Label.TextProperty, new Binding("VisitTime", stringFormat:"{0:yyy/MM/dd hh:mm}"));
            remain.SetBinding(Label.TextProperty, new Binding("Remaining", stringFormat: "残り:{0}"));
            alert.SetBinding(Label.TextProperty, "Status");
            alert.BindingContextChanged += (s, e) =>
            {
                var item = (Label)s;
                if(item.Text == "30分経過")
                {
                    alert.TextColor = Color.Red;
                    alert.FontSize = 15;
                }
                else if(item.Text == "会計")
                {
                    alert.TextColor = Color.Red;
                    alert.FontSize = 15;
                }
            };

            count.Text = "入店時間:";
            table.Text = "テーブル名:";

            

            cellWraper.Orientation = StackOrientation.Horizontal;
            tableName.HorizontalOptions = LayoutOptions.CenterAndExpand;
            tableName.FontSize = 15;
            alert.VerticalOptions = LayoutOptions.CenterAndExpand;
            alert.HorizontalOptions = LayoutOptions.CenterAndExpand;
            
            table.HorizontalOptions = LayoutOptions.CenterAndExpand;
            count.HorizontalOptions = LayoutOptions.CenterAndExpand;
            remain.VerticalOptions = LayoutOptions.CenterAndExpand;
            remain.HorizontalOptions = LayoutOptions.CenterAndExpand;
            remain.FontSize = 20;
            visitTime.HorizontalOptions = LayoutOptions.CenterAndExpand;

            grid.Children.Add(tableName);
            Grid.SetRow(tableName, 0);
            Grid.SetColumn(tableName, 1);
            grid.Children.Add(table);
            Grid.SetRow(table, 0);
            Grid.SetColumn(table, 0);
            grid.Children.Add(visitTime);
            Grid.SetRow(visitTime, 1);
            Grid.SetColumn(visitTime,1);
            grid.Children.Add(count);
            Grid.SetRow(count, 1);
            Grid.SetColumn(count, 0);
            grid.Children.Add(remain);
            Grid.SetRow(remain, 0);
            Grid.SetRowSpan(remain, 2);
            Grid.SetColumn(remain, 2);
            grid.Children.Add(alert);
            Grid.SetRow(alert, 0);
            Grid.SetRowSpan(alert, 2);
            Grid.SetColumn(alert, 3);

            

            cellWraper.Children.Add(grid);

            View = cellWraper;
        }

       

        void SetMenuItem(MainPage main)
        {
            var actionDelete = new MenuItem()
            {
                Text = "削除",
               
            };
            actionDelete.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            actionDelete.Clicked +=  (s, e) => main.Action((MenuItem)s);
           

            var detail = new MenuItem()
            {
                Text = "会計",
            };

            detail.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            detail.Clicked += (s, e) => main.Action((MenuItem)s);
            ContextActions.Add(detail);
            ContextActions.Add(actionDelete);

        }


        

        
    }
}