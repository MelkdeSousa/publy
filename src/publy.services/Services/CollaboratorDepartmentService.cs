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
  public class CollaboratorDepartmentService : ICollaboratorDepartmentService
  {
    private readonly IMapper _mapper;
    private readonly ICollaboratorDepartmentRepository _collaboratorDepartmentRepository;

    public CollaboratorDepartmentService(IMapper mapper, ICollaboratorDepartmentRepository collaboratorDepartmentRepository)
    {
      _mapper = mapper;
      _collaboratorDepartmentRepository = collaboratorDepartmentRepository;
    }

    public virtual async Task<CollaboratorDepartmentDTO> Create(CollaboratorDepartmentDTO collaboratorDepartmentDTO)
    {
      CollaboratorDepartment collaboratorDepartmentExists = await _collaboratorDepartmentRepository.GetCollaboratorDepartmentById(collaboratorDepartmentDTO.CollaboratorId, collaboratorDepartmentDTO.DepartmentId);

      if (collaboratorDepartmentExists != null)
        throw new DomainException("CollaboratorDepartment already exists");

      CollaboratorDepartment collaboratorDepartment = _mapper.Map<CollaboratorDepartment>(collaboratorDepartmentDTO);

      CollaboratorDepartment collaboratorDepartmentCreated = await _collaboratorDepartmentRepository.Create(collaboratorDepartment);

      return _mapper.Map<CollaboratorDepartmentDTO>(collaboratorDepartmentCreated);
    }

    public virtual async Task<List<CollaboratorDepartmentDTO>> GetAll()
    {
      List<CollaboratorDepartment> CollaboratorDepartments = await _collaboratorDepartmentRepository.GetAll();

      return _mapper.Map<List<CollaboratorDepartmentDTO>>(CollaboratorDepartments);
    }

    public virtual async Task<CollaboratorDepartmentDTO> GetCollaboratorDepartmentById(Guid collaboratorId, Guid departmentId)
    {
      CollaboratorDepartment collaboratorDepartment = await _collaboratorDepartmentRepository.GetCollaboratorDepartmentById(collaboratorId, departmentId);

      return _mapper.Map<CollaboratorDepartmentDTO>(collaboratorDepartment);
    }

    public virtual async Task Remove(Guid collaboratorId, Guid departmentId)
    {
      await _collaboratorDepartmentRepository.RemoveCollaboratorDepartment(collaboratorId, departmentId);
    }

    public virtual async Task<List<CollaboratorDepartmentDTO>> SearchByName(string collaboratorName, string departmentName)
    {
      List<CollaboratorDepartment> collaboratorDepartments = await _collaboratorDepartmentRepository.SearchCollaboratorDepartmentByName(collaboratorName, departmentName);

      return _mapper.Map<List<CollaboratorDepartmentDTO>>(collaboratorDepartments);
    }

    public virtual async Task<CollaboratorDepartmentDTO> Update(CollaboratorDepartmentDTO collaboratorDepartmentDTO)
    {
      CollaboratorDepartment collaboratorDepartmentExists = await _collaboratorDepartmentRepository.GetCollaboratorDepartmentById(collaboratorDepartmentDTO.CollaboratorId, collaboratorDepartmentDTO.DepartmentId);

      if (collaboratorDepartmentExists == null)
        throw new DomainException("CollaboratorDepartment not exists.");

      CollaboratorDepartment collaboratorDepartment = _mapper.Map<CollaboratorDepartment>(collaboratorDepartmentDTO);

      CollaboratorDepartment collaboratorDepartmentUpdated = await _collaboratorDepartmentRepository.Update(collaboratorDepartment);

      return _mapper.Map<CollaboratorDepartmentDTO>(collaboratorDepartmentUpdated);
    }
  }
}
