using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Publy.Domain.Entities;
using Publy.Infra.Context;
using Publy.Infra.Interfaces;

namespace Publy.Infra.Repositories
{
  public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
  {
    private readonly PublyContext _context;

    public DepartmentRepository(PublyContext context) : base(context)
    {
      _context = context;
    }

    public virtual async Task<Department> GetByName(string name)
    {
      Department department = await _context
                          .Departments
                          .Where(c => c.Name.ToLower() == name.ToLower())
                          .AsNoTracking()
                          .FirstOrDefaultAsync();

      return department;
    }

    public virtual async Task<List<Department>> SearchByName(string name)
    {
      List<Department> departments = await _context
                                            .Departments
                                            .Where(c => c.Name.ToLower().Contains(name.ToLower()))
                                            .AsNoTracking()
                                            .ToListAsync();

      return departments;
    }
  }
}
