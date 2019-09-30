using SQLiteDemo.Cells;
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
    public partial class WorkView : ContentPage
    {
        readonly WorkRepository _work = new WorkRepository();
        readonly UserRepository _user = new UserRepository();
        public WorkView()
        {
            InitializeComponent();
            CreateView();
        }


        void CreateView()
        {
            var listView = new ListView
            {
                ItemsSource = _user.KyastStuffAll(),
                ItemTemplate = new DataTemplate(() => new WorkTodayCell(this))
            };

            var label = new Label
            {
                Text = "キャスト勤怠",
                FontSize = 40,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
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
                        Padding = 5,
                        Orientation = StackOrientation.Horizontal,
                        BackgroundColor = Color.Black,
                        Children = {label}
                    },
                    listView,
                    backButton
                }
            };
        }
    }
}