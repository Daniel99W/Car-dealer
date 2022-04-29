using Core.CarDealer.Commands.Brands;
using Core.CarDealer.DTO;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.Brands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private IMediator _mediator;
        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> AddBrand(CreateBrandDTO createBrandDTO)
        {
            await _mediator.Send(new CreateBrandCommand
            {
                Name = createBrandDTO.Name,
                Description = createBrandDTO.Description,
            });
            return Ok(200);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            return new ActionResult<IEnumerable<Brand>>(await _mediator.Send(new GetBrandsQuery()));
        }


           

    }
}
