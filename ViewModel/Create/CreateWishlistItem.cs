﻿using Moqayda.API.Entities;
using Moqayda.API.Repository.Abstruct;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Threading;
using Moqayda.API.ViewModel.Get;
using Microsoft.Extensions.DependencyInjection;

namespace Moqayda.API.ViewModel.Create
{
    public class CreateWishlistItem : WishlistItemViewModel
    {
        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext,
        CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();
            var wishlistService = validationContext.GetService<IWishlistService>();

            if (await wishlistService.IsWishlistItemExistAsync(OwnerADObjectId, ProductId))
            {
                errors.Add(new ValidationResult($"Product id {ProductId} exist for owner {OwnerADObjectId}", new[] { nameof(ProductId) }));
            }

            return errors;

        }
    }
}
