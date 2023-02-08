using JustDoIt.Enums;
using SQLite;
using System;

namespace JustDoIt.Models
{
    public class ToDoNote /*: INotifyPropertyChanged*/
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Done { get; set; }

        public bool IsFavourite { get; set; }

        public DateTime? CreationDateTime { get; set; }

        public DateTime? DeadlineDateTime { get; set; }

        public bool IsItalic { get; set; }

        public bool IsBold { get; set; }

        public string Hyperlink { get; set; } = Constants.DefaultSite;
        
        public Priority Priority { get; set; }
    }
}
