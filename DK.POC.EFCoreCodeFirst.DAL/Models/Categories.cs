using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DK.POC.EFCoreCodeFirst.DAL.Models
{
    [Table("TCategories")]
    public class Categories
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Notes { get; set; }

        public IEnumerable<Products> Products { get; set; }
    }
}
