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
  public class DepartmentService : IDepartmentService
  {
    private readonly IMapper _mapper;
    private readonly IDepartmentRepository _DepartmentRepository;

    public DepartmentService(IMapper mapper, IDepartmentRepository DepartmentRepository)
    {
      _mapper = mapper;
      _DepartmentRepository = DepartmentRepository;
    }

    public virtual async Task<DepartmentDTO> Create(DepartmentDTO DepartmentDTO)
    {
      Department DepartmentExists = await _DepartmentRepository.GetByName(DepartmentDTO.Name);

      if (DepartmentExists != null)
        throw new DomainException("Department already exists");

      Department Department = _mapper.Map<Department>(DepartmentDTO);
      Department.Validate();

      Department DepartmentCreated = await _DepartmentRepository.Create(Department);

      return _mapper.Map<DepartmentDTO>(DepartmentCreated);
    }

    public virtual async Task<List<DepartmentDTO>> GetAll()
    {
      List<Department> Departments = await _DepartmentRepository.GetAll();

      return _mapper.Map<List<DepartmentDTO>>(Departments);
    }

    public virtual async Task<DepartmentDTO> GetById(Guid id)
    {
      Department Department = await _DepartmentRepository.GetById(id);

      return _mapper.Map<DepartmentDTO>(Department);
    }

    public virtual async Task Remove(Guid id)
    {
      await _DepartmentRepository.Remove(id);
    }

    public virtual async Task<List<DepartmentDTO>> SearchByName(string name)
    {
      List<Department> Departments = await _DepartmentRepository.SearchByName(name);

      return _mapper.Map<List<DepartmentDTO>>(Departments);
    }

    public virtual async Task<DepartmentDTO> Update(DepartmentDTO DepartmentDTO)
    {
      Department DepartmentExists = await _DepartmentRepository.GetById(DepartmentDTO.Id);

      if (DepartmentExists == null)
        throw new DomainException("Department not exists.");

      Department Department = _mapper.Map<Department>(DepartmentDTO);
      Department.Validate();

      Department DepartmentUpdated = await _DepartmentRepository.Update(Department);

      return _mapper.Map<DepartmentDTO>(DepartmentUpdated);


    }
  }
}
