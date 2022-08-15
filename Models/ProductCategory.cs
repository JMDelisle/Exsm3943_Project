using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClassroomStart.Models
{
    [Table("product category")]
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        [Column("ID", TypeName = "int(11)")]
        public int Id { get; set; }
        [StringLength(20)]
        public string Paint { get; set; } = null!;
        [StringLength(10)]
        public string Sandpaper { get; set; } = null!;
        [StringLength(10)]
        public string Fillers { get; set; } = null!;
        [Column("PPE")]
        [StringLength(25)]
        public string Ppe { get; set; } = null!;
        [Column("Shop Supplies")]
        [StringLength(25)]
        public string ShopSupplies { get; set; } = null!;

        [InverseProperty("ProductCategory")]
        public virtual ICollection<Product> Products { get; set; }
        [InverseProperty("ProductCategory")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
