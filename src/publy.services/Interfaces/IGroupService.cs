using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Publy.Services.DTO;

namespace Publy.Services.Interfaces
{
  public interface IGroupService
  {
    Task<GroupDTO> Create(GroupDTO groupDTO);
    Task<GroupDTO> Update(GroupDTO groupDTO);
    Task Remove(Guid id);
    Task<GroupDTO> GetById(Guid id);
    Task<List<GroupDTO>> GetAll();
    Task<List<GroupDTO>> SearchByName(string name);
  }
}
