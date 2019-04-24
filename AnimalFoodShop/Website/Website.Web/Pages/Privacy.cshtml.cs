using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Website.Application.Customers;
using Website.Application.Products;

namespace Website.Web.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly IMediator _mediator;

        public PrivacyModel(IMediator mediator) => _mediator = mediator;

        public void OnGet() => _mediator
            .Publish(new AddProductsToCacheNotification(new CustomerLoggedInEvent(Guid.NewGuid(), new List<Guid>())));
    }
}