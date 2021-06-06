using ShopBridge.DataContracts;
using ShopBridge.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopBridge.Controllers
{

    public class ItemController : ApiController
    {
        [HttpGet, Route("api/Items")]
        public async Task<HttpResponseMessage> GetItems(int start = 0)
        {
            try
            {
                return ResponseGenerator.GetSuccessResponse(ItemsHelper.GetItemsInternal(start));
            }
            catch (Exception ex)
            {
                return ResponseGenerator.GetFailureResponse(ex.Message, ex.StackTrace);
            }
        }

        [HttpPost, Route("api/Items/Add")]
        public async Task<HttpResponseMessage> AddItem(ItemRequest request)
        {
            try
            {
                return ResponseGenerator.GetSuccessResponse(ItemsHelper.AddItem(request));
            }
            catch (Exception ex)
            {
                return ResponseGenerator.GetFailureResponse(ex.Message, ex.StackTrace);
            }
        }

        [HttpPost, Route("api/Items/{itemId}/Variants")]
        public async Task<HttpResponseMessage> AddItemVariant(string itemId, ItemVariantRequest request)
        {
            try
            {
                var response = await ItemsHelper.AddItemVariant(Guid.Parse(itemId), request);
                return ResponseGenerator.GetSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ResponseGenerator.GetFailureResponse(ex.Message, ex.StackTrace);
            }
        }

        [HttpPut, Route("api/Items/{itemId}")]
        public async Task<HttpResponseMessage> UpdateItem(string itemId, ItemRequest request)
        {
            try
            {
                var response = await ItemsHelper.UpdateItem(Guid.Parse(itemId), request);
                return ResponseGenerator.GetSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ResponseGenerator.GetFailureResponse(ex.Message, ex.StackTrace);
            }
        }

        [HttpPut, Route("api/Items/Variants/{itemVariantId}")]
        public async Task<HttpResponseMessage> UpdateItemVariant(string itemVariantId, ItemVariantRequest request)
        {
            try
            {
                var response = await ItemsHelper.UpdateItemVariant(Guid.Parse(itemVariantId), request);
                return ResponseGenerator.GetSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ResponseGenerator.GetFailureResponse(ex.Message, ex.StackTrace);
            }
        }

        [HttpDelete, Route("api/Items/{itemId}")]
        public async Task<HttpResponseMessage> DeleteItem(string itemId)
        {
            try
            {
                var response = await ItemsHelper.DeleteItems(Guid.Parse(itemId));
                return ResponseGenerator.GetSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ResponseGenerator.GetFailureResponse(ex.Message, ex.StackTrace);
            }
        }

        [HttpDelete, Route("api/Items/Variant/{itemVariantId}")]
        public async Task<HttpResponseMessage> DeleteItemVariant(string itemVariantId)
        {
            try
            {
                var response = await ItemsHelper.DeleteItemVariant(Guid.Parse(itemVariantId));
                return ResponseGenerator.GetSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ResponseGenerator.GetFailureResponse(ex.Message, ex.StackTrace);
            }
        }
    }
}
