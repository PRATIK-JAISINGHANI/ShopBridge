using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class Category : DocumentClass
    {
        public Guid? ParentCategoryId { get; set; }

        public string Name { get; set; }

    }
}