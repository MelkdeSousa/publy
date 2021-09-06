namespace Publy.Api.ViewModels
{
  public class ResponseViewModel
  {
    public string Message { get; set; }
    public bool Success { get; set; }
    public dynamic Data { get; set; }
  }
}
