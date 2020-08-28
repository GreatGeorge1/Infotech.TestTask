using System.Collections.Generic;
using System.Threading.Tasks;
using Infotech.TestTask.Webapi.Models;

namespace Infotech.TestTask.Webapi.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetByOwner(long personId);
        Task<IEnumerable<Car>> GetByOwner(string personExternalId);
        Task<IEnumerable<Person>> GetOwners(long carId);
        Task<IEnumerable<Person>> GetOwners(string carNationalId);
    }
}