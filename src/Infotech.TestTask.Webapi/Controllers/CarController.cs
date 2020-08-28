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
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetOwnersById(long id = 0)
        {
            if (id <= 0)
            {
                return BadRequest("carId має бути більше нуля");
            }
            IEnumerable<Person> owners = await _repo.GetOwners(id).ConfigureAwait(false);
            if (owners?.Any() != true)
            {
                return NotFound();
            }
            return new ActionResult<IEnumerable<PersonDto>>(_mapper.Map<IEnumerable<Person>,IEnumerable<PersonDto>>(owners));
        }
        
        [HttpGet("OwnersByCarNationalId")]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetOwnersByNationalId(string id = "")
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            IEnumerable<Person> owners = await _repo.GetOwners(id).ConfigureAwait(false);
            if (owners?.Any() != true)
            {
                return NotFound();
            }
            return new ActionResult<IEnumerable<PersonDto>>(_mapper.Map<IEnumerable<Person>,IEnumerable<PersonDto>>(owners));
        }

        [HttpPost("ByPersonExternalId")]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCarsByPersonExternalId([FromBody] GetCarsByPersonExternalIdRequest req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cars = await _repo.GetByOwner(req.PersonExternalId).ConfigureAwait(false);
            if (cars.Any())
            {
                return new ActionResult<IEnumerable<CarDto>>(_mapper.Map<IEnumerable<Car>,IEnumerable<CarDto>>(cars));
            }
            return NotFound();
        }

        [HttpPost("ByPersonId")]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCarsByPersonId([FromBody] GetCarsByPersonIdRequest req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cars = await _repo.GetByOwner((long)req.PersonId).ConfigureAwait(false);
            if (cars.Any())
            {
                return new ActionResult<IEnumerable<CarDto>>(_mapper.Map<IEnumerable<Car>,IEnumerable<CarDto>>(cars));
            }
            return NotFound();
        }
    }
}
