using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServisOrder.Model
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("UserId")]
        [Required]
        public int UserId { get; set; }

        [Column("ProductId")]
        [Required]
        public int ProductId { get; set; }

        [Column("CreateOrder")]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
