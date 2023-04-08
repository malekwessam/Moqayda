using Moqayda.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moqayda.API.Repository.Abstruct
{
    public interface IWishlistRepository
    {
        Task<List<WishlistItem>> GetWishlistItemsAsync(string adObjName = "Admin");
        Task<WishlistItem> CreateWishlistItemAsync(WishlistItem wishlistItem);
        Task<bool> IsWishlistItemExistAsync(long wishlistItemId);
        Task<bool> DeleteWishlistItemAsync(long id);
        Task<bool> IsWishlistItemExistAsync(string ownerADObjectId, int productId);
        Task<WishlistItem> GetWishlistItemAsync(string adObjName, int productId);
        Task<List<WishlistItem>> GetWishlistProductsAsync(int noOfProduct);
        Task<WishlistItem> GetWishlistItemAsync(long id);
    }
}
