using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Publy.Services.DTO;
using Publy.Api.ViewModels;
using Publy.Domain.Entities;
using Publy.Services.Interfaces;
using Publy.Api.Utilities;
using Publy.Core.Exceptions;
using System;
using System.Collections.Generic;

namespace Publy.Api.Controllers
{
  [Route(("api/v1/collaborators"))]
  [ApiController]
  public class CollaboratorController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly ICollaboratorService _collaboratorService;

    public CollaboratorController(IMapper mapper, ICollaboratorService collaboratorService)
    {
      _mapper = mapper;
      _collaboratorService = collaboratorService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCollaborator([FromBody] CreateCollaboratorViewModel collaboratorViewModel)
    {
      try
      {
        CollaboratorDTO collaboratorDTO = _mapper.Map<CollaboratorDTO>(collaboratorViewModel);

        CollaboratorDTO collaboratorCreated = await _collaboratorService.Create(collaboratorDTO);

        return Ok(new ResponseViewModel
        {
          Message = "Collaborator created successfully!",
          Success = true,
          Data = collaboratorCreated
        });
      }
      catch (DomainException domainException)
      {
        return BadRequest(Responses.DomainErrorMessage(domainException.Message, domainException.Errors));
      }
      catch (Exception)
      {
        return StatusCode(500, Responses.ApplicationErrorMessage());
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCollaborator(Guid id)
    {
      try
      {
        CollaboratorDTO collaborator = await _collaboratorService.GetById(id);

        if (collaborator == null)
        {
          return NotFound(new ResponseViewModel
          {
            Message = "Collaborator not found.",
            Success = true,
            Data = collaborator
          });
        }

        return Ok(new ResponseViewModel
        {
          Message = "Collaborator found successfully.",
          Success = true,
          Data = collaborator
        });
      }
      catch (DomainException domainException)
      {
        return BadRequest(Responses.DomainErrorMessage(domainException.Message, domainException.Errors));
      }
      catch (Exception)
      {
        return StatusCode(500, Responses.ApplicationErrorMessage());
      }
    }

    [HttpGet]
    public async Task<IActionResult> GetCollaborators()
    {
      try
      {
        List<CollaboratorDTO> collaborators = await _collaboratorService.GetAll();

        return Ok(new ResponseViewModel
        {
          Message = "Collaborators found successfully.",
          Success = true,
          Data = collaborators
        });
      }
      catch (DomainException domainException)
      {
        return BadRequest(Responses.DomainErrorMessage(domainException.Message, domainException.Errors));
      }
      catch (Exception)
      {
        return StatusCode(500, Responses.ApplicationErrorMessage());
      }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCollaborator([FromBody] UpdateCollaboratorViewModel collaboratorViewModel)
    {
      try
      {
        CollaboratorDTO collaboratorDTO = _mapper.Map<CollaboratorDTO>(collaboratorViewModel);
        CollaboratorDTO collaboratorUpdated = await _collaboratorService.Update(collaboratorDTO);

        return Ok(new ResponseViewModel
        {
          Message = "Collaborator updated successfully.",
          Success = true,
          Data = collaboratorUpdated
        });
      }
      catch (DomainException domainException)
      {
        return BadRequest(Responses.DomainErrorMessage(domainException.Message, domainException.Errors));
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCollaborator(Guid id)
    {
      try
      {
        await _collaboratorService.Remove(id);

        return Ok(new ResponseViewModel
        {
          Message = "Collaborator removed successfully.",
          Success = true,
          Data = null
        });
      }
      catch (DomainException ex)
      {
        return BadRequest(Responses.DomainErrorMessage(ex.Message));
      }
      catch (Exception)
      {
        return StatusCode(500, Responses.ApplicationErrorMessage());
      }
    }
  }
}
