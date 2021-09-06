using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Publy.Domain.Entities;
using Publy.Infra.Context;
using Publy.Infra.Interfaces;

namespace Publy.Infra.Repositories
{
  public class CollaboratorDepartmentRepository : ICollaboratorDepartmentRepository
  {
    private readonly PublyContext _context;

    public CollaboratorDepartmentRepository(PublyContext context)
    {
      _context = context;
    }

    public virtual async Task<CollaboratorDepartment> Create(CollaboratorDepartment collaboratorDepartment)
    {
      _context.Add(collaboratorDepartment);
      await _context.SaveChangesAsync();

      return collaboratorDepartment;
    }

    public virtual async Task<CollaboratorDepartment> Update(CollaboratorDepartment collaboratorDepartment)
    {
      _context.Entry(collaboratorDepartment).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return collaboratorDepartment;
    }

    public virtual async Task<List<CollaboratorDepartment>> GetAll()
    {
      return await _context.Set<CollaboratorDepartment>()
                            .AsNoTracking()
                            .ToListAsync();
    }

    public virtual async Task RemoveCollaboratorDepartment(Guid collaboratorId, Guid departmentId)
    {
      CollaboratorDepartment collaboratorByDepartment = await GetCollaboratorDepartmentById(collaboratorId, departmentId);

      if (collaboratorByDepartment != null)
      {
        _context.Remove(collaboratorByDepartment);
        await _context.SaveChangesAsync();
      }
    }

    public async Task<CollaboratorDepartment> GetCollaboratorDepartmentById(Guid collaboratorId, Guid departmentId)
    {
      CollaboratorDepartment collaboratorDepartment = await _context
                .Set<CollaboratorDepartment>()
                .AsNoTracking()
                .Where(x => x.Collaborator.Id == collaboratorId && x.Department.Id == departmentId)
                .FirstOrDefaultAsync();

      return collaboratorDepartment;

    }

    public async Task<List<CollaboratorDepartment>> SearchCollaboratorDepartmentByName(string collaboratorName, string departmentName)
    {
      List<CollaboratorDepartment> collaboratorsDepartments = await _context
                                          .Set<CollaboratorDepartment>()
                                          .Where(
                                            cd => cd.Collaborator.Name.ToLower().Contains(collaboratorName.ToLower())
                                            || cd.Department.Name.ToLower().Contains(departmentName.ToLower()))
                                          .AsNoTracking()
                                          .ToListAsync();

      return collaboratorsDepartments;
    }
  }
}
