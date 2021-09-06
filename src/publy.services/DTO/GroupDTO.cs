using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Publy.Domain.Entities;

namespace Publy.Services.DTO
{
  public class GroupDTO
  {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public GroupDTO()
    { }

    public GroupDTO(Guid id, string name)
    {
      Id = id;
      Name = name;
    }
  }
}
