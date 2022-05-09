using AutoMapper;
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
        private IMapper _mapper;
        public BrandController(
            IMediator mediator,
            IMapper mapper
            )
        {
            _mediator = mediator;
            _mapper = mapper;
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
        public async Task<ActionResult<IEnumerable<GetBrandDTO>>> GetBrands()
        {
            return new ActionResult<IEnumerable<GetBrandDTO>>(_mapper.Map<IEnumerable<Brand>, IEnumerable<GetBrandDTO>>(
                await _mediator.Send(new GetBrandsQuery())));
        }


           

    }
}
