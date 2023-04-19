using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServisUser.Model
{
    [Table("User")]
    public class User
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Column("Age")]
        public int Age { get; set; }

        [Column("DateRegestry")]
        public DateTime Regestry { get; set; } = DateTime.Now;
    }
}
