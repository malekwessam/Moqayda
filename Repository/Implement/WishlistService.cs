using Moqayda.API.Entities;
using Moqayda.API.Repository.Abstruct;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moqayda.API.Repository.Implement
{
    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository wishlistRepository;

        public WishlistService(IWishlistRepository wishlistRepository)
        {
            this.wishlistRepository = wishlistRepository;
        }
        public Task<WishlistItem> CreateWishlistItemAsync(WishlistItem wishlistItem)
        {
            return wishlistRepository.CreateWishlistItemAsync(wishlistItem);
        }

        public Task<bool> DeleteWishlistItemAsync(long id)
        {
            return wishlistRepository.DeleteWishlistItemAsync(id);
        }

        public Task<WishlistItem> GetWishlistItemAsync(string adObjName, int productId)
        {
            return wishlistRepository.GetWishlistItemAsync(adObjName, productId);
        }

        public Task<List<WishlistItem>> GetWishlistItemsAsync(string adName)
        {
            return wishlistRepository.GetWishlistItemsAsync(adName);
        }

        public Task<List<WishlistItem>> GetWishlistProductsAsync(int noOfProducts = 100)
        {
            return wishlistRepository.GetWishlistProductsAsync(noOfProducts);
        }


        public Task<bool> IsWishlistItemExistAsync(long wishlistItemId)
        {
            return wishlistRepository.IsWishlistItemExistAsync(wishlistItemId);
        }

        public Task<bool> IsWishlistItemExistAsync(string ownerADObjectId, int productId)
        {
            return wishlistRepository.IsWishlistItemExistAsync(ownerADObjectId, productId);
        }
        public Task<WishlistItem> GetWishlistItemAsync(long id)
        {
            return wishlistRepository.GetWishlistItemAsync(id);
        }
    }
}
