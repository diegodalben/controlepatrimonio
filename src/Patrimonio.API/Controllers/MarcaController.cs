using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Patrimonio.Business.Entities;
using Patrimonio.Business.Services.Abstractions;

namespace Patrimonio.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;
        private readonly IPatrimonioService _patrimonioService;

        public MarcaController
        (
            IMarcaService marcaService,
            IPatrimonioService patrimonioService
        )
        {
            _marcaService = marcaService ?? throw new ArgumentNullException(nameof(marcaService));
            _patrimonioService = patrimonioService ?? throw new ArgumentNullException(nameof(patrimonioService));
        }

        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.Created)]
        public IActionResult Create([FromBody] EMarca entity)
        {
            if(entity == null) entity = new EMarca();
            var response = _marcaService.Create(entity);

            if(!response.Ok) return BadRequest(new {Message = response.Message});

            return CreatedAtRoute("GetMarcaById", new{Id = entity.MarcaId}, entity);
        }

        [Route("{id}")]
        [HttpPut]
        [ProducesResponseType((int) HttpStatusCode.Accepted)]
        public IActionResult Update([FromRoute] int id, [FromBody] EMarca entity)
        {
            if(entity == null) entity = new EMarca();
            entity.MarcaId = id;
            var response = _marcaService.Update(entity);

            if(!response.Ok) return BadRequest(new {Message = response.Message});
            if(response.ObjectResponse == 0) return NotFound();

            return Accepted();
        }

        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public IActionResult Delete([FromRoute] int id)
        {
            var response = _marcaService.Delete(id);
            
            if(response.ObjectResponse == 0) return NotFound();

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            var response = _marcaService.GetAll();

            return Ok(response.ObjectResponse);
        }

        [Route("{id}", Name="GetMarcaById")]
        [HttpGet]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = _marcaService.GetById(id);

            if(response.ObjectResponse == null) return NotFound();

            return Ok(response.ObjectResponse);
        }

        [Route("{id}/patrimonios")]
        [HttpGet]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public IActionResult GetPatrimonios(int id)
        {
            var response = _patrimonioService.GetByMarca(id);

            return Ok(response.ObjectResponse);
        }
    }
}