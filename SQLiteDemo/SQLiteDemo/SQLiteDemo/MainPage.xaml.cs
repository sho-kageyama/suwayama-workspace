using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SQLiteDemo.Cells;
using SQLiteDemo.Entyties;
using SQLiteDemo.Models;
using SQLiteDemo.Repository;
using SQLiteDemo.Views;
using Xamarin.Forms;

namespace SQLiteDemo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        readonly SlipRepository _slip = new SlipRepository();
        readonly OrderDetailRepository _order = new OrderDetailRepository();
        readonly MenuRepository _menu = new MenuRepository();
        readonly GestRepository _guest = new GestRepository();
        readonly SlipHistoryRepository _history = new SlipHistoryRepository();
        readonly TableRepository _table = new TableRepository();


        private ObservableCollection<Slipcs> slipList = new ObservableCollection<Slipcs>();
        private List<HoleDetailCell> cellList = new List<HoleDetailCell>();

        ListView listView;
        public MainPage()
        {
            InitializeComponent();


           
            
            CreateTableView();
            
        }

        void TableCommand(object s, EventArgs e)
        {
            Navigation.PushModalAsync(new Views.TableView());
        }

       
        void SlipCommand(object s, EventArgs e)
        {
            Navigation.PushModalAsync(new SlipHistroyView());
        }

        void WorkCommand(object s, EventArgs e)
        {
            Navigation.PushModalAsync(new WorkView());
        }



        void CreateTableView()
        {
            MakeSlipList();
            this.listView = new ListView(ListViewCachingStrategy.RecycleElement)
            {
                ItemsSource = this.slipList,
                ItemTemplate = new DataTemplate(() => {
                    var hole = new HoleDetailCell(this);
                    hole.alert.SetBinding(Label.TextProperty, "Status");
                    cellList.Add(hole);
                    return hole;
                    
                })
            };

            listView.ItemAppearing += (s, e) =>
            {
                var index = e.ItemIndex;
                if(index > 0)
                {
                    index += 1;
                }
                var item = (Slipcs)e.Item;
                
                Timer(item.Id, index);
                listView.ItemsSource = this.slipList;
            };


            listView.ItemTapped += (s, e) =>
            {
                var item = (Slipcs)e.Item;
                Navigation.PushModalAsync(new OrderTableView(item));
            };

          


            stk.Children.Add(listView);

           
           
        }

        


        void Timer(int id, int index)
        {
            Slipcs slip = _slip.FindOne(id);
            int re = slip.Remaining;
            if(re != 0)
            {
                Device.StartTimer(TimeSpan.FromSeconds(5), () => {

                    slip.Remaining -= 2;
                    _slip.SaveSlipcs(slip);
                    MakeSlipList();
                    if (slip.Remaining == 30)
                    {
                        var array = this.cellList.ToArray();
                        slip.Status = "30分経過";
                        _slip.SaveSlipcs(slip);
                       
                        MakeSlipList();
                        return true;
                    }
                    else if (slip.Remaining <= 0)
                    {
                        var array = this.cellList.ToArray();
                        slip.Status = "会計";
                        _slip.SaveSlipcs(slip);
                        
                        MakeSlipList();
                        return false;
                    }
                    return true;
                });
          
            }
        }

       
        

        public async void Action(MenuItem item)
        {
            var data = item.CommandParameter;
            var slip = (Slipcs)data;
            if (item.Text == "削除")
            {
                if (await DisplayAlert("伝票を削除します", "テーブル:" + slip.TableName + "伝票:" + slip.Id, "OK", "キャンセル"))
                {
                    DeleteSlip(slip);
                    this.slipList.RemoveAt(this.slipList.IndexOf(slip));
                }
            }else if(item.Text == "会計")
            {
                await Navigation.PushModalAsync(new SlipDetailView(slip));
            }

        }

        void MakeSlipList()
        {
            this.slipList.Clear();
            foreach (Slipcs s in _slip.FindAll())
            {
                slipList.Add(s);
            }
        }
       


        void SettingCommand(object s, EventArgs e)
        {
            Navigation.PushModalAsync(new SettingView());
        }



        void DeleteSlip(Slipcs slip)
        {
            //伝票をDelete
            slip.Delete = true;
            _slip.SaveSlipcs(slip);

            //履歴にDeleteとして登録
            var hist = new SaveSlip { EndTime = DateTime.Now, SlipId = slip.Id, Delete = true };
            _history.SaveSSlip(hist);

            //オーダー情報をDelete
            var orderList = _order.GetSlipId(slip.Id);
            foreach (OrderInfo oi in orderList)
            {
                oi.Delete = true;
                _order.SaveOrderInfo(oi);
            }

            //ゲストをDelete
            var guestList = _guest.getGests(slip.TableName);
            foreach (Gest g in guestList)
            {
                g.Delete = true;
                _guest.SaveGest(g);
            }

            //卓のUSE解除
            Tabel table = _table.FindOne(slip.TableName);
            table.Use = false;
            _table.SaveTable(table);
        }
    }
}
