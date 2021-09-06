using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Publy.Services.DTO;
using Publy.Core.Exceptions;
using Publy.Domain.Entities;
using Publy.Infra.Interfaces;
using Publy.Services.Interfaces;

namespace Publy.Services.Services
{
  public class GroupService : IGroupService
  {
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;

    public GroupService(IMapper mapper, IGroupRepository groupRepository)
    {
      _mapper = mapper;
      _groupRepository = groupRepository;
    }

    public virtual async Task<GroupDTO> Create(GroupDTO groupDTO)
    {
      Group groupExists = await _groupRepository.GetByName(groupDTO.Name);

      if (groupExists != null)
        throw new DomainException("Group already exists");

      Group group = _mapper.Map<Group>(groupDTO);
      group.Validate();

      Group groupCreated = await _groupRepository.Create(group);

      return _mapper.Map<GroupDTO>(groupCreated);
    }

    public virtual async Task<List<GroupDTO>> GetAll()
    {
      List<Group> groups = await _groupRepository.GetAll();

      return _mapper.Map<List<GroupDTO>>(groups);
    }

    public virtual async Task<GroupDTO> GetById(Guid id)
    {
      Group group = await _groupRepository.GetById(id);

      return _mapper.Map<GroupDTO>(group);
    }

    public virtual async Task Remove(Guid id)
    {
      await _groupRepository.Remove(id);
    }

    public virtual async Task<List<GroupDTO>> SearchByName(string name)
    {
      List<Group> groups = await _groupRepository.SearchByName(name);

      return _mapper.Map<List<GroupDTO>>(groups);
    }

    public virtual async Task<GroupDTO> Update(GroupDTO groupDTO)
    {
      Group groupExists = await _groupRepository.GetById(groupDTO.Id);

      if (groupExists == null)
        throw new DomainException("Group not exists.");

      Group group = _mapper.Map<Group>(groupDTO);
      group.Validate();

      Group groupUpdated = await _groupRepository.Update(group);

      return _mapper.Map<GroupDTO>(groupUpdated);


    }
  }
}
