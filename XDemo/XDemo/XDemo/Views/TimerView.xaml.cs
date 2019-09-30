using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XDemo.Models;

namespace XDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerView : ContentPage
    {
        public TimerModel TimerModel { get; } = new TimerModel();

        private bool _frag = false;
        private int _remaining = 0;
        private Timer _timer;
        public TimerView()
        {
            InitializeComponent();
            this.BindingContext = this.TimerModel;
            this.TimerModel.Time = "00:00";
            this.TimerModel.TimerButton = "start";
            this._timer = new Timer(On_TimerAsync,null,0,100);
        }


        void BackCommand(object s, EventArgs e)
        {
            Navigation.PopModalAsync();
        }


        void StartCommand(object s, EventArgs e)
        {
            if (!_frag)
            {
                _frag = true;
                this.TimerModel.TimerButton = "stop";
            }
            else
            {
                _frag = false;
                this.TimerModel.TimerButton = "start";
            }
        }


        void Add10MinCommand(object s, EventArgs e)
        {
            _remaining += 600 * 1000;
            ShowRemaining();
        }

        void Add1MinCommand(object s, EventArgs e)
        {
            _remaining += 60 * 1000;
            ShowRemaining();
        }

        void Add10SecCommand(object s, EventArgs e)
        {
            _remaining += 10 * 1000;
            ShowRemaining();
        }

        void Add1SecCommand(object s, EventArgs e)
        {
            _remaining += 1000;
            ShowRemaining();
        }

        void ResetCommand(object s, EventArgs e)
        {
            _frag = false;
            _remaining = 0;
            this.TimerModel.TimerButton = "start";
            ShowRemaining();
        }

        async void On_TimerAsync(object state)
        {
            await Task.Run(() =>
            {
                if (!_frag)
                {
                    return;
                }

                _remaining -= 100;
                if(_remaining <= 0)
                {
                    _frag = false;
                    _remaining = 0;
                    this.TimerModel.TimerButton = "start";
                }
                ShowRemaining();
            });
        }


        void ShowRemaining()
        {
            var sec = _remaining / 1000;
            this.TimerModel.Time = string.Format("{0:f0}:{1:d2}",sec / 60 ,sec % 60);
        }
    }
}