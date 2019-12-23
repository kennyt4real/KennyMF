using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KennyMF.Entities
{
    public class BaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
