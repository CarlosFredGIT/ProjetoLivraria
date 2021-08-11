using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivraria.Services.Models.Requests;
using ProjetoLivraria.Services.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLivraria.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(LivroPostRequest request) //Inserir
        {
            //criar gravação em banco

            var response = new LivroPostResponse
            {
                IdLivro = Guid.NewGuid(),
                Isbn = request.Isbn,
                Autor = request.Autor,
                Nome = request.Nome,
                Preco = request.Preco,
                DataPublicacao = DateTime.Parse(request.DataPublicacao)
            };
            return Ok(response); 
        }

        [HttpPut]
        public IActionResult Put(LivroPutRequest request) //Alterar
        {
            //criar gravação em banco

            var response = new LivroPutResponse
            {
                IdLivro = Guid.Parse(request.IdLivro),
                Isbn = request.Isbn,
                Autor = request.Autor,
                Nome = request.Nome,
                Preco = request.Preco,
                DataPublicacao = DateTime.Parse(request.DataPublicacao)
            };
            
            return Ok(response); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) //Deletar
        {
            //criar gravação em banco

            var response = new LivroDeleteResponse
            {
                IdLivro = id,
                Isbn = "1234567891234",
                Autor = "Anielle Franco",
                Nome = "Sexo Selvagem",
                Preco = 100,
                DataPublicacao = new DateTime(2021, 08, 11)
            };

            return Ok(response);
        }

        [HttpGet]
        public IActionResult Get() //Consultar
        {
            //criar consulta no banco

            var response = new List<LivroGetResponse>();


            response.Add(new LivroGetResponse
            {
                IdLivro = Guid.NewGuid(),
                Isbn = "1234567891234",
                Autor = "Anielle Franco",
                Nome = "Sexo Selvagem",
                Preco = 100,
                DataPublicacao = new DateTime(2021, 08, 11)
            });

            response.Add(new LivroGetResponse
            {
                IdLivro = Guid.NewGuid(),
                Isbn = "1111111111111",
                Autor = "Carlos Frederico",
                Nome = "Pentada Violenta",
                Preco = 200,
                DataPublicacao = new DateTime(2021, 08, 10)
            });

            return Ok(response);
        }  
    }
}
