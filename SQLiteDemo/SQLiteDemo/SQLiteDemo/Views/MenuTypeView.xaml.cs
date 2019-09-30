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
    public partial class MenuTypeView : ContentPage
    {
        readonly MenuTypeRepository _db = new MenuTypeRepository();
        public MenuTypeView()
        {
            
            InitializeComponent();
            CreateView();
        }





        void CreateView()
        {
            var listView = new ListView
            {
                ItemsSource = _db.FindAll(),
                ItemTemplate = new DataTemplate(typeof(TextCell))
            };
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "Id");
            

            listView.ItemTapped += async (s, e) =>
            {
                var item = (MenuType)e.Item;
                if (await DisplayAlert("削除しますか？", item.Name, "OK", "キャンセル"))
                {
                    _db.DeleteType(item);
                    listView.ItemsSource = _db.FindAll();
                }

            };

            var entry = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White
            };

            var addButton = new Button
            {
                WidthRequest = 60,
                TextColor = Color.White,
                Text = "Add"
            };

            addButton.Clicked += (s, e) =>
            {
                if (!string.IsNullOrEmpty(entry.Text))
                {
                    var type = new MenuType { Name = entry.Text, Date = DateTime.Now };
                    _db.SaveType(type);
                    listView.ItemsSource = _db.FindAll();
                    entry.Text = "";
                }
            };

            var backButton = new Button
            {
                Text = "戻る",
                WidthRequest = 60,
                TextColor = Color.White
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
                        BackgroundColor = Color.Navy,
                        Padding = 5,
                        Orientation = StackOrientation.Horizontal,
                        Children = {entry, addButton}
                    },
                    listView,
                    backButton

                }
            };
        }
    }
}