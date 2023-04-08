using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moqayda.API.Entities
{
    public class ProductOwner
    {
        public ProductOwner()
        {
            Product = new HashSet<Product>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(200)]
        public string OwnerAdobjectId { get; set; }
        [MaxLength(1000)]
        public string OwnerName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
