using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application;
using Products.DTO;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) => _mediator = mediator;

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get()
        {
            var products = await _mediator
                .Send(new ProductsQuery())
                .ConfigureAwait(false);

            return products.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name
            }).AsEnumerable();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
