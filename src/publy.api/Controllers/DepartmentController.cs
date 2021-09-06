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
  [Route(("api/v1/departments"))]
  [ApiController]
  public class DepartmentController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IMapper mapper, IDepartmentService departmentService)
    {
      _mapper = mapper;
      _departmentService = departmentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentViewModel departmentViewModel)
    {
      try
      {
        DepartmentDTO departmentDTO = _mapper.Map<DepartmentDTO>(departmentViewModel);

        DepartmentDTO departmentCreated = await _departmentService.Create(departmentDTO);

        return Ok(new ResponseViewModel
        {
          Message = "Department created successfully!",
          Success = true,
          Data = departmentCreated
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
    public async Task<IActionResult> GetDepartment(Guid id)
    {
      try
      {
        DepartmentDTO department = await _departmentService.GetById(id);

        if (department == null)
        {
          return NotFound(new ResponseViewModel
          {
            Message = "Department not found.",
            Success = true,
            Data = department
          });
        }

        return Ok(new ResponseViewModel
        {
          Message = "Department found successfully.",
          Success = true,
          Data = department
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
    public async Task<IActionResult> GetDepartments()
    {
      try
      {
        List<DepartmentDTO> departments = await _departmentService.GetAll();

        return Ok(new ResponseViewModel
        {
          Message = "Departments found successfully.",
          Success = true,
          Data = departments
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
    public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentViewModel departmentViewModel)
    {
      try
      {
        DepartmentDTO departmentDTO = _mapper.Map<DepartmentDTO>(departmentViewModel);
        DepartmentDTO departmentUpdated = await _departmentService.Update(departmentDTO);

        return Ok(new ResponseViewModel
        {
          Message = "Department updated successfully.",
          Success = true,
          Data = departmentUpdated
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
    public async Task<IActionResult> DeleteDepartment(Guid id)
    {
      try
      {
        await _departmentService.Remove(id);

        return Ok(new ResponseViewModel
        {
          Message = "Department removed successfully.",
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
