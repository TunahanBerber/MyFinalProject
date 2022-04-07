using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        public string CustomerId { get; set; } //Northwind'de CustomerId String olarak tutulduğu için string verdik
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }

    }
}
