using System;
using System.Collections.Generic;

namespace Publy.Domain.Entities
{
  public abstract class Base
  {
    public virtual Guid Id { get; private set; }
    public virtual string Name { get; private set; }

    internal List<string> _errors;
    public IReadOnlyCollection<string> Errors => _errors;

    public abstract bool Validate();
  }
}
