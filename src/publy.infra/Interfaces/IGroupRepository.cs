using System.Collections.Generic;
using System.Threading.Tasks;
using Publy.Domain.Entities;

namespace Publy.Infra.Interfaces
{
  public interface IGroupRepository : IBaseRepository<Group>
  {
    Task<Group> GetByName(string name);
    Task<List<Group>> SearchByName(string name);
  }
}
