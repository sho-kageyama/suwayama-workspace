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
    public partial class OrderTableView : ContentPage
    {
        readonly SlipRepository _db = new SlipRepository();
        readonly GestRepository _guest = new GestRepository();

        OrderInfo info;

        public OrderTableView(Slipcs slip)
        {
            InitializeComponent();
            CreateView(slip);
        }



        void CreateView(Slipcs slip)
        {
            var listView = new ListView
            {
                ItemsSource = _guest.getGests(slip.TableName),
                ItemTemplate = new DataTemplate(typeof(TextCell))
            };
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "Id");

            listView.ItemTapped += async(s, e) =>
            {
                var guest = (Gest)e.Item;
                this.info = new OrderInfo { SlipId = slip.Id.ToString(), GuestId = guest.Name};
                await Navigation.PushModalAsync(new OrderView(this.info));
            };

            var label = new Label
            {
                Text = "注文者を選択してください。",
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
                    listView,
                    backButton
                }
            };

        }
    }
}