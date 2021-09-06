using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Publy.Services.DTO;

namespace Publy.Services.Interfaces
{
  public interface ICollaboratorDepartmentService
  {
    Task<CollaboratorDepartmentDTO> Create(CollaboratorDepartmentDTO collaboratorDepartmentDTO);
    Task<List<CollaboratorDepartmentDTO>> GetAll();
    Task<CollaboratorDepartmentDTO> GetCollaboratorDepartmentById(Guid collaboratorId, Guid departmentId);
    Task Remove(Guid collaboratorId, Guid departmentId);
    Task<List<CollaboratorDepartmentDTO>> SearchByName(string collaboratorName, string departmentName);
    Task<CollaboratorDepartmentDTO> Update(CollaboratorDepartmentDTO collaboratorDepartmentDTO);
  }
}
