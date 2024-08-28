using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Requests;
using Shop.Features.Products.Create;
using Shop.Features.Products.Delete;
using Shop.Features.Products.Get;
using Shop.Features.Products.Update;

namespace Shop.Api.Controllers;

[ApiController, Authorize, Route("/api/products"), Tags("Product")]
public class ProductController(UserManager<IdentityUser> userManager, IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductRequest request)
    {
        var userId = userManager.GetUserId(User);
        if (userId is null)
            return BadRequest();

        var query = new CreateProductCommand(request.Name, request.Description, request.Price, request.Stock, userId);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [Authorize(Policy = Constants.CanEditPolicy), HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var query = new DeleteProductCommand(id);
        var result = await mediator.Send(query);
        return result is null ? NotFound() : Ok(result);
    }

    [AllowAnonymous, HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var query = new GetProductQuery(id);
        var result = await mediator.Send(query);
        return result is null ? NotFound() : Ok(result);
    }

    [AllowAnonymous, HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var query = new GetProductsQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [Authorize(Policy = Constants.CanEditPolicy), HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid id, UpdateProductRequest request)
    {
        var query = new UpdateProductCommand(id, request.Name, request.Description, request.Price);
        var result = await mediator.Send(query);
        return result is null ? NotFound() : Ok(result);
    }
}
