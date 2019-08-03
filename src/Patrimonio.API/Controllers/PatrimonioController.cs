using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Patrimonio.Business.Entities;
using Patrimonio.Business.Services.Abstractions;

namespace Patrimonio.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class PatrimonioController : ControllerBase
    {
        private readonly IPatrimonioService _service;

        public PatrimonioController(IPatrimonioService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.Created)]
        public IActionResult Create([FromBody] EPatrimonio entity)
        {
            var response = _service.Create(entity);

            if(!response.Ok) return BadRequest(new {Message = response.Message});

            return CreatedAtRoute("api/v1/[controller]/{id}", entity);
        }

        [Route("{id}")]
        [HttpPut]
        [ProducesResponseType((int) HttpStatusCode.Accepted)]
        public IActionResult Update([FromBody] EPatrimonio entity)
        {
            var response = _service.Update(entity);

            if(!response.Ok) return BadRequest(new {Message = response.Message});
            if(response.ObjectResponse == 0) return NotFound();

            return Accepted();
        }

        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public IActionResult Delete([FromRoute] int id)
        {
            var response = _service.Delete(id);

            if(response.ObjectResponse == 0) return NotFound();

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            var response = _service.GetAll();

            return Ok(response.ObjectResponse);
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = _service.GetById(id);

            if(response.ObjectResponse == null) return NotFound();

            return Ok(response.ObjectResponse);
        }
    }
}