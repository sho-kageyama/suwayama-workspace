using SQLiteDemo.Cells;
using SQLiteDemo.Entyties;
using SQLiteDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteSlipDetailView : ContentPage
    {
        readonly OrderDetailRepository _order = new OrderDetailRepository();
        readonly SlipRepository _slip = new SlipRepository();
        readonly GestRepository _guest = new GestRepository();

        public DeleteSlipDetailView(SaveSlip slip)
        {
            InitializeComponent();
            CreateView(slip);
        }

        void CreateView(SaveSlip relay)
        {
            var label = new Label
            {
                Text = "伝票詳細:",
                FontSize = 40,
                TextColor = Color.White
            };

            var slipId = new Label
            {
                Text = relay.SlipId.ToString(),
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 40
            };

            var time = new Label
            {
                Text = "入店日時:",
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20

            };

            var visitTime = new Label
            {
                Text = _slip.FindOne(relay.SlipId).VisitTime.ToLongDateString() + _slip.FindOne(relay.SlipId).VisitTime.ToShortTimeString(),
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 15

            };

            var num = new Label
            {
                Text = "客数:",
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20

            };

            var numA = new Label
            {
                Text = _guest.CountGuest(relay.SlipId).ToString(),
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 15
            };

            var table = new Label
            {
                Text = "テーブル:",
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20
            };

            var tName = new Label
            {
                Text = _slip.FindOne(relay.SlipId).TableName,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 15
            };

            var guest = new Label
            {
                Text = "注文者",
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            var menu = new Label
            {
                Text = "メニュー",
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            var count = new Label
            {
                Text = "数量",
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };



            var detail = new Label
            {
                Text = "対象",
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            var sum = new Label
            {
                Text = "小計",
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };



            var total = new Label
            {
                Text = "合計:  " + string.Format("{0:C}", _order.GetTotal(relay.SlipId)),
                HorizontalOptions = LayoutOptions.EndAndExpand,
                FontSize = 40,
                TextColor = Color.Black
            };

            var listView = new ListView
            {
                ItemsSource = _order.DeleteOrderHistory(relay.SlipId),
                ItemTemplate = new DataTemplate(typeof(SaveSlipCell))
            };






            var backButton = new Button
            {
                Text = "戻る",
                TextColor = Color.Black
            };
            backButton.Clicked += (s, e) =>
            {
                Navigation.PopModalAsync();
            };


            Content = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                Children =
                {
                    new StackLayout
                    {
                        Padding = 5,
                        BackgroundColor = Color.Gray,
                        Orientation = StackOrientation.Horizontal,
                        Children = {label, slipId}
                    },
                     new StackLayout
                    {
                        Padding = 5,
                        BackgroundColor = Color.Gray,
                        Orientation = StackOrientation.Horizontal,
                        Children = {time, visitTime}
                    },
                      new StackLayout
                    {
                        Padding = 5,
                        BackgroundColor = Color.Gray,
                        Orientation = StackOrientation.Horizontal,
                        Children = {num, numA}
                    },
                       new StackLayout
                    {
                        Padding = 5,
                        BackgroundColor = Color.Gray,
                        Orientation = StackOrientation.Horizontal,
                        Children = {table, tName}
                    },
                    new StackLayout
                    {
                        BackgroundColor = Color.Gray,
                        Orientation = StackOrientation.Horizontal,
                        Children = {guest,menu,count,detail,sum}
                    },
                    listView,
                    total,
                    backButton
                }
            };

        }
    }
}