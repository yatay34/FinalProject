﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }

    }
}
