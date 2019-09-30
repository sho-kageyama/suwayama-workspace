using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XDemo.Models
{
    public class MemoModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string date;
        private string subject;
        private string memo;
        private string now;

        public string Date
        {
            get { return this.date; }
            set
            {
                if(this.date != value)
                {
                    this.date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public string Subject
        {
            get { return this.subject; }
            set
            {
                if(this.subject != value)
                {
                    this.subject = value;
                    OnPropertyChanged("Subject");
                }
            }
        }

        public string Memo
        {
            get { return this.memo; }
            set
            {
                if(this.memo != value)
                {
                    this.memo = value;
                    OnPropertyChanged("Memo");
                }
            }
        }


        public string Now
        {
            get { return this.now; }
            set
            {
                if(this.now != value)
                {
                    this.now = value;
                    OnPropertyChanged("Now");
                }
            }
        }


        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
