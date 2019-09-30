using SQLiteDemo.Entyties;
using SQLiteDemo.Models;
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
    public partial class GestComingView : ContentPage
    {
        readonly GestRepository _db = new GestRepository();
        public DisplayModel model = new DisplayModel();


        public string TableId { get; set; }
        private int num = 0;

        public GestComingView(string tableInfo)
        {
            this.TableId = tableInfo;
            this.BindingContext = this.model;
            this.model.Count = 0;
            InitializeComponent();
        }



        void AddCommand(object s, EventArgs e)
        {
            this.num += 1;
            ShowCount();
        }

        void PullCommand(object s, EventArgs e)
        {
            if(this.num != 0)
            {
                this.num -= 1;
                ShowCount();
            }
        }

        void NextCommand(object s, EventArgs e)
        {
            if(count.Text != "0")
            {
                Gest[] gestList = new Gest[this.num];
                for(int i = 0; i < this.num; i++)
                {
                    var item = new Gest() { Name = "お客様" + (i+1), TableId = this.TableId, InsertDate = DateTime.Now };
                    gestList[i] = item;
                }

                Navigation.PushModalAsync(new SetFeeView(gestList, TableId));
            }
            else
            {
                DisplayAlert("人数", "１人以上入力してください", "OK");
            }
        }


        void ShowCount()
        {
            this.model.Count = this.num;
        }
    }
}