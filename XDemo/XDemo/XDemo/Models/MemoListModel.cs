using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XDemo.Models
{
    public class MemoListModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static MemoListModel Current { get; } = new MemoListModel();
        public List<MemoModel> MemoList { get; } = new List<MemoModel>();

       

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
