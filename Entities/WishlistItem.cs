using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moqayda.API.Entities
{
    public class WishlistItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int? ProductId { get; set; }
        [MaxLength(200)]
        public string OwnerAdobjectId { get; set; }

        public virtual Product Product { get; set; }
    }
}
