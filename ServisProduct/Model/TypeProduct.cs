using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ServisProduct.Model
{
    [Table("ProductType")]
    public class TypeProduct
    {
        [Key]
        public int Id { get; set; }

        [Column("Name")]
        [MaxLength(255)]    
        public string Name { get; set; }
        [JsonIgnore]
        public List<Product> Product { get; set; }  
    }
}
