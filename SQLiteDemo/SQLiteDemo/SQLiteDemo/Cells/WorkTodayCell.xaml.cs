using SQLiteDemo.Entyties;
using SQLiteDemo.Models;
using SQLiteDemo.Repository;
using SQLiteDemo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteDemo.Cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkTodayCell : ViewCell
    {
        public UserRepository _user = new UserRepository();
        readonly WorkRepository _work = new WorkRepository();
        public WorkTodayCell(WorkView view)
        {
            InitializeComponent();
            CreateCell(view);
        }

        void CreateCell(WorkView view)
        {
            var name = new Label();
            var work = new Label();
            var workS = new Switch();
            var time = new Label();
            var delete = new Button();
            StackLayout lay = new StackLayout();
            StackLayout cellWraper = new StackLayout();

            name.SetBinding(Label.TextProperty, "Name");
            work.SetBinding(Label.TextProperty, "State");
            workS.SetBinding(Switch.IsToggledProperty, "State");
            
            
            workS.Toggled += async(s, e) =>
            {
                var status = (bool)e.Value;
                if(status == true)
                {
                    var item = name.Text;
                    var start = DateTime.Now.ToLongDateString();
                    if (await view.DisplayAlert("出勤します","キャスト:"+item + " \n出勤時間:"+ DateTime.Now.ToShortTimeString(),"OK", "キャンセル"))
                    {
                        var kyast = new Work { Day = start, StartTime = DateTime.Now, UserName = item, State = true};
                        User user = _user.FindOne(item);
                        user.State = true;
                        _user.SaveUser(user);
                        //_work.SaveWork(kyast);
                       


                    }
                 


                }
                else
                {
                    var item = name.Text;
                    var start = DateTime.Now.ToLongDateString();
                    if (await view.DisplayAlert("退勤します", "キャスト:" + item + "時間:" + DateTime.Now.ToShortTimeString(), "OK", "キャンセル"))
                    {
                        User user = _user.FindOne(item);
                        user.State = false;
                        _user.SaveUser(user);
                        //_work.SaveWork(kyast);
                       
                    }
                   
                }
            };
            time.Text = DateTime.Now.ToLongDateString();
            time.TextColor = Color.Black;


            lay.Orientation = StackOrientation.Horizontal;
            name.HorizontalOptions = LayoutOptions.StartAndExpand;
            work.HorizontalOptions = LayoutOptions.CenterAndExpand;
            workS.HorizontalOptions = LayoutOptions.CenterAndExpand;
            time.HorizontalOptions = LayoutOptions.EndAndExpand;

            lay.Children.Add(name);
            lay.Children.Add(work);
            lay.Children.Add(workS);
            lay.Children.Add(time);

            cellWraper.Children.Add(lay);

            View = cellWraper;

        }
    }
}