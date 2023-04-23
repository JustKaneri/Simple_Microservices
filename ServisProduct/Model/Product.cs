using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServisProduct.Model
{
    [Table("Product")]
    public class Product
    {

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        [MaxLength(255)]
        public string Name { get; set; }

        [ForeignKey("Id")]
        public int IdType { get; set; }

        public TypeProduct Type { get; set; }

        [Column("Count")]
        public int Count { get; set; }
    }
}
