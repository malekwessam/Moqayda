using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moqayda.API.Entities
{
    public class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }
        [Required]
        [MinLength(4),MaxLength(100)]
        [Column(TypeName ="nvarchar(250)")]
        public string CategoryName { get; set; }
        
        public bool IsAcTive { get; set; } = true;
        [Column(TypeName = "nvarchar(max)")]
        public string PathImage { get; set; }
        
        public int? CategoryBgColor { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
