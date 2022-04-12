using Core.CarDealer.Commands.Images;
using Core.CarDealer.DTO;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private IMediator _mediator;
        private IServiceBlob _blobService;
        public ImagesController(
            IMediator mediator,
            IServiceBlob serviceBlob)
        {
            _mediator = mediator;
            _blobService = serviceBlob;
        }


     
    }

}
