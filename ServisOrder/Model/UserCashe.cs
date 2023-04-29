using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServisOrder.Model
{
    [Table("UserCashe")]
    public class UserCashe
    {
        [Key]
        public int Id { get; set; }

        [Column("IdUser")]
        public int IdUser { get; set; }
    }
}
