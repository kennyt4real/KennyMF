using System;
using System.Collections.Generic;
using System.Text;

namespace KennyMF.Entities
{
    public class Form : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string FormJson { get; set; }
        public long TeamId { get; set; }
        public string FormMessage { get; set; }
    }
}
