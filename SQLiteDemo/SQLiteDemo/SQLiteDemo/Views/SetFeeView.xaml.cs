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
    public partial class SetFeeView : ContentPage
    {
        readonly MenuRepository _menu = new MenuRepository();
        readonly SlipRepository _slip = new SlipRepository();
        readonly OrderDetailRepository _order = new OrderDetailRepository();
        readonly GestRepository _gest = new GestRepository();
        readonly TableRepository _table = new TableRepository();
        readonly SetRepository _set = new SetRepository();

        private string TableId { get; set; }
        private List<string> priceList = new List<string>();
        private List<string> timeList = new List<string>();
        private OrderInfo[] orderInfos;
        private int remaining = 60;

        public SetFeeView(Gest[] gestList, string tableId)
        {
            InitializeComponent();
            this.TableId = tableId;
            MakeList(gestList);
            CreateView(TableId, gestList);
        }


        void CreateView(string TableId, Gest[] gests)
        {
           

            for(int i = 0; i < gests.Length; i++)
            {
                var g = new Grid();

                g.VerticalOptions = LayoutOptions.Center;

                var labelName = new Label
                {
                    Text = gests[i].Name,
                    TextColor = Color.Red
                };

                var labelTime = new Label
                {
                    Text = "時間"
                };

                var time = new Picker
                {
                    ItemsSource = this.timeList,
                    SelectedIndex = 0,

                };
                time.SelectedIndexChanged += (s, e) =>
                {
                    var t = time.SelectedItem;
                    int index = stk.Children.IndexOf(g);
                    SetTime(index, t.ToString());
                    Console.WriteLine(index);
                };

                var price = new Picker
                {
                    ItemsSource = this.priceList,
                    SelectedIndex = 0,
                };
                price.SelectedIndexChanged += (s, e) =>
                {
                    var p = price.SelectedItem;
                    int index = stk.Children.IndexOf(g);
                    SetOrder(index, p.ToString());
                    Console.WriteLine(index);
                };

                g.Children.Add(labelName);
                Grid.SetColumn(labelName, 0);
                g.Children.Add(labelTime);
                Grid.SetColumn(labelTime, 1);
                g.Children.Add(time);
                Grid.SetColumn(time,2);
                g.Children.Add(price);
                Grid.SetColumn(price,3);
                stk.VerticalOptions = LayoutOptions.CenterAndExpand;
                stk.Children.Add(g);


            }



            var backButton = new Button
            {
                Text = "戻る",
                TextColor = Color.Black
            };
            backButton.Clicked += (s, e) =>
            {
                Navigation.PopModalAsync();
            };

            var nextCommand = new Button
            {
                Text = "決定",
                TextColor = Color.Black
            };

            nextCommand.Clicked += (s, e) => 
            {
                bool frag = false;
                foreach(OrderInfo oi in orderInfos)
                {
                    if(oi.MenuId == null)
                    {
                        frag = true;
                    }
                }
                if(frag == true)
                {
                    DisplayAlert("セット料金", "セットを選択してください。", "OK");
                }
                else
                {
                    CreateSlips(orderInfos);
                    Navigation.PushModalAsync(new MainPage());
                }

            };








                   stk.Children.Add(nextCommand);
                   stk.Children.Add(backButton);
           

           
        }

      


        void MakeList(Gest[] gests)
        {
            orderInfos = new OrderInfo[gests.Length];
            for(int i = 0; i< gests.Length; i++)
            {
                orderInfos[i] = new OrderInfo { GuestId = gests[i].Name, SlipId = gests[i].TableId}; 
            }

            var set = _set.FindAll();
            foreach (Set s in set)
            {
                this.timeList.Add(s.Time.ToString());
                this.priceList.Add(s.Price.ToString());
            }
        }

        void SetOrder(int index, string id)
        {
            int price = int.Parse(id);
            string name = _set.GetName(id);
            this.orderInfos[index].MenuId = name;
            this.orderInfos[index].Sum = price;
           
        }

        void SetTime(int index, string time)
        {
            int t = int.Parse(time);
            this.remaining = t;

        }

        void CreateSlips(OrderInfo[] orderInfos)
        {
            var slip = new Slipcs { VisitTime = DateTime.Now, TableName = this.TableId , Remaining = this.remaining, Status = "在席"};
            _slip.SaveSlipcs(slip);
            int slipId = _slip.GetSlipId(this.TableId);
           

            int tId = _table.GetId(this.TableId);
            var table = new Tabel { Id = tId, Name = this.TableId, Use = true };
            _table.SaveTable(table);


            foreach(OrderInfo oi in orderInfos)
            {
                var user = new Gest { Name = oi.GuestId, TableId = this.TableId, SlipId = slipId ,InsertDate = DateTime.Now };
                _gest.SaveGest(user);

                var set = _set.FindOne(oi.MenuId);
                var order = new OrderInfo { SlipId = slipId.ToString(), GuestId = oi.GuestId, MenuId = set.Name, Count = 1,Back = oi.Back, TargetId = oi.TargetId, Sum = set.Price };
                _order.SaveOrderInfo(order);
            }
        }

    }
}