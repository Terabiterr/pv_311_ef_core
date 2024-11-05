using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lesson_1_app.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string? Name { get; set; }
        [Required]
        [Range(typeof(decimal), "0.0", "100000.00")]
        public decimal Price { get; set; }
    }
}
