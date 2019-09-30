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
    public partial class SaveSlipView : ContentPage
    {
        readonly SlipHistoryRepository _save = new SlipHistoryRepository();

        public SaveSlipView()
        {
            InitializeComponent();
            CreateView();
        }

        void CreateView()
        {
            var listView = new ListView
            {
                ItemsSource = _save.GetSaveHistory(),
                ItemTemplate = new DataTemplate(typeof(TextCell))
            };
            listView.ItemTemplate.SetBinding(TextCell.TextProperty,new Binding("Id",stringFormat:"伝票ID:{0:}"));
            listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "SlipId");

            listView.ItemTapped += (s, e) =>
            {
                var item = (SaveSlip)e.Item;
                Navigation.PushModalAsync(new SaveSlipDetailView(item));


            };

            var label = new Label
            {
                Text = "タップで詳細が見れます",
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