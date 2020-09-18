using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI1.ViewModels
{
    public class ProductPostVM
    {
            public string productCode { get; set; }
            public string productName { get; set; }
            public string productLine { get; set; }
            public string productScale { get; set; }
            public string productVendor { get; set; }
            public string productDescription { get; set; }
            public Nullable<int> quantityInStock { get; set; }
            public double buyPrice { get; set; }
            public double MSRP { get; set; }
    }
}