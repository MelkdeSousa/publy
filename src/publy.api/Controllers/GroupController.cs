using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Publy.Api.ViewModels;
using Publy.Services.DTO;
using Publy.Services.Interfaces;
using Publy.Api.Utilities;
using Publy.Core.Exceptions;

namespace Publy.Api.Controllers
{
  [Route(("api/v1/groups"))]
  [ApiController]
  public class GroupController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IGroupService _groupService;

    public GroupController(IMapper mapper, IGroupService groupService)
    {
      _mapper = mapper;
      _groupService = groupService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGroup([FromBody] CreateGroupViewModel groupViewModel)
    {
      try
      {
        GroupDTO groupDTO = _mapper.Map<GroupDTO>(groupViewModel);

        GroupDTO groupCreated = await _groupService.Create(groupDTO);

        return Ok(new ResponseViewModel
        {
          Message = "Group created successfully!",
          Success = true,
          Data = groupCreated
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
    public async Task<IActionResult> GetGroup(Guid id)
    {
      try
      {
        GroupDTO group = await _groupService.GetById(id);

        if (group == null)
        {
          return NotFound(new ResponseViewModel
          {
            Message = "Group not found.",
            Success = true,
            Data = group
          });
        }

        return Ok(new ResponseViewModel
        {
          Message = "Group found successfully.",
          Success = true,
          Data = group
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
    public async Task<IActionResult> GetGroups()
    {
      try
      {
        List<GroupDTO> groups = await _groupService.GetAll();

        return Ok(new ResponseViewModel
        {
          Message = "Groups found successfully.",
          Success = true,
          Data = groups
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
    public async Task<IActionResult> UpdateGroup([FromBody] UpdateGroupViewModel groupViewModel)
    {
      try
      {
        GroupDTO groupDTO = _mapper.Map<GroupDTO>(groupViewModel);
        GroupDTO groupUpdated = await _groupService.Update(groupDTO);

        return Ok(new ResponseViewModel
        {
          Message = "Group updated successfully.",
          Success = true,
          Data = groupUpdated
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
    public async Task<IActionResult> DeleteGroup(Guid id)
    {
      try
      {
        await _groupService.Remove(id);

        return Ok(new ResponseViewModel
        {
          Message = "Group removed successfully.",
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
