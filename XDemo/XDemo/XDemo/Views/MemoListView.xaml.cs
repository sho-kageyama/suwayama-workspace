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
    public partial class MemoListView : ContentPage
    {
        public  List<MemoModel> memoCell = new List<MemoModel>();
        public MemoListView()
        {
            InitializeComponent();
            memoCell.AddRange(MemoListModel.Current.MemoList);
            this.BindingContext = memoCell;
        }
    }
}