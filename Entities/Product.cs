using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Moqayda.API.Entities
{
    public class Product
    {
        public Product()
        {
            WishlistItem = new HashSet<WishlistItem>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(3),MaxLength(250)]
        [Column(TypeName = "nvarchar(250)")]
        public string ProductName { get; set; }
        [Required]
        [MinLength(1),MaxLength(8000)]
        [Column(TypeName = "nvarchar(max)")]
        public string ProductDescription { get; set; }
        
        public DateTime AvailableSince { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(200)]
        public string CreatedBy { get; set; }
        public int NumberOfQuantity { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime ModifiedDate { get; set; }
        [MaxLength(200)]
        public string Modifiedby { get; set; }
        public short? CategoryId { get; set; }
        public int? ProductOwnerId { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        [DefaultValue("null")]
        public string PathImage { get; set; }
        public int? ProductBgColor { get; set; }
        [DefaultValue("false")]
        public bool IsWishlistItem { get; set; } 
        
        [Column(TypeName = "nvarchar(max)")]
        public string? ProductToSwap { get; set; }
        [DefaultValue("false")]
        public bool? Isfavourite { get; set; }

        public virtual Category Category { get; set; }
        public virtual ProductOwner ProductOwner { get; set; }
        public virtual ICollection<WishlistItem> WishlistItem { get; set; }
    }
}
