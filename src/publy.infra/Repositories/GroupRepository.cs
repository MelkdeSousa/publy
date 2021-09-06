using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Publy.Domain.Entities;
using Publy.Infra.Context;
using Publy.Infra.Interfaces;

namespace Publy.Infra.Repositories
{
  public class GroupRepository : BaseRepository<Group>, IGroupRepository
  {
    private readonly PublyContext _context;

    public GroupRepository(PublyContext context) : base(context)
    {
      _context = context;
    }

    public virtual async Task<Group> GetByName(string name)
    {
      Group group = await _context
                          .Groups
                          .Where(c => c.Name.ToLower() == name.ToLower())
                          .AsNoTracking()
                          .FirstOrDefaultAsync();

      return group;
    }

    public virtual async Task<List<Group>> SearchByName(string name)
    {
      List<Group> groups = await _context
                                            .Groups
                                            .Where(c => c.Name.ToLower().Contains(name.ToLower()))
                                            .AsNoTracking()
                                            .ToListAsync();

      return groups;
    }
  }
}
