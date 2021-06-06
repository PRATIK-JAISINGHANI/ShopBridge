using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.DataContracts
{
    public class ItemResponse
    {
        public Guid GeneratedId { get; set; }

        public Item Item { get; set; }
    }
}