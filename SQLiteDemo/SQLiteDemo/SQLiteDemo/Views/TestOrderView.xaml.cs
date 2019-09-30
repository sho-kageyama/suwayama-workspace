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
    public partial class TestOrderView : ContentPage
    {
        readonly TableRelaySlipRepository _db = new TableRelaySlipRepository();

        public TestOrderView()
        {
            InitializeComponent();
            CreateTableView();
        }


        void CreateTableView()
        {
            var listView = new ListView
            {
                ItemsSource = _db.FindAll(),
                ItemTemplate = new DataTemplate(typeof(TextCell))
            };
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "TableId");
            listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "SlipId");

            listView.ItemTapped += (s, e) =>
            {
                var item = (TableSlipRelay)e.Item;
                //Navigation.PushModalAsync(new OrderView(item));
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
                    listView,
                    backButton
                }
            };
        }


       
    }
}