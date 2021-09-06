using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Publy.Services.DTO;

namespace Publy.Services.Interfaces
{
  public interface IDepartmentService
  {
    Task<DepartmentDTO> Create(DepartmentDTO departmentDTO);
    Task<DepartmentDTO> Update(DepartmentDTO departmentDTO);
    Task Remove(Guid id);
    Task<DepartmentDTO> GetById(Guid id);
    Task<List<DepartmentDTO>> GetAll();
    Task<List<DepartmentDTO>> SearchByName(string name);
  }
}
