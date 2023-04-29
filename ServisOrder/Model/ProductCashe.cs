using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServisOrder.Model
{
    [Table("ProductCashe")]
    public class ProductCashe
    {
        [Key]
        public int Id { get; set;}

        [Column("IdProduct")]
        public int IdProduct { get; set; }
    }
}
