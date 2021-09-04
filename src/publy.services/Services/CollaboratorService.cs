using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using publy.services.DTO;
using Publy.Core.Exceptions;
using Publy.Domain.Entities;
using Publy.Infra.Interfaces;
using Publy.Services.Interfaces;

namespace Publy.Services.Services
{
  public class CollaboratorService : ICollaboratorService
  {
    private readonly IMapper _mapper;
    private readonly ICollaboratorRepository _collaboratorRepository;

    public CollaboratorService(IMapper mapper, ICollaboratorRepository collaboratorRepository)
    {
      _mapper = mapper;
      _collaboratorRepository = collaboratorRepository;
    }

    public virtual async Task<CollaboratorDTO> Create(CollaboratorDTO collaboratorDTO)
    {
      Collaborator collaboratorExists = await _collaboratorRepository.GetByEmail(collaboratorDTO.Email);

      if (collaboratorExists != null)
        throw new DomainException("Collaborator already exists");

      Collaborator collaborator = _mapper.Map<Collaborator>(collaboratorDTO);
      collaborator.Validate();

      Collaborator collaboratorCreated = await _collaboratorRepository.Create(collaborator);

      return _mapper.Map<CollaboratorDTO>(collaboratorCreated);
    }

    public virtual async Task<List<CollaboratorDTO>> GetAll()
    {
      List<Collaborator> collaborators = await _collaboratorRepository.GetAll();

      return _mapper.Map<List<CollaboratorDTO>>(collaborators);
    }

    public virtual async Task<CollaboratorDTO> GetById(Guid id)
    {
      Collaborator collaborator = await _collaboratorRepository.GetById(id);

      return _mapper.Map<CollaboratorDTO>(collaborator);
    }

    public virtual async Task Remove(Guid id)
    {
      await _collaboratorRepository.Remove(id);
    }

    public virtual async Task<List<CollaboratorDTO>> SearchByName(string name)
    {
      List<Collaborator> collaborators = await _collaboratorRepository.SearchByName(name);

      return _mapper.Map<List<CollaboratorDTO>>(collaborators);
    }

    public virtual async Task<CollaboratorDTO> Update(CollaboratorDTO collaboratorDTO)
    {
      Collaborator collaboratorExists = await _collaboratorRepository.GetById(collaboratorDTO.Id);

      if (collaboratorExists == null)
        throw new DomainException("Collaborator not exists.");

      Collaborator collaborator = _mapper.Map<Collaborator>(collaboratorDTO);
      collaborator.Validate();

      Collaborator collaboratorUpdated = await _collaboratorRepository.Update(collaborator);

      return _mapper.Map<CollaboratorDTO>(collaboratorUpdated);


    }
  }
}
