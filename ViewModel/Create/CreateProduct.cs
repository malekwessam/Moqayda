using Moqayda.API.Repository.Abstruct;
using Moqayda.API.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Policy;
using Moqayda.API.ViewModel.Get;

namespace Moqayda.API.ViewModel.Create
{
    public class CreateProduct : AbstractValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        
        public string Descriptions { get; set; }
        public string pathImage { get; set; }

        public bool IsActive { get; set; } = true;
        public short CategoryId { get; set; }
        public int ProductBackgroundColor { get; set; }
        public bool IsFavourite { get; set; } = false;
        public string ProductToSwap { get; set; }







        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext,
      CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();
            var categoryService = validationContext.GetService<ICategoryService>();
            var productService = validationContext.GetService<IProductService>();

            var category = await categoryService.GetCategoryAsync(CategoryId);
            var isProductNameExist = await productService.IsProductNameExistAsync(Name);
            if (isProductNameExist)
            {
                errors.Add(new
                   ValidationResult($"Product with name {Name} exist, provide a different name", new[] { nameof(Name) }));
            }
            if (category == null)
            {
                errors.Add(new ValidationResult($"Category id {CategoryId} doesn't exist", new[] { nameof(CategoryId) }));
            }

            return errors;
        }
    }
}
