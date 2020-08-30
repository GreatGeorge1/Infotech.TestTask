using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infotech.TestTask.Webapi.Models;
using Infotech.TestTask.Webapi.Dto;
using Infotech.TestTask.Webapi.Repositories;
using AutoMapper;

namespace Infotech.TestTask.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _repo;
        private readonly IMapper _mapper;

        public CarController(ICarRepository repo, IMapper mapper)
        {
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            _repo = repo ?? throw new System.ArgumentNullException(nameof(repo));
        }

        [HttpGet("OwnersByCarId")]
        public async Task<ActionResult<IReadOnlyList<PersonDto>>> GetOwnersById(long id = 0)
        {
            if (id <= 0)
            {
                return BadRequest("carId має бути більше нуля");
            }
            IReadOnlyList<Person> owners = await _repo.GetOwners(id).ConfigureAwait(false);
            if (owners?.Any() != true)
            {
                return NotFound();
            }
            return new ActionResult<IReadOnlyList<PersonDto>>(_mapper.Map<IReadOnlyList<Person>,IReadOnlyList<PersonDto>>(owners));
        }

        [HttpGet("OwnersByCarNationalId")]
        public async Task<ActionResult<IReadOnlyList<PersonDto>>> GetOwnersByNationalId(string id = "")
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            IReadOnlyList<Person> owners = await _repo.GetOwners(id).ConfigureAwait(false);
            if (owners?.Any() != true)
            {
                return NotFound();
            }
            return new ActionResult<IReadOnlyList<PersonDto>>(_mapper.Map<IReadOnlyList<Person>,IReadOnlyList<PersonDto>>(owners));
        }

        [HttpPost("ByPersonExternalId")]
        public async Task<ActionResult<IReadOnlyList<CarDto>>> GetCarsByPersonExternalId([FromBody] GetCarsByPersonExternalIdRequest req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cars = await _repo.GetByOwner(req.PersonExternalId).ConfigureAwait(false);
            if (cars.Any())
            {
                return new ActionResult<IReadOnlyList<CarDto>>(_mapper.Map<IReadOnlyList<Car>,IReadOnlyList<CarDto>>(cars));
            }
            return NotFound();
        }

        [HttpPost("ByPersonId")]
        public async Task<ActionResult<IReadOnlyList<CarDto>>> GetCarsByPersonId([FromBody] GetCarsByPersonIdRequest req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cars = await _repo.GetByOwner((long)req.PersonId).ConfigureAwait(false);
            if (cars.Any())
            {
                return new ActionResult<IReadOnlyList<CarDto>>(_mapper.Map<IReadOnlyList<Car>,IReadOnlyList<CarDto>>(cars));
            }
            return NotFound();
        }
    }
}
