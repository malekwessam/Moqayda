using Microsoft.EntityFrameworkCore;
using Moqayda.API.Data;
using Moqayda.API.Entities;
using Moqayda.API.Repository.Abstruct;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moqayda.API.Repository.Implement
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly MoqaydaDbContext DbContext;
        public WishlistRepository(MoqaydaDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public async Task<WishlistItem> CreateWishlistItemAsync(WishlistItem wishlistItem)
        {
            DbContext.WishlistItem.Add(wishlistItem);
            await DbContext.SaveChangesAsync();
            return wishlistItem;
        }

        public async Task<bool> DeleteWishlistItemAsync(long id)
        {
            var entityToDelete = await DbContext.WishlistItem.FindAsync(id);
            DbContext.WishlistItem.Remove(entityToDelete);
            return await DbContext.SaveChangesAsync() > 0;
        }

        public Task<WishlistItem> GetWishlistItemAsync(string adObjName, int productId)
        {
            return DbContext.WishlistItem.FirstOrDefaultAsync(f => f.ProductId == productId
            && f.OwnerAdobjectId == adObjName);
        }

        public Task<List<WishlistItem>> GetWishlistItemsAsync(string adObjName = "Admin")
        {
            return DbContext.WishlistItem.Where(w => w.OwnerAdobjectId == adObjName).ToListAsync();
        }

       

        public async Task<bool> IsWishlistItemExistAsync(long wishlistItemId)
        {
            var entity = await DbContext.WishlistItem.FindAsync(wishlistItemId);
            return entity != null;
        }

        public async Task<bool> IsWishlistItemExistAsync(string ownerADObjectId, int productId)
        {
            var wishlistItem = await DbContext.WishlistItem.FirstOrDefaultAsync(f => f.ProductId == productId && f.OwnerAdobjectId == ownerADObjectId);
            return wishlistItem != null;
        }
        public Task<List<WishlistItem>> GetWishlistProductsAsync(int noOfProducts)
        {
            var products = DbContext.WishlistItem.AsNoTracking()
                .Include(i => i.Product)
                
                 .Take(noOfProducts).ToListAsync(); //this will order the data and then take only specific count and returns
            return products;
        }
        public Task<WishlistItem> GetWishlistItemAsync(long id)
        {
            return this.DbContext.WishlistItem.FindAsync(id).AsTask();
        }
    }
}
