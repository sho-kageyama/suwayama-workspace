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
    public partial class MenuView : ContentPage
    {
        readonly MenuRepository _db = new MenuRepository();
        readonly MenuTypeRepository _type = new MenuTypeRepository();
        public MenuView()
        {
            
            InitializeComponent();
            createView();
        }






        void createView()
        {
            var listView = new ListView
            {
                ItemsSource = _db.GetMenus(),
                ItemTemplate = new DataTemplate(typeof(TextCell))
            };

            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "TypeId");
            listView.ItemTemplate.SetBinding(TextCell.DetailProperty,"Price");

            listView.ItemTapped += async (s, e) =>
            {
                var item = (Entyties.Menu)e.Item;
                if (await DisplayAlert("削除しますか？", item.Name, "OK", "キャンセル"))
                {
                    _db.DeleteMenu(item);
                    listView.ItemsSource = _db.GetMenus();
                }
            };

            var entryName = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White
            };
            var nameLabel = new Label
            {
                Text = "メニュー名",
                WidthRequest = 60,
                TextColor = Color.White
            };

            var entryPrice = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White
            };
            var priceLabel = new Label
            {
                Text = "金額",
                WidthRequest = 60,
                TextColor = Color.White
            };

            var entryback = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White
            };
            var backLabel = new Label
            {
                Text = "バック金額",
                WidthRequest = 60,
                TextColor = Color.White
            };

            var typePicker = new Picker
            {
                ItemsSource = _type.GetStringList(),
                SelectedIndex = 1,
                WidthRequest = 180,
                BackgroundColor = Color.White

            };
            var AddButton = new Button
            {
                WidthRequest = 60,
                TextColor = Color.White,
                Text = "Add"
            };

            AddButton.Clicked += (s, e) =>
            {
                if (!string.IsNullOrEmpty(entryName.Text) && !string.IsNullOrEmpty(entryPrice.Text) && !string.IsNullOrEmpty(entryback.Text))
                {
                    var type = typePicker.SelectedItem;
                    var id = _type.GetId(type.ToString());
                    var menu = new Entyties.Menu { Name = entryName.Text, Price = int.Parse(entryPrice.Text), Back = int.Parse(entryback.Text), TypeId = id };
                    
                   if(_db.SaveMenu(menu) == 0)
                    {
                        DisplayAlert("既に使用されています。", menu.Name, "OK");
                    }
                    entryName.Text = "";
                    entryPrice.Text = "";
                    entryback.Text = "";
                        listView.ItemsSource = _db.GetMenus();
                }
                else
                {
                    DisplayAlert("必須入力","すべて入力してください", "OK");
                }
            };

            var backButton = new Button
            {
                Text = "戻る",
                WidthRequest = 60,
                TextColor = Color.White,
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
                    new StackLayout{
                        BackgroundColor = Color.Navy,
                        Padding = 5,
                        Orientation = StackOrientation.Horizontal,
                        Children = {entryName, nameLabel}
                    },
                    new StackLayout{
                        BackgroundColor = Color.Navy,
                        Padding = 5,
                        Orientation = StackOrientation.Horizontal,
                        Children = {entryPrice, priceLabel}
                    },
                    new StackLayout{
                        BackgroundColor = Color.Navy,
                        Padding = 5,
                        Orientation = StackOrientation.Horizontal,
                        Children = {entryback, backLabel}
                    },
                    new StackLayout{
                        BackgroundColor = Color.Navy,
                        Padding = 5,
                        Orientation = StackOrientation.Horizontal,
                        Children = {typePicker, AddButton}
                    },
                    listView,
                    backButton
                }
            };


        }
    }
}