using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SQLiteDemo.Models
{
    public class DisplayModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int count;
        private string frag;

        public string Frag
        {
            get { return this.frag; }
            set
            {
                if(this.frag != value)
                {
                    this.frag = value;
                    OnPropertyChanged("Frag");
                }
            }
        }
        public int Count
        {
            get { return this.count; }
            set
            {
                if(this.count != value)
                {
                    this.count = value;
                    OnPropertyChanged("Count");
                }
            }
        }




        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
