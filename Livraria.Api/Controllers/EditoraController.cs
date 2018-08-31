﻿using System;
using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces;
using Livraria.Service.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Editora")]
    [ApiController]
    public class EditoraController : ControllerBase
    {
        private readonly IServiceBase<Editora> _editoraService;

        public EditoraController(IServiceBase<Editora> editoraService)
        {
            _editoraService = editoraService;
        }

        [HttpPost]
        [Route("inserir")]
        public IActionResult Post([FromBody] Editora editora)
        {
            try
            {
                _editoraService.Post<EditoraValidator>(editora);
                return new ObjectResult(editora.Id);
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
        public IActionResult Put([FromBody] Editora editora)
        {
            try
            {
                _editoraService.Put<EditoraValidator>(editora);
                return new ObjectResult(editora);
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
                _editoraService.Delete(id);
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
                return new ObjectResult(_editoraService.GetAll());
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
                return new ObjectResult(_editoraService.GetById(id));
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