using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XDemo.Models;

namespace XDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemoView : ContentPage
    {
        public MemoModel MemoModel { get; } = new MemoModel();
        public MemoView()
        {
            InitializeComponent();
            this.BindingContext = this.MemoModel;
            this.MemoModel.Now = DateTime.Today.ToString();
            this.MemoModel.Date = DateTime.Today.ToString();
            this.MemoModel.Subject = "";
            this.MemoModel.Memo = "";
        }

        void BackCommand(object s, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        void RegisterCommand(object s, EventArgs e)
        {
            DisplayAlert("登録", this.MemoModel.Date + "/" + this.MemoModel.Subject + "/" + this.MemoModel.Memo, "OK");
            MemoListModel.Current.MemoList.Add(new MemoModel()
            {
                Date = string.Format("{0:yyyy/MM/dd}", this.MemoModel.Date),
                Subject = this.MemoModel.Subject,
                Memo = this.MemoModel.Memo,

            }) ;

            Clear();
        }

        void ListCommand(object s, EventArgs e)
        {
            DisplayAlert("一覧","test","OK");
            Navigation.PushModalAsync(new MemoListView());
        }

        void ClearCommand(object s, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            this.MemoModel.Date = DateTime.Today.ToString();
            this.MemoModel.Subject = "";
            this.MemoModel.Memo = "";
        }
    }
}