using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakerCollection.API.Contracts.Sneaker;
using SneakerCollection.Application.Services.Sneaker;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.Entities;
using SneakerCollection.Domain.UserAggregate.ValueObjects;
using System.Runtime.CompilerServices;

namespace SneakerCollection.API.Controllers
{
    [ApiController]
    [Route("sneaker")]
    [Authorize]
    public class SneakerController : ControllerBase
    {
        private readonly ISneakerService _sneakerService;
        public SneakerController(
            ISneakerService sneakerService)
        {
            _sneakerService = sneakerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSneakersByUser()
        {
            var loggedUserId = User.FindFirst("uid").Value;
            if (loggedUserId == null)
            {
                return Unauthorized("There is no user actually logged into the server, please try again");
            }
            var guid = Guid.Parse(loggedUserId);
            var response = await _sneakerService.GetSneakerByUserId(UserId.Create(guid));
            return Ok(response);
        }

        [HttpGet("{sneakerId}")]
        public async Task<IActionResult> GetSneakerById(string sneakerId)
        {
            var loggedUserId = User.FindFirst("uid").Value;
            if (loggedUserId == null)
            {
                return Unauthorized("There is no user actually logged into the server, please try again");
            }
            var guid = Guid.Parse(loggedUserId);
            var snkId = Guid.Parse(sneakerId);
            var response = await _sneakerService.GetSneakerById(SneakerId.Create(snkId),UserId.Create(guid));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSneaker(CreateSneakerRequest request)
        {
            var loggedUserId =  User.FindFirst("uid").Value;
            if (loggedUserId == null)
            {
                return BadRequest("There is no user actually logged into the server, please try again");
            }
            var userId = UserId.Create(Guid.Parse(loggedUserId));
            var sneaker = Sneaker.Create(request.Name, request.Brand, request.Price, request.Size, request.Year, request.Rate,userId);
            await _sneakerService.AddSneaker(sneaker);
            return Ok(sneaker);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateSneaker(UpdateSneakerRequest request)
        {
            var loggedUserId = User.FindFirst("uid").Value;
            if (loggedUserId == null)
            {
                return BadRequest("There is no user actually logged into the server, please try again");
            }
            var sneakerId = SneakerId.Create(Guid.Parse(request.SneakerId));
            var userId = UserId.Create(Guid.Parse(loggedUserId));
            var sneaker = await _sneakerService.GetSneakerById(sneakerId,userId);
            if (sneaker == null)
            {
                return Problem("Occured an error while updating the sneaker");
            }
            else
            {
                sneaker.Update(
                    request.Name,
                    request.Brand,
                    request.Price,
                    request.Size,
                    request.Year,
                    request.Rate);
            }
            await _sneakerService.UpdateSneaker(sneaker);

            var response = new SneakerResponse(
                sneaker.Id.Value.ToString(),
                sneaker.Brand,
                sneaker.Name,
                sneaker.Price,
                sneaker.Rate,
                sneaker.Size,
                sneaker.Year);

            return Ok(sneaker);

        }
    }
}
