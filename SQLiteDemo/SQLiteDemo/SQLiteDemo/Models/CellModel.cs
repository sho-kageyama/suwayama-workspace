using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SQLiteDemo.Models
{
    public class CellModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string tableName;
        private DateTime visitTime;
        private int remaining;
        private string status;

        
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
