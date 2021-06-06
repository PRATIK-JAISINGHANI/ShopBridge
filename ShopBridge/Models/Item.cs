using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class Item : DocumentClass
    {

        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ManufacturerName { get; set; }

        public string SupplierName { get; set; }
    }
}