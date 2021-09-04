using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Publy.Domain.Entities;
using Publy.Infra.Context;
using Publy.Infra.Interfaces;

namespace Publy.Infra.Repositories
{
  public class CollaboratorRepository : BaseRepository<Collaborator>, ICollaboratorRepository
  {
    private readonly PublyContext _context;

    public CollaboratorRepository(PublyContext context) : base(context)
    {
      _context = context;
    }

    public virtual async Task<Collaborator> GetByEmail(string email)
    {
      Collaborator collaborator = await _context.Collaborators
                                  .Where
                                  (
                                       x =>
                                           x.Email.ToLower() == email.ToLower()
                                   )
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync();

      return collaborator;
    }

    public virtual async Task<Collaborator> GetByName(string name)
    {
      Collaborator collaborator = await _context
                          .Collaborators
                          .Where(c => c.Name.ToLower() == name.ToLower())
                          .AsNoTracking()
                          .FirstOrDefaultAsync();

      return collaborator;
    }

    public virtual async Task<List<Collaborator>> SearchByName(string name)
    {
      List<Collaborator> collaborators = await _context
                                            .Collaborators
                                            .Where(c => c.Name.ToLower().Contains(name.ToLower()))
                                            .AsNoTracking()
                                            .ToListAsync();

      return collaborators;
    }
  }
}
