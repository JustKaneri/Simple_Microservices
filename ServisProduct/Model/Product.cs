using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        [JsonIgnore]
        public TypeProduct? Type { get; set; }

        [Column("Count")]
        public int Count { get; set; }
    }
}
