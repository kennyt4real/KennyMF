using System;
using System.Collections.Generic;
using System.Text;

namespace KennyMF.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public long TeamId { get; set; }
    }
}
