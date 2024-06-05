using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace graphs_ms.Models
{
    public class Building
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Surface { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public DateTime? SaleDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? SalePrice { get; set; }

        [Required]
        public int IdCity { get; set; }

        [ForeignKey("IdCity")]
        public City City { get; set; }
    }
}