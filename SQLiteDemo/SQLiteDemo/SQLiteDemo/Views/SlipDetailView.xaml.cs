using SQLiteDemo.Cells;
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
    public partial class SlipDetailView : ContentPage
    {
        readonly OrderDetailRepository _order = new OrderDetailRepository();
        readonly MenuRepository _menu = new MenuRepository();
        readonly SlipRepository _slip = new SlipRepository();
        readonly GestRepository _guest = new GestRepository();
        readonly SlipHistoryRepository _history = new SlipHistoryRepository();
        readonly TableRepository _table = new TableRepository();

        Slipcs detail;
        public SlipDetailView(Slipcs relay)
        {
            InitializeComponent();
            this.detail = relay;
            CreateView(relay);
        }

        void CreateView(Slipcs relay)
        {
            var label = new Label
            {
                Text = "伝票詳細",
                FontSize = 40,
                TextColor = Color.White
            };

            var slipId = new Label
            {
                Text = relay.Id.ToString(),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 40
            };

            var guest = new Label
            {
                Text = "注文者",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            var menu = new Label
            {
                Text = "メニュー",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            var count = new Label
            {
                Text = "数量",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            var back = new Label
            {
                Text = "バック",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            var sum = new Label
            {
                Text = "小計",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };



            var total = new Label
            {
                Text = string.Format("{0:C}",_order.GetTotal(relay.Id)),
                HorizontalOptions = LayoutOptions.EndAndExpand,
                FontSize = 40,
                TextColor = Color.Black
            };

            var listView = new ListView
            {
                ItemsSource = _order.GetSlipId(relay.Id),
                ItemTemplate = new DataTemplate(typeof(SlipDetailCell))
            };

            listView.ItemTapped += async (s, e) =>
            {
                var item = (OrderInfo)e.Item;
                string menuName = _menu.GetMenuName(item.MenuId);
                if(await DisplayAlert("削除しますか？", item.GuestId +":"+ menuName +":"+ item.Sum, "OK", "cancel"))
                {
                    item.Delete = true;
                    _order.SaveOrderInfo(item);
                    listView.ItemsSource = _order.GetSlipId(relay.Id);
                    total.Text = _order.GetTotal(relay.Id).ToString();
                }
            };

            var paymaster = new Button
            {
                Text = "会計",
                TextColor = Color.Red,
                FontSize = 30
            };
            paymaster.Clicked += async(s, e) =>
            {
                if(await DisplayAlert("会計", "会計します、よろしいですか？", "OK", "キャンセル"))
                {
                    PayMaster();
                    await Navigation.PushModalAsync(new MainPage());
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
                        BackgroundColor = Color.Gray,
                        Orientation = StackOrientation.Horizontal,
                        Children = {label, slipId}
                    },
                    new StackLayout
                    {
                        BackgroundColor = Color.Gray,
                        Orientation = StackOrientation.Horizontal,
                        Children = {guest,menu,count,back,sum}
                    },
                    listView,
                    total,
                    paymaster,
                    backButton
                }
            };

        }

        void PayMaster()
        {
            //伝票をSave
            this.detail.Save = true;
            _slip.SaveSlipcs(this.detail);

            //履歴にSaveとして登録
            var hist = new SaveSlip { EndTime = DateTime.Now, SlipId = this.detail.Id, Save = true };
            _history.SaveSSlip(hist);

            //オーダー情報をSave
            var orderList = _order.GetSlipId(this.detail.Id);
            foreach(OrderInfo oi in orderList)
            {
                oi.Save = true;
                _order.SaveOrderInfo(oi);
            }

            //ゲストをDelete
            var guestList = _guest.getGests(this.detail.TableName);
            foreach(Gest g in guestList)
            {
                g.Delete = true;
                _guest.SaveGest(g);
            }

            //卓のUSE解除
            Tabel table = _table.FindOne(this.detail.TableName);
            table.Use = false;
            _table.SaveTable(table);
        }

    }
}