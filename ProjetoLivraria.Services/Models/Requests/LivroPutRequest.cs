using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjetoLivraria.Services.Models.Requests
{
    public class LivroPutRequest
    {
        [Required(ErrorMessage = "Por favor, informe o ID do livro.")]
        public Guid IdLivro { get; set; }

        [RegularExpression("^[0-9]{13}$", ErrorMessage = "Por favor, informe 13 dígitos numéricos.")]
        [Required(ErrorMessage = "Por favor, informe o ISBN do livro.")]
        public string Isbn { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do autor do livro.")]
        public string Autor { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do livro.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o preço do livro.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data da publicação do livro.")]
        public string DataPublicacao { get; set; }
    }
}
