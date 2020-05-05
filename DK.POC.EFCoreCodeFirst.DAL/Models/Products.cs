using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DK.POC.EFCoreCodeFirst.DAL.Models
{
    [Table("TProducts")]
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        //Navigation properties
        public Categories Categories { get; set; }
    }
}
