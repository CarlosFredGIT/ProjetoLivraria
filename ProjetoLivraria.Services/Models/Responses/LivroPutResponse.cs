using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLivraria.Services.Models.Responses
{
    public class LivroPutResponse
    {
        public Guid IdLivro { get; set; }
        public string Isbn { get; set; }
        public string Autor { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}
