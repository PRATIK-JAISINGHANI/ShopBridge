using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.DataContracts
{
    public class ItemVariantRequest
    {
        public string Size { get; set; }

        public float Price { get; set; }
    }
}