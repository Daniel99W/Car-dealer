using Core.CarDealer.Commands.Images;
using Core.CarDealer.DTO;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries;
using Core.CarDealer.Queries.Images;
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
  
        public ImagesController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> UploadImages(UploadImageDTO uploadImageDTO)
        {
            foreach (IFormFile image in uploadImageDTO.Images)
                await _mediator.Send(new CreateImageCommand
                {
                    CarId = uploadImageDTO.CarId,
                    FormFile = image
                });
            
            return Ok("The images have been uploaded succesfully");
        }

        [HttpGet("{imageName}")]
        public async Task<ActionResult> RemoveImage(string imageName)
        {
            Image? image = await _mediator.Send(new GetImageByNameQuery
            {
                ImageName = imageName
            });

            if (image == null)
                return NotFound();

            await _mediator.Send(new DeleteImageCommand
            {
                ImageName = image.ImageName,
                CarId = (Guid) image.CarId
            });

            return Ok();
        }


     
    }

}
