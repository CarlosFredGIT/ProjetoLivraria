using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivraria.Domain.Entities;
using ProjetoLivraria.Repository.Repositories;
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
        public IActionResult Post(LivroPostRequest request,
            [FromServices] LivrosRepository livrosRepository) 
        {
            try
            {
                var livros = new Livros
                {
                    IdLivro = Guid.NewGuid(),
                    Isbn = request.Isbn,
                    Autor = request.Autor,
                    Nome = request.Nome,
                    Preco = request.Preco,
                    DataPublicacao = DateTime.Parse(request.DataPublicacao)
                };

                if (livrosRepository.ObterPorIsbn(livros.Isbn) != null)
                {
                    return StatusCode(403, new { Mensagem = $"Ops! O ISBN '{livros.Isbn}' já está cadastrado. =/" });
                }
                else
                {
                    livrosRepository.Inserir(livros);
                }
                
                var response = new LivroPostResponse
                {
                    IdLivro = livros.IdLivro,
                    Isbn = livros.Isbn,
                    Autor = livros.Autor,
                    Nome = livros.Nome,
                    Preco = livros.Preco,
                    DataPublicacao = livros.DataPublicacao
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(LivroPutRequest request,
            [FromServices] LivrosRepository livrosRepository) 
        {
            try
            {
                var livros = livrosRepository.ObterPorId(request.IdLivro);

                if (livros != null)
                {
                    livros.Isbn = request.Isbn;
                    livros.Autor = request.Autor;
                    livros.Nome = request.Nome;
                    livros.Preco = request.Preco;
                    livros.DataPublicacao = DateTime.Parse(request.DataPublicacao);

                    livrosRepository.Alterar(livros);

                    var response = new LivroPutResponse
                    {
                        IdLivro = livros.IdLivro,
                        Isbn = livros.Isbn,
                        Autor = livros.Autor,
                        Nome = livros.Nome,
                        Preco = livros.Preco,
                        DataPublicacao = livros.DataPublicacao
                    };

                    return Ok(response);
                }
                else
                {
                    return StatusCode(403, new { Mensagem = $"Ops! O ID não está cadastrado. =/" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id, 
            [FromServices] LivrosRepository livrosRepository) 
        {
            try
            {
                var livros = livrosRepository.ObterPorId(id);

                if (livros != null)
                {
                    livrosRepository.Excluir(livros);

                    var response = new LivroDeleteResponse
                    {
                        IdLivro = livros.IdLivro,
                        Isbn = livros.Isbn,
                        Autor = livros.Autor,
                        Nome = livros.Nome,
                        Preco = livros.Preco,
                        DataPublicacao = livros.DataPublicacao
                    };

                    return Ok(response);
                }
                else
                {
                    return StatusCode(403, new { Mensagem = $"Ops! O ID não está cadastrado. =/" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(
            [FromServices] LivrosRepository livrosRepository)
        {
            try
            {
                var lista = livrosRepository.ObterTodos();

                List<LivroGetResponse> result = new List<LivroGetResponse>();

                foreach (var item in lista)
                {
                    result.Add(new LivroGetResponse
                    {
                        IdLivro = item.IdLivro,
                        Isbn = item.Isbn,
                        Autor = item.Autor,
                        Nome = item.Nome,
                        Preco = item.Preco,
                        DataPublicacao = item.DataPublicacao
                    });
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("ById/{id}")]
        public IActionResult GetById(Guid id,
            [FromServices] LivrosRepository livrosRepository)
        {
            try
            {
                var livros = livrosRepository.ObterPorId(id);

                if (livros != null)
                {
                    var response = new LivroGetResponse
                    {
                        IdLivro = livros.IdLivro,
                        Isbn = livros.Isbn,
                        Autor = livros.Autor,
                        Nome = livros.Nome,
                        Preco = livros.Preco,
                        DataPublicacao = livros.DataPublicacao
                    };

                    return Ok(response);
                }

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("ByIsbn/{isbn}")]
        public IActionResult GetByIsbn(string isbn,
            [FromServices] LivrosRepository livrosRepository)
        {
            try
            {
                var livros = livrosRepository.ObterPorIsbn(isbn);

                if (livros != null)
                {
                    var response = new LivroGetResponse
                    {
                        IdLivro = livros.IdLivro,
                        Isbn = livros.Isbn,
                        Autor = livros.Autor,
                        Nome = livros.Nome,
                        Preco = livros.Preco,
                        DataPublicacao = livros.DataPublicacao
                    };

                    return Ok(response);
                }

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("ByAutor/{autor}")]
        public IActionResult GetByAutor(string autor,
            [FromServices] LivrosRepository livrosRepository)
        {
            try
            {
                var livros = livrosRepository.ObterPorAutor(autor);

                List<LivroGetResponse> result = new List<LivroGetResponse>();

                foreach (var item in livros)
                {
                    result.Add(new LivroGetResponse
                    {
                        IdLivro = item.IdLivro,
                        Isbn = item.Isbn,
                        Autor = item.Autor,
                        Nome = item.Nome,
                        Preco = item.Preco,
                        DataPublicacao = item.DataPublicacao
                    });
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("ByNome/{nome}")]
        public IActionResult GetByNome(string nome,
            [FromServices] LivrosRepository livrosRepository)
        {
            try
            {
                var livros = livrosRepository.ObterPorNome(nome);

                List<LivroGetResponse> result = new List<LivroGetResponse>();

                foreach (var item in livros)
                {
                    result.Add(new LivroGetResponse
                    {
                        IdLivro = item.IdLivro,
                        Isbn = item.Isbn,
                        Autor = item.Autor,
                        Nome = item.Nome,
                        Preco = item.Preco,
                        DataPublicacao = item.DataPublicacao
                    });
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("ByPreco/{precoMin}/{precoMax}")]
        public IActionResult GetByPreco(decimal precoMin, decimal precoMax,
            [FromServices] LivrosRepository livrosRepository)
        {
            try
            {
                var livros = livrosRepository.ObterPorPreco(precoMin, precoMax);

                List<LivroGetResponse> result = new List<LivroGetResponse>();

                foreach (var item in livros)
                {
                    result.Add(new LivroGetResponse
                    {
                        IdLivro = item.IdLivro,
                        Isbn = item.Isbn,
                        Autor = item.Autor,
                        Nome = item.Nome,
                        Preco = item.Preco,
                        DataPublicacao = item.DataPublicacao
                    });
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("ByData/{dataMin}/{dataMax}")]
        public IActionResult GetByData(DateTime dataMin, DateTime dataMax,
            [FromServices] LivrosRepository livrosRepository)
        {
            try
            {
                var livros = livrosRepository.ObterPorData(dataMin, dataMax);

                List<LivroGetResponse> result = new List<LivroGetResponse>();

                foreach (var item in livros)
                {
                    result.Add(new LivroGetResponse
                    {
                        IdLivro = item.IdLivro,
                        Isbn = item.Isbn,
                        Autor = item.Autor,
                        Nome = item.Nome,
                        Preco = item.Preco,
                        DataPublicacao = item.DataPublicacao
                    });
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
