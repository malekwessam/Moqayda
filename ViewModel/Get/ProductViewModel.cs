using System.ComponentModel.DataAnnotations;
using System;
using Moqayda.API.Validation;

namespace Moqayda.API.ViewModel.Get
{
    public class ProductViewModel : AbstractValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        
        public string Descriptions { get; set; }
        public string pathImage { get; set; }
        public DateTime AvailableSince { get; set; }
        public bool IsActive { get; set; } = true;
        public short CategoryId { get; set; }
        public int ProductBackgroundColor { get; set; }
        public bool IsFavourite { get; set; } = false;
        public string ProductToSwap { get; set; }
    }
}
