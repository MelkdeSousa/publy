using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Publy.Services.DTO;
using Publy.Api.ViewModels;
using Publy.Services.Interfaces;
using Publy.Api.Utilities;
using Publy.Core.Exceptions;
using System;
using System.Collections.Generic;

namespace Publy.Api.Controllers
{
  [Route(("api/v1/collaborators-departments"))]
  [ApiController]
  public class CollaboratorDepartmentController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly ICollaboratorDepartmentService _collaboratorsDepartmentService;

    public CollaboratorDepartmentController(IMapper mapper, ICollaboratorDepartmentService collaboratorsDepartmentsService)
    {
      _mapper = mapper;
      _collaboratorsDepartmentService = collaboratorsDepartmentsService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCollaboratorDepartmentViewModel collaboratorDepartmentViewModel)
    {
      try
      {
        CollaboratorDepartmentDTO collaboratorDepartmentDTO = _mapper.Map<CollaboratorDepartmentDTO>(collaboratorDepartmentViewModel);
        CollaboratorDepartmentDTO collaboratorDepartmentCreated = await _collaboratorsDepartmentService.Create(collaboratorDepartmentDTO);

        return Ok(new ResponseViewModel
        {
          Message = $"Relationship between \"{collaboratorDepartmentCreated.Collaborator.Name}\" and Department of \"{collaboratorDepartmentCreated.Department.Name}\" created successfully.",
          Success = true,
          Data = collaboratorDepartmentCreated
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
    public async Task<IActionResult> Get()
    {
      try
      {
        List<CollaboratorDepartmentDTO> collaboratorsDepartments = await _collaboratorsDepartmentService.GetAll();

        return Ok(new ResponseViewModel
        {
          Message = "Relationships between collaborators and departments found successfully.",
          Success = true,
          Data = collaboratorsDepartments
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
    public async Task<IActionResult> Update([FromBody] UpdateCollaboratorDepartmentViewModel collaboratorDepartmentViewModel)
    {
      try
      {
        CollaboratorDepartmentDTO collaboratorDepartmentDTO = _mapper.Map<CollaboratorDepartmentDTO>(collaboratorDepartmentViewModel);
        CollaboratorDepartmentDTO collaboratorDepartmentUpdated = await _collaboratorsDepartmentService.Update(collaboratorDepartmentDTO);

        return Ok(new ResponseViewModel
        {
          Message = $"Relationship between \"{collaboratorDepartmentUpdated.Collaborator.Name}\" and Department of \"{collaboratorDepartmentUpdated.Department.Name}\" updated successfully.",
          Success = true,
          Data = collaboratorDepartmentUpdated
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

    [HttpDelete]
    [Route("/api/v1/collaborators/{collaboratorId}/departments/{departmentId}")]
    public async Task<IActionResult> Remove(Guid collaboratorId, Guid departmentId)
    {
      try
      {
        await _collaboratorsDepartmentService.Remove(collaboratorId, departmentId);

        return Ok(new ResponseViewModel
        {
          Message = $"Relationship deleted successfully.",
          Success = true,
          Data = null
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
  }
}
