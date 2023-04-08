using Moqayda.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moqayda.API.Repository.Abstruct
{
    public interface IWishlistService
    {
        Task<List<WishlistItem>> GetWishlistItemsAsync(string adName);
        Task<WishlistItem> CreateWishlistItemAsync(WishlistItem wishlistItem);
        Task<bool> IsWishlistItemExistAsync(long wishlistItemId);
        Task<bool> IsWishlistItemExistAsync(string ownerADObjectId, int productId);
        Task<bool> DeleteWishlistItemAsync(long id);
        Task<WishlistItem> GetWishlistItemAsync(string adObjName, int productId);
        Task<List<WishlistItem>> GetWishlistProductsAsync(int noOfProducts = 100);
        Task<WishlistItem> GetWishlistItemAsync(long id);
    }
}