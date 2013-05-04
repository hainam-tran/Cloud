using System;
using System.Collections.Generic;

namespace Artnman.Commerce.Model
{
    public partial class ProductCategory
    {
        public List<object> Products { get; set; }

        public String Link { get; set; }

        public Int32 NumberOfChild { get; set; }

        public Int32 JQueryMenuIndex { get; set; }
    }
}
