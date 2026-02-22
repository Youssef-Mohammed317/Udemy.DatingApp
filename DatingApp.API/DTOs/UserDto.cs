namespace DatingApp.API.DTOs;

public class UserDto
{
  public required string Id { get; set; } = null!;
  public required string Email { get; set; } = null!;
  public required string DisplayName { get; set; } = null!;
  public string? ImageUrl { get; set; }
  public required string Token { get; set; } = null!;

}
