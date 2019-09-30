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
    public partial class SettingSetView : ContentPage
    {
        readonly SetRepository _set = new SetRepository();
        public SettingSetView()
        {
            InitializeComponent();
            CreateView();
        }

        void CreateView()
        {
            var listView = new ListView
            {
                ItemsSource = _set.FindAll(),
                ItemTemplate = new DataTemplate(typeof(TextCell))
            };
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Price");
            listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "Time");

            listView.ItemTapped += async(s, e) =>
            {
                var item = (Set)e.Item;
                if(await DisplayAlert("削除します,よろしいですか?", item.Name, "OK", "キャンセル"))
                {
                    _set.Delete(item);
                    listView.ItemsSource = _set.FindAll();
                }
            };

            var entryName = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                TextColor = Color.Black
            };
            var labelName = new Label
            {
                Text = "名前",
                TextColor = Color.White,
                WidthRequest = 60
            };
            var entryPrice = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                TextColor = Color.Black
            };
            var labelPrice = new Label
            {
                Text = "値段",
                TextColor = Color.White,
                WidthRequest = 60
            };
            var entryTime = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                TextColor = Color.Black
            };
            var labelTime = new Label
            {
                Text = "時間",
                TextColor = Color.White,
                WidthRequest = 60
            };
            var addButton = new Button
            {
                Text = "追加",
                TextColor = Color.White
            };
            addButton.Clicked += (s, e) =>
            {
                int price = int.Parse(entryPrice.Text);
                int time = int.Parse(entryTime.Text);
                var set = new Set { Name = entryName.Text, Price = price, Time = time};
                _set.SaveSet(set);
                listView.ItemsSource = _set.FindAll();
            };

            var backButton = new Button
            {
                Text = "戻る",
                TextColor = Color.AliceBlue
            };
            backButton.Clicked += (s, e) =>
            {
                Navigation.PopModalAsync();
            };


            Content = new StackLayout
            {
                Children =
                {
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        BackgroundColor = Color.Red,
                        Padding = 5,
                        Children ={entryName,labelName}
                    },
                     new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        BackgroundColor = Color.Red,
                        Padding = 5,
                        Children ={entryPrice,labelPrice}
                    },
                      new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        BackgroundColor = Color.Red,
                        Padding = 5,
                        Children ={entryTime,labelTime}
                    },
                      addButton,
                      listView,
                      backButton

                }
            };
        }
    }
}