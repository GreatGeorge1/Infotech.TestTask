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

        [HttpGet("Owners")]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetOwners(long carId = 0, string carNationalId = "")
        {
            IEnumerable<Person> owners = null;
            if (carId != 0)
            {
                owners = await _repo.GetOwners(carId).ConfigureAwait(false);
            }
            if (!string.IsNullOrWhiteSpace(carNationalId) && owners is null)
            {
                owners = await _repo.GetOwners(carNationalId).ConfigureAwait(false);
            }
            if (owners?.Any() != true)
            {
                return NotFound();
            }
            return new ActionResult<IEnumerable<PersonDto>>(_mapper.Map<IEnumerable<Person>,IEnumerable<PersonDto>>(owners));
        }

        [HttpPost("ByPersonExternalId")]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCarsByPersonExternalId([FromBody] GetCarsByPersonExternalIdRequest req)
        {
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
            var cars = await _repo.GetByOwner(req.PersonId).ConfigureAwait(false);
            if (cars.Any())
            {
                return new ActionResult<IEnumerable<CarDto>>(_mapper.Map<IEnumerable<Car>,IEnumerable<CarDto>>(cars));
            }
            return NotFound();
        }
    }
}
