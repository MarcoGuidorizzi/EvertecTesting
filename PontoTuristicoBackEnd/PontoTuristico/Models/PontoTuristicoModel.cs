using System.ComponentModel.DataAnnotations;

namespace PontoTuristicoApp.Models
{
    public class PontoTuristicoModel
    {
        //usei a [key] para já identificar que o Id é a chave primária da minha tabela, ou seja,
        //é o campo que vai identificar unicamente cada registro da minha tabela.
        //O [required] para garantir que os campos sejam preenchidos, ou seja, que não sejam nulos.
        //O [maxLength] para limitar a quantidade de caracteres que podem ser inseridos na descrição,
        //para evitar que o usuário insira uma descrição maior que 100 caracteres, como foi solicitado na descrição do próprio teste.
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
