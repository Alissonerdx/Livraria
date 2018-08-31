using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces;
using Livraria.Service.Services;
using Livraria.Service.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Livro")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly IServiceBase<Livro> _livroService;

        public LivroController(IServiceBase<Livro> livroService)
        {
            _livroService = livroService;
        }

        [HttpPost]
        [Route("inserir")]
        public IActionResult Post([FromBody] Livro livro)
        {
            try
            {
                _livroService.Post<LivroValidator>(livro);
                return new ObjectResult(livro.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("alterar")]
        public IActionResult Put([FromBody] Livro livro)
        {
            try
            {
                _livroService.Put<LivroValidator>(livro);
                return new ObjectResult(livro);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("remover/{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _livroService.Delete(id);
                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult GetAll()
        {
            try
            {
                return new ObjectResult(_livroService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("obter/{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return new ObjectResult(_livroService.GetById(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}