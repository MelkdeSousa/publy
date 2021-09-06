using System.Collections.Generic;
using Publy.Api.ViewModels;

namespace Publy.Api.Utilities
{
  public static class Responses
  {
    public static ResponseViewModel ApplicationErrorMessage()
    {
      return new ResponseViewModel
      {
        Message = "Some internal error, please try again later!",
        Success = false,
        Data = null
      };
    }

    public static ResponseViewModel DomainErrorMessage(string message)
    {
      return new ResponseViewModel
      {
        Message = message,
        Success = false,
        Data = null
      };
    }

    public static ResponseViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
    {
      return new ResponseViewModel
      {
        Message = message,
        Success = false,
        Data = null
      };
    }
  }
}
