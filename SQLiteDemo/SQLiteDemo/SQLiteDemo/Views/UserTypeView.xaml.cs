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
    public partial class UserTypeView : ContentPage
    {
        readonly UserTypeRepository _db = new UserTypeRepository();

        public UserTypeView()
        {
            InitializeComponent();
            CreateView();
        }

        void CreateView()
        {
            var listView = new ListView
            {
                ItemsSource = _db.GetUserTypes(),
                ItemTemplate = new DataTemplate(typeof(TextCell))
            };
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "Id");

            listView.ItemTapped += async (s, e) =>
            {
                var item = (UserType)e.Item;
                if(await DisplayAlert("削除しますか？", item.Name, "OK", "キャンセル"))
                {
                    _db.Delete(item);
                    listView.ItemsSource = _db.GetUserTypes();
                }
            };

            var entry = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White
            };
            var addButton = new Button
            {
                Text = "Add",
                WidthRequest = 60,
                TextColor = Color.White
            };
            addButton.Clicked += (s, e) =>
            {
                if (!string.IsNullOrEmpty(entry.Text))
                {
                    var userType = new UserType { Name = entry.Text };
                    if(_db.SaveUserType(userType) == 0)
                    {
                        DisplayAlert("既に使用されています。", userType.Name, "OK");
                    }
                    listView.ItemsSource = _db.GetUserTypes();
                }
                else
                {
                    DisplayAlert("必須入力", "名前を入力して下さい", "OK");
                }

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
                        BackgroundColor = Color.Navy,
                        Children = {entry, addButton}
                    },
                    listView,
                    backButton
                }
            };
        }
    }
}