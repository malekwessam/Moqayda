using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Moqayda.API.Entities;
using Moqayda.API.Repository.Abstruct;
using Moqayda.API.Repository.Implement;
using Moqayda.API.ViewModel.Create;
using Moqayda.API.ViewModel.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Moqayda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        //    private readonly IWishlistService wishlistService;
        //    public WishlistController(IWishlistService wishlistService)
        //    {
        //        this.wishlistService = wishlistService;
        //    }
        //    [HttpGet("all", Name = "GetWishlists")]
        //    [ProducesResponseType(typeof(List<WishlistItemViewModel>), StatusCodes.Status200OK)]
        //    public async Task<IActionResult> GetWishlistItemsAsync()
        //    {
        //        var adObjName = "Admin";


        //        var wishlists = await wishlistService.GetWishlistItemsAsync(adObjName);

        //        var wishlistsViewModel = wishlists.Select(s => new WishlistItemViewModel()
        //        {
        //            OwnerADObjectId = s.OwnerAdobjectId,
        //            ProductId = Convert.ToInt32(s.ProductId),
        //            Id = s.Id
        //        }).ToList();

        //        return Ok(wishlistsViewModel);
        //    }

        //    [HttpPost("", Name = "CreateWishlist")]
        //    //[ProducesResponseType(StatusCodes.Status201Created)]
        //    //[ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        //    public async Task<IActionResult> PostWishlistAsync([FromBody] CreateWishlistItem createWishlistItem)
        //    {

        //        var wishListInDB = await wishlistService.GetWishlistItemAsync("Admin",
        //            createWishlistItem.ProductId);

        //        if (wishListInDB == null)
        //        {
        //            var entity = new WishlistItem()
        //            {
        //                OwnerAdobjectId = "Admin",
        //                ProductId = createWishlistItem.ProductId
        //            };

        //            var isSuccess = await wishlistService.CreateWishlistItemAsync(entity);
        //            return new CreatedAtRouteResult("GetWishlist",
        //              new { id = entity.Id });
        //        }
        //        return new CreatedAtRouteResult("GetWishlist",
        //               new { id = wishListInDB.Id });
        //    }
        //    //[HttpDelete("{id}", Name = "DeleteWishlist")]
        //    //// [ProducesResponseType(StatusCodes.Status200OK)]
        //    //// [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        //    //public async Task<IActionResult> DeleteWishlistAsync([FromRoute] long id)
        //    //{

        //    //    //  Logger.LogInformation($"Executing {nameof(DeleteWishlistAsync)}");

        //    //    var exist = await wishlistService.IsWishlistItemExistAsync(id);

        //    //    if (!exist)
        //    //        return NotFound();

        //    //    await wishlistService.DeleteWishlistItemAsync(id);

        //    //    return Ok();
        //    //}
        //}

        private readonly IWishlistService wishlistService;
        public WishlistController(IWishlistService wishlistService)
        {
            this.wishlistService = wishlistService;
        }
        [HttpGet("all", Name = "GetWishlists")]
        [ProducesResponseType(typeof(List<WishlistItemViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWishlistProductsAsync()
        {
            var adObjName = "Admin";


            var wishlists = await wishlistService.GetWishlistItemsAsync(adObjName);

            var wishlistsViewModel = wishlists.Select(s => new WishlistItemViewModel()
            {
                OwnerADObjectId = s.OwnerAdobjectId,
                ProductId = Convert.ToInt32(s.ProductId),
                Id = s.Id,
                //ProductWishlistViewModels = s.Product.Any() ? s.Product.Select
                // (s => new ProductWishlistViewModel()
                // {

                //     Id = s.Id,
                //     Name = s.ProductName,
                //     Descriptions = s.ProductDescription,
                //     pathImage = "http://www.moqayda.somee.com/" + s.PathImage,
                //     AvailableSince = s.AvailableSince,
                //     IsActive = s.IsActive



                // }).ToList() : new List<ProductWishlistViewModel>()
            }).ToList();

            return Ok(wishlistsViewModel);
        }
        [HttpPost("", Name = "CreateWishlist")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostWishlistAsync([FromBody] CreateWishlistItem createWishlistItem)
        {

            var wishListInDB = await wishlistService.GetWishlistItemAsync("Admin",
                createWishlistItem.ProductId);

            if (wishListInDB == null)
            {
                var entity = new WishlistItem()
                {
                    OwnerAdobjectId = "Admin",
                    ProductId = createWishlistItem.ProductId
                };

                var isSuccess = await wishlistService.CreateWishlistItemAsync(entity);
                return new CreatedAtRouteResult("GetWishlist",
                  new { id = entity.Id });
            }
            return new CreatedAtRouteResult("GetWishlist",
                   new { id = wishListInDB.Id });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(long id)
        {
            var product = await wishlistService.GetWishlistItemAsync(id);
            if (product == null)
                return NotFound();

            // System.IO.File.Delete(product.PathImage);
            var isSuccess = await wishlistService.DeleteWishlistItemAsync(id);
            return Ok();
        }
    }


}
