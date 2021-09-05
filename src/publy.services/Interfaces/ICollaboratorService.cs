using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Publy.Services.DTO;

namespace Publy.Services.Interfaces
{
  public interface ICollaboratorService
  {
    Task<CollaboratorDTO> Create(CollaboratorDTO collaboratorDTO);
    Task<CollaboratorDTO> Update(CollaboratorDTO collaboratorDTO);
    Task Remove(Guid id);
    Task<CollaboratorDTO> GetById(Guid id);
    Task<List<CollaboratorDTO>> GetAll();
    Task<List<CollaboratorDTO>> SearchByName(string name);
  }
}
