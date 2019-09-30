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
    public partial class UserView : ContentPage
    {
        readonly UserRepository _db = new UserRepository();
        readonly UserTypeRepository _type = new UserTypeRepository();
        public UserView()
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
            listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "TypeId");
            listView.ItemTapped += async (s, e) =>
            {
                var item = (User)e.Item;
                if (await DisplayAlert("削除しますか?", item.Name, "OK", "キャンセル"))
                {
                    _db.Delete(item);
                    listView.ItemsSource = _db.FindAll();
                }
            };

            var entryName = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White

            };

            var nameLabel = new Label
            {
                Text = "ユーザー名",
                WidthRequest = 80,
                TextColor = Color.White
            };

            var typePicker = new Picker
            {
                ItemsSource = _type.GetTypeList(),
                SelectedIndex = 0,
                WidthRequest = 180,
                BackgroundColor = Color.White
            };

            var addButton = new Button
            {
                WidthRequest = 10,
                TextColor = Color.White,
                Text = "Add"
            };
            addButton.Clicked += (s, e) =>
            {
                if (!string.IsNullOrEmpty(entryName.Text))
                {
                    var typeName = typePicker.SelectedItem;
                    var Id = _type.GetId(typeName.ToString());
                    var user = new User { Name = entryName.Text, TypeId = Id , State = false};
                    if(_db.SaveUser(user) == 0)
                    {
                        DisplayAlert("既に使用されています。", user.Name, "OK");
                    }
                    entryName.Text = "";
                    listView.ItemsSource = _db.FindAll();
                }
                else
                {
                    DisplayAlert("必須入力","名前を入力してください","OK");
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
                        Children = {entryName, nameLabel}
                    },
                    new StackLayout
                    {
                        Padding = 5,
                        BackgroundColor = Color.Navy,
                        Children = {typePicker, addButton}
                    },
                    listView,
                    backButton
                }
            };
        }
    }
}