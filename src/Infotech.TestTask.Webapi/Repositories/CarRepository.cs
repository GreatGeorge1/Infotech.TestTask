using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infotech.TestTask.Webapi.EntityFrameworkCore;
using Infotech.TestTask.Webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Infotech.TestTask.Webapi.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationContext _context;

        public CarRepository(ApplicationContext context){
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Car>> GetByOwner(long personId)
        {
            var person = await _context.People
                .AsNoTracking()
                .Include(p=>p.PersonCars)
                .FirstOrDefaultAsync(p=>p.Id==personId).ConfigureAwait(false);
            if(person is null){
                return new List<Car>();
            }

            var idList = person.PersonCars.Select(p => p.CarId);
            return await _context.Cars.AsNoTracking()
                .Where(c=>idList.Contains(c.Id))
                .ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Car>> GetByOwner(string personExternalId)
        {
            var person = await _context.People
                .AsNoTracking()
                .Include(p=>p.PersonCars)
                .FirstOrDefaultAsync(p=>p.ExternalId.Equals(personExternalId)).ConfigureAwait(false);
            if(person is null){
                return new List<Car>();
            }

            var idList = person.PersonCars.Select(p => p.CarId);
            return await _context.Cars.AsNoTracking()
                .Where(c=>idList.Contains(c.Id))
                .ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Person>> GetOwners(long carId)
        {
            var car= await _context.Cars.AsNoTracking()
                .Include(car=>car.PersonCars)
                .FirstOrDefaultAsync(car=>car.Id==carId).ConfigureAwait(false);
            if(car?.PersonCars is null){
                return new List<Person>();
            }
            var idList = car.PersonCars.Select(p=>p.PersonId);
            return await _context.People.AsNoTracking()
                .Where(p=>idList.Contains(p.Id))
                .ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Person>> GetOwners(string carNationalId)
        {
            var car= await _context.Cars.AsNoTracking()
                .Include(car=>car.PersonCars)
                .FirstOrDefaultAsync(car=>car.NationalId==carNationalId).ConfigureAwait(false);
            if(car?.PersonCars is null){
                return new List<Person>();
            }

            var idList = car.PersonCars.Select(p => p.PersonId);
            return await _context.People.AsNoTracking()
                .Where(p=>idList.Contains(p.Id))
                .ToListAsync().ConfigureAwait(false);
        }

        public Task<IEnumerable<Person>> GetOwnersByVIN(string vinNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}