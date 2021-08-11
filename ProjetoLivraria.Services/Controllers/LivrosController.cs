using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Post() //Inserir
        {
            return Ok(); // Provisório
        }

        [HttpPut]
        public IActionResult Put() //Alterar
        {
            return Ok(); // Provisório
        }

        [HttpDelete]
        public IActionResult Delete() //Deletar
        {
            return Ok(); // Provisório
        }

        [HttpGet]
        public IActionResult Get() //Consultar
        {
            return Ok(); // Provisório
        }  
    }
}
