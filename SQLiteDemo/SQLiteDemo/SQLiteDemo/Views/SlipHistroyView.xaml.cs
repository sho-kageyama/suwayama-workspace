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
    public partial class SlipHistroyView : ContentPage
    {
        public SlipHistroyView()
        {
            InitializeComponent();
        }

        void SaveHistCommand(object s, EventArgs e)
        {
            Navigation.PushModalAsync(new SaveSlipView());
        }

        void DeleteHistCommand(object s, EventArgs e)
        {
            Navigation.PushModalAsync(new DeleteSlipView());
        }

        void BackCommand(object s, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}