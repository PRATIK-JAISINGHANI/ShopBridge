using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.DataContracts
{
    public class ItemVariantResponse
    {
        public Guid GeneratedId { get; set; }

        public Item ParentItem { get; set; }

        public ItemVariant ItemVariant { get; set; }


    }
}