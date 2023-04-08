﻿using Moqayda.API.Repository.Abstruct;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Linq;
using Moqayda.API.ViewModel.Get;
using Microsoft.Extensions.DependencyInjection;

namespace Moqayda.API.ViewModel.Create
{
    public class CreateCategory : CategoryViewModel
    {
        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext,
    CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();
            var categoryService = validationContext.GetService<ICategoryService>();

            if (await categoryService.IsCategoryExistAsync(Name))
            {
                errors.Add(new ValidationResult($"Category name {Name} exist", new[] { nameof(Name) }));
            }

            return errors;

        }
    }
}
