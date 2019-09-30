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
    public partial class SettingView : ContentPage
    {
        public SettingView()
        {
            InitializeComponent();
        }

        void MenuCommand(object s, EventArgs e)
        {
            Navigation.PushModalAsync(new MenuView());
        }

        void TypeCommand(object s, EventArgs e)
        {
            Navigation.PushModalAsync(new MenuTypeView());
        }

        void TableCommand(object s, EventArgs e)
        {
            Navigation.PushModalAsync(new TableSettingView());
        }

        void UserCommand(object s, EventArgs e)
        {
            Navigation.PushModalAsync(new UserView());
        }

        void UserTypeCommand(object s, EventArgs e)
        {
            Navigation.PushModalAsync(new UserTypeView());
        }

        void SetCommand(object s, EventArgs e)
        {
            Navigation.PushModalAsync(new SettingSetView());
        }

        void BackCommand(object s, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

    }
}