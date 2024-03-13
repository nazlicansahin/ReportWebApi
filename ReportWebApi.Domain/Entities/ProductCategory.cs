﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportWebApi.Domain.Entities
{
    public class ProductCategory
    {
       public Guid ProductId { get; set; }
       public Guid CategoryId { get; set; }
       public Product Product { get; set; }
       public Category Category { get; set; } 

    }
}
