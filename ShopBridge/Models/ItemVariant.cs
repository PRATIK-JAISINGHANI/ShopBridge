using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class ItemVariant : DocumentClass
    {
        public ItemVariant(Item item)
        {
            ItemId = item.Id;
        }

        public ItemVariant()
        {

        }

        public string Size { get; set; }

        [Required]
        public Guid ItemId { get; set; }

        public float Price { get; set; }
    }
}