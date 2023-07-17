using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TestePloomes.Domain.DTOS {
    public class ClientesDTO {

        [SwaggerSchema(Description = "Id do cliente")]
        public int Id { get; set; }
        [SwaggerSchema(Description = "Nome do cliente")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100)]
        public string Nome { get; set; }
        [SwaggerSchema(Description = "Cpf do cliente sem pontuação")]
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(11)]
        public string Cpf { get; set; }
        [SwaggerSchema(Description = "Endereço do cliente")]
        [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
        [StringLength(200)]
        public string Endereco { get; set; }
        [SwaggerSchema(Description = "Email do cliente")]
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [StringLength(100)]
        public string Email { get; set; }
        [SwaggerSchema(Description = "Limite de crédito do cliente")]
        [Required(ErrorMessage = "O campo LimiteCredito é obrigatório.")]
        public decimal LimiteCredito { get; set; }
    }
}
