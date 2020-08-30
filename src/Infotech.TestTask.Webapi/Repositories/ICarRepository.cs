using System.Collections.Generic;
using System.Threading.Tasks;
using Infotech.TestTask.Webapi.Models;

namespace Infotech.TestTask.Webapi.Repositories
{
    public interface ICarRepository
    {
        Task<IReadOnlyList<Car>> GetByOwner(long personId);
        Task<IReadOnlyList<Car>> GetByOwner(string personExternalId);
        Task<IReadOnlyList<Person>> GetOwners(long carId);
        Task<IReadOnlyList<Person>> GetOwners(string carNationalId);
    }
}