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
    public partial class TableSettingView : ContentPage
    {
        readonly TableRepository _db = new TableRepository();
        readonly TableRelaySlipRepository _table = new TableRelaySlipRepository();
        public TableSettingView()
        {

            var listview = new ListView
            {
                ItemsSource = _db.FindAll(),
                ItemTemplate = new DataTemplate(typeof(TextCell))
            };
            listview.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            listview.ItemTemplate.SetBinding(TextCell.DetailProperty, new Binding("CreateDay", stringFormat: "{0:yyy/mm/dd hh:mm}"));

            listview.ItemTapped += async(s, e) =>
            {
                var item = (Tabel)e.Item;
                if(await DisplayAlert("削除しますか?",item.Name,"OK", "キャンセル"))
                {
                    item.Delete = true;
                    _db.SaveTable(item);
                    listview.ItemsSource = _db.FindAll();
                }
               

            };
            var entry = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White
            };
            var buttonAdd = new Button
            {
                WidthRequest = 60,
                TextColor = Color.White,
                Text = "Add"
            };
            buttonAdd.Clicked += (s, e) =>
            {
                if (!string.IsNullOrEmpty(entry.Text))
                {
                    var item = new Tabel { Name = entry.Text, CreateDay = DateTime.Now, Delete = false };
                    _db.SaveTable(item);
                    listview.ItemsSource = _db.GetTabels();
                    entry.Text = "";
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
                    new StackLayout
                    {
                        BackgroundColor = Color.Navy,
                        Padding = 5,
                        Orientation = StackOrientation.Horizontal,
                        Children = {entry, buttonAdd}
                    },
                    listview,
                    backButton
                }
            };
        }
    }
}