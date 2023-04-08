using System;

namespace Moqayda.API.ViewModel.Get
{
    public class CategoryProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Descriptions { get; set; }
        public string pathImage { get; set; }
       
        public DateTime AvailableSince { get; set; }
        public bool IsActive { get; set; }
        public short CategoryId { get; set; }
        public bool IsFavourite { get; set; } = false;
        public string ProductToSwap { get; set; }
    }
    
}
