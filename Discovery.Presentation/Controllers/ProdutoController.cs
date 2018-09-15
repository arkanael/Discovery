using AutoMapper;
using Discovery.Entities;
using Discovery.Infra.Repository;
using Discovery.Presentation.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discovery.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/produto")]
    public class ProdutoController : Controller
    {
        [HttpPost("cadastrar")]
        [ProducesResponseType(200)] //OK
        [ProducesResponseType(400)] //Requisição Invalida
        [ProducesResponseType(500)] //Erro interno
        public IActionResult POST([FromBody]ProdutoCadastroViewModel model, [FromServices] ProdutoRepository repository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Produto produto = Mapper.Map<Produto>(model);
                    repository.Insert(produto);
                    return Ok(); //200
                }
                catch (Exception e)
                {

                    return StatusCode(500, e.Message); //500
                }
            }
            else
            {
                return BadRequest(); //400
            }
        }

        [HttpPut("atualizar")]
        [ProducesResponseType(200)] //OK
        [ProducesResponseType(400)] //Requisição Invalida
        [ProducesResponseType(500)] //Erro interno
        public IActionResult PUT([FromBody] ProdutoEdicaoViewModel model, [FromServices] ProdutoRepository repository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Produto produto = Mapper.Map<Produto>(model);
                    repository.Update(produto);
                    return Ok(); //200
                }
                catch (Exception e)
                {

                    return StatusCode(500, e.Message); //500
                }
            }
            else
            {
                return BadRequest(); //400
            }
        }

        [HttpGet("excluir/{id}")]
        [ProducesResponseType(200)] //OK
        [ProducesResponseType(404)] //Requisição Invalida
        [ProducesResponseType(500)] //Erro interno
        public IActionResult Delete(Guid id, [FromServices] ProdutoRepository repository)
        {
            try
            {
                Produto produto = repository.FindById(id);

                repository.Delete(id);
                return Ok(); //200
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message); //500
            }
        }

        [HttpGet("consultar")]
        [ProducesResponseType(200, Type = typeof(ProdutoConsultaViewModel))] //OK
        [ProducesResponseType(404)] //Requisição Invalida
        [ProducesResponseType(500)] //Erro interno
        public IActionResult GetAll([FromServices] ProdutoRepository repository)
        {
            try
            {
                var lista = new List<ProdutoConsultaViewModel>();

                foreach (var produto in repository.FindAll())
                    lista.Add(Mapper.Map<ProdutoConsultaViewModel>(produto));

                return Ok(); //200
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message); //500
            }
        }

        [HttpGet("consultar/{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProdutoConsultaViewModel>))] //OK
        [ProducesResponseType(404)] //Requisição Invalida
        [ProducesResponseType(500)] //Erro interno
        public IActionResult GetById(Guid id, [FromServices] ProdutoRepository repository)
        {
            try
            {
                Produto produto = repository.FindById(id);

                if (produto != null)
                {
                    return Ok(Mapper.Map<ProdutoConsultaViewModel>(produto));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message); //500
            }
        }
    }
}
