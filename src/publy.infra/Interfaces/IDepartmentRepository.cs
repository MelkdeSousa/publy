using System.Collections.Generic;
using System.Threading.Tasks;
using Publy.Domain.Entities;

namespace Publy.Infra.Interfaces
{
  public interface IDepartmentRepository : IBaseRepository<Department>
  {
    Task<Department> GetByName(string name);
    Task<List<Department>> SearchByName(string name);
  }
}
