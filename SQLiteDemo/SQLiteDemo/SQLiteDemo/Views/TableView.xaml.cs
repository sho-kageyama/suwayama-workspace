using SQLiteDemo.Entyties;
using SQLiteDemo.Repository;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableView : ContentPage
    {
        readonly TableRepository _db = new TableRepository();
        readonly TableRelaySlipRepository _table = new TableRelaySlipRepository();
        public TableView() { 

            var listview = new ListView
            {
                ItemsSource = _db.GetTabels(),
                ItemTemplate = new DataTemplate(typeof(TextCell))
            };
            listview.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            listview.ItemTemplate.SetBinding(TextCell.DetailProperty, new Binding("CreateDay",stringFormat:"{0:yyy/mm/dd hh:mm}"));

            listview.ItemTapped += (s, e) =>
            {
                var item = (Tabel)e.Item;
                Navigation.PushModalAsync(new GestComingView(item.Name));
                
            };
            var label = new Label
            {
                Text = "卓を選択してください。",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                TextColor = Color.Black
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
                        Children = {label}
                    },
                    listview,
                    backButton
                }
            };
        }
    }
}