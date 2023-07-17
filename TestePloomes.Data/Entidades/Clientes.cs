using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestePloomes.Data.Entidades {

    public partial class Clientes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("Nome")]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [Column("CPF")]
        [StringLength(11)]
        public string Cpf { get; set; }
        [Required]
        [Column("Endereco")]
        [StringLength(200)]
        public string Endereco { get; set; }
        [Required]
        [Column("Email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal LimiteCredito { get; set; }
    }
}