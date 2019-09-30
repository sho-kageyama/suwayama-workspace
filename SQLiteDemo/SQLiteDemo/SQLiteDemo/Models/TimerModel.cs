using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SQLiteDemo.Models
{
    public class TimerModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string time;

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





        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
