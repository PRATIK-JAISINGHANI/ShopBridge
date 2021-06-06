using ShopBridge.DataContracts;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ShopBridge.Helper
{
    public class ItemsHelper
    {
        public async static Task<IEnumerable<Item>> GetItemsInternal(int startCount)
        {
            return ApplicationContext.Instance().Items.OrderBy(i => i.Name).Skip(startCount).Take(10);
        }

        public async static Task<ItemResponse> AddItem(ItemRequest request)
        {
            var context = ApplicationContext.Instance();
            if (context.Items.Where(i => i.Name == request.Name).Count() > 0)
                throw new Exception("Item already exists");

            var newItem = new Item() { CategoryId = request.CategoryId, Name = request.Name, Description = request.Description, ManufacturerName = request.ManufacturerName, SupplierName = request.SupplierName };
            ApplicationContext.Instance().Items.Add(newItem);
            if (ApplicationContext.Instance().SaveChanges() > 0)
            {
                return new ItemResponse() { GeneratedId = newItem.Id, Item = newItem };
            }
            throw new Exception("Something went wrong while creating an Item");
        }

        public async static Task<object> UpdateItem(Guid itemId, ItemRequest request)
        {
            var context = ApplicationContext.Instance();
            var existingItem = context.Items.Where(i => i.Id == itemId).FirstOrDefault();
            if (existingItem == null)
                throw new Exception("Item not found for provided id");

            existingItem.Name = request.Name;
            existingItem.Description = request.Description;
            existingItem.SupplierName = request.SupplierName;
            existingItem.ManufacturerName = request.ManufacturerName;
            existingItem.CategoryId = request.CategoryId;
            if (context.SaveChanges() > 0)
                return new { Message = "Item is updated" };

            throw new Exception("Something went wrong while creating an Item");
        }

        public async static Task<object> UpdateItemVariant(Guid itemVariantId, ItemVariantRequest request)
        {
            var context = ApplicationContext.Instance();
            var existingItem = context.ItemVariants.Where(i => i.Id == itemVariantId).FirstOrDefault();
            if (existingItem == null)
                throw new Exception("Item not found for provided id");

            existingItem.Size = request.Size;
            existingItem.Price = request.Price;
            if (context.SaveChanges() > 0)
                return new { Message = "Item Variant is updated" };

            throw new Exception("Something went wrong while creating an Item");
        }

        public async static Task<ItemVariantResponse> AddItemVariant(Guid itemId, ItemVariantRequest request)
        {
            var existingItem = ApplicationContext.Instance().Items.Where(i => i.Id == itemId).FirstOrDefault();
            if (existingItem == null)
                throw new Exception("Item not found with provided ItemId");

            if (ApplicationContext.Instance().ItemVariants.Where(iv => iv.Size == request.Size && iv.ItemId == itemId).Count() > 0)
                throw new Exception("Item Variant already exists");

            var newItemVariant = new ItemVariant(existingItem) { Size = request.Size, Price = request.Price };
            ApplicationContext.Instance().ItemVariants.Add(newItemVariant);
            if (ApplicationContext.Instance().SaveChanges() > 0)
            {
                return new ItemVariantResponse() { GeneratedId = newItemVariant.Id, ParentItem = existingItem, ItemVariant = newItemVariant };
            }
            throw new Exception("Something went wrong while creating an Item");
        }

        public async static Task<object> DeleteItems(Guid itemId)
        {
            var context = ApplicationContext.Instance();
            var existingItemVariants = context.ItemVariants.Where(iv => iv.ItemId == itemId);
            foreach (var itemVariant in existingItemVariants)
                context.ItemVariants.Remove(itemVariant);
            var existingItem = ApplicationContext.Instance().Items.Where(iv => iv.Id == itemId).FirstOrDefault();
            ApplicationContext.Instance().Items.Remove(existingItem);
            if (ApplicationContext.Instance().SaveChanges() > 0)
                return new { Message = "Items & Related ItemVariants are Deleted" };
            throw new Exception("Something went wrong while deleting items & variants");
        }

        public async static Task<object> DeleteItemVariant(Guid itemVariantId)
        {
            var context = ApplicationContext.Instance();
            var existingItemVariants = context.ItemVariants.Where(iv => iv.Id == itemVariantId);
            foreach (var itemVariant in existingItemVariants)
                context.ItemVariants.Remove(itemVariant);
            if (ApplicationContext.Instance().SaveChanges() > 0)
                return new { Message = "Item Variant is Deleted" };
            throw new Exception("Something went wrong while deleting items & variants");
        }
    }
}