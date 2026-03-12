using System.ComponentModel.DataAnnotations;

namespace PontoTuristicoApp.Models
{
    public class PontoTuristicoModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é um campo obrigatório.")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "A localização é um campo obrigatório. Aqui deverá ter endereço ou uma referência de localização")]
        public string? Localizacao { get; set; }
        [Required(ErrorMessage = "A cidade é um campo obrigatório.")]
        public string? Cidade { get; set; }
        [Required(ErrorMessage = "O estado é um campo obrigatório.")]
        public string? Estado { get; set; }
        [Required(ErrorMessage = "A descrição é um campo obrigatório.")]
        [MaxLength(100, ErrorMessage = "A descrição não pode exceder 100 caracteres.")]
        public string? Descricao { get; set; }

    }
}
