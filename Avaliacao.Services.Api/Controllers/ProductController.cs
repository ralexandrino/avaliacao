using System;
using Avaliacao.Application.Interfaces;
using Avaliacao.Application.ViewModels;
using Avaliacao.Domain.Core.Bus;
using Avaliacao.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _ProductAppService;

        public ProductController(IProductAppService ProductAppService)
        {
            _ProductAppService = ProductAppService;
        }

        [HttpGet]
        [Route("~/Product")]
        public IActionResult Get()
        {
            var products = _ProductAppService.GetAll();

            if (products == null)
                return NotFound();

            return Ok(products);
        }

        [HttpGet]
        [Route("~/Product/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var product = _ProductAppService.GetById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        [Route("~/Product")]
        public IActionResult Post([FromBody]ProductViewModel ProductViewModel)
        {
            _ProductAppService.Register(ProductViewModel);

            return Ok(ProductViewModel);
        }

        [HttpPut]
        [Route("~/Product")]
        public IActionResult Put([FromBody]ProductViewModel ProductViewModel)
        {
            _ProductAppService.Update(ProductViewModel);

            return Ok(ProductViewModel);
        }

        [HttpDelete]
        [Route("~/Product")]
        public IActionResult Delete(Guid id)
        {
            _ProductAppService.Remove(id);

            return Ok();
        }
    }
}
