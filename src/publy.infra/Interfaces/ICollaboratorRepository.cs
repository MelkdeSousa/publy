using System.Collections.Generic;
using System.Threading.Tasks;
using Publy.Domain.Entities;

namespace Publy.Infra.Interfaces
{
  public interface ICollaboratorRepository : IBaseRepository<Collaborator>
  {
    Task<Collaborator> GetByName(string name);
    Task<List<Collaborator>> SearchByName(string name);
  }
}
