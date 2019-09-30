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
    public partial class OrderView : ContentPage
    {
        readonly MenuRepository _menu = new MenuRepository();
        readonly OrderDetailRepository _order = new OrderDetailRepository();
        readonly UserRepository _user = new UserRepository();
        readonly WorkRepository _work = new WorkRepository();

        List<OrderInfo> instance = new List<OrderInfo>();
        OrderInfo info;
        public OrderView(OrderInfo oi)
        {
            this.info = oi;
            CreateView(this.info);
        }

        void CreateView(OrderInfo info)
        {
            var orderList = new ListView
            {
                ItemsSource = instance.ToArray(),
                ItemTemplate = new DataTemplate(typeof(OrderListCell))
            };
            orderList.ItemTapped += async(s, e) =>
            {
                var item = (OrderInfo)e.Item;
                var count = await DisplayActionSheet("数量","cansel",null,"1","2","3","4","5");
                if(count != "cansel")
                {
                    int index = e.ItemIndex;
                    int num = int.Parse(count);
                    orderList.ItemsSource = Updata(index, num);
                }
            };



            var orderlabel = new Label
            {
                Text = "注文情報",
                TextColor = Color.Black
            };

            var menuList = new ListView
            {
                ItemsSource = _menu.GetMenus(),
                ItemTemplate = new DataTemplate(typeof(TextCell))
            };
            menuList.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            menuList.ItemTemplate.SetBinding(TextCell.DetailProperty, new Binding("Price", stringFormat:"{0:C}"));

            menuList.ItemTapped += async(s, e) =>
            {
                var menu = (Entyties.Menu)e.Item;
                var target = await DisplayActionSheet("対象", "cancel", null, _user.GetUsers().ToArray());
                if(target == "cancel")
                {
                    await DisplayAlert("対象者", "対象者を選んでください", "OK");
                }
                else
                {
                    var oi = new OrderInfo { GuestId = info.GuestId ,MenuId = menu.Name, TargetId = target, SlipId = info.SlipId, Count = 1,Back = menu.Back, Sum = menu.Price };
                    int id = _order.SaveOrderInfo(oi);
                    Console.WriteLine(id);
                    oi.Id = id;
                    instance.Add(oi);
                    orderList.ItemsSource = instance.ToArray();
                }
            };

            var menuLabel = new Label
            {
                Text = "メニュー一覧",
                TextColor = Color.Black
            };


            var nextButton = new Button
            {
                Text = "決定",
                TextColor = Color.Red
            };
            nextButton.Clicked += async(s, e) =>
            {
                if(await DisplayAlert("注文を確定します", "よろしいでしょうか？", "OK", "キャンセル"))
                {
                    AddSlip(this.instance.ToArray());
                    await Navigation.PushModalAsync(new MainPage());
                }
            };


            Content = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Children ={menuLabel,menuList}
                    },
                    new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Children ={orderlabel,orderList}
                    },
                    nextButton
                }
            };

        }

        OrderInfo[] Updata(int index, int count)
        {
            var array = this.instance.ToArray();
            var name = array[index].MenuId;
            int price = _menu.FindPrice(name);
            array[index].Count = count;
            array[index].Sum = (count * price);

            return array;
        }


        void AddSlip(OrderInfo[] infos)
        {
            foreach (OrderInfo oi in infos)
            {
                oi.GuestId = info.GuestId;
                _order.SaveOrderInfo(oi);
            }
        }
    }
}