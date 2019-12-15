﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KennyMF.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
