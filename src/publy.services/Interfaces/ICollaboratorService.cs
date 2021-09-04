using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using publy.services.DTO;

namespace Publy.Services.Interfaces
{
  public interface ICollaboratorService
  {
    Task<CollaboratorDTO> Create(CollaboratorDTO userDTO);
    Task<CollaboratorDTO> Update(CollaboratorDTO userDTO);
    Task Remove(Guid id);
    Task<CollaboratorDTO> GetById(Guid id);
    Task<List<CollaboratorDTO>> GetAll();
    Task<List<CollaboratorDTO>> SearchByName(string name);
  }
}
