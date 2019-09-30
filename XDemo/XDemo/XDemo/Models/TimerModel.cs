using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XDemo.Models
{
   public class TimerModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string time;
        private string timerButton;

        public string Time
        {
            get { return this.time; }
            set
            {
                if(this.time != value)
                {
                    this.time = value;
                    OnPropertyChanged("Time");
                }
            }
        }

        public string TimerButton
        {
            get { return this.timerButton; }
            set
            {
                if(this.timerButton != value)
                {
                    this.timerButton = value;
                    OnPropertyChanged("TimerButton");
                }
            }
        }




        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
