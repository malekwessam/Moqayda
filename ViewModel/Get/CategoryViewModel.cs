using Moqayda.API.Validation;
using System.Collections.Generic;

namespace Moqayda.API.ViewModel.Get
{
    public class CategoryViewModel : AbstractValidatableObject
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public string pathImage { get; set; }

        public int CategoryBackgroundColor { get; set; }
        public List<CategoryProductViewModel> CategoryProductViewModels { get; set; }
    }
}
