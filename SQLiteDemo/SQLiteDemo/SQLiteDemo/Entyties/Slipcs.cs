using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SQLiteDemo.Entyties
{
    public class Slipcs : INotifyPropertyChanged
    {
        private int id;
        private string tableName;
        private DateTime visitTime;
        private int remaining;
        private bool delete;
        private bool save;
        private string status;



        [PrimaryKey,AutoIncrement]
        public int Id
        {
            get { return this.id; }
            set
            {
                if(this.id != value)
                {
                    this.id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string TableName
        {
            get { return this.tableName; }
            set
            {
                if (this.tableName != value)
                {
                    this.tableName = value;
                    OnPropertyChanged("TableName");
                }
            }
        }
        public DateTime VisitTime
        {
            get { return this.visitTime; }
            set
            {
                if (this.visitTime != value)
                {
                    this.visitTime = value;
                    OnPropertyChanged("VisitTime");
                }
            }
        }
        public int Remaining
        {
            get { return this.remaining; }
            set
            {
                if (this.remaining != value)
                {
                    this.remaining = value;
                    OnPropertyChanged("Remaining");
                }
            }
        }
        public bool Delete
        {
            get { return this.delete; }
            set
            {
                if (this.delete != value)
                {
                    this.delete = value;
                    OnPropertyChanged("Delete");
                }
            }
        }
        public bool Save
        {
            get { return this.save; }
            set
            {
                if (this.save != value)
                {
                    this.save = value;
                    OnPropertyChanged("Save");
                }
            }
        }
        public string Status
        {
            get { return this.status; }
            set
            {
                if (this.status != value)
                {
                    this.status = value;
                    OnPropertyChanged("Status");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
