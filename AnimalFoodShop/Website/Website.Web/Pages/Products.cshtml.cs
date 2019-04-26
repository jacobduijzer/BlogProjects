using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Website.Application.Products;
using Website.Domain.Products;

namespace Website.Web.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IMediator _mediator;

        public ProductsModel(IMediator mediator) => _mediator = mediator;

        public IList<Product> Products { get; private set; }

        public async Task OnGet()
        {
            var products = await _mediator.Send(new ProductsQuery()).ConfigureAwait(false);
            if (products.Any())
                Products = products.ToList();
        }
    }
}
