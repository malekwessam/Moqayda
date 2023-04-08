using Moqayda.API.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Moqayda.API.ViewModel.Get
{
    public class WishlistItemViewModel : AbstractValidatableObject
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
         [MaxLength(200)]
         public string OwnerADObjectId { get; set; } = "Admin";
        //public List<ProductWishlistViewModel> ProductWishlistViewModels { get; set; }
    }
}
