using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs;

public class loginDto
{
  [Required]
  [EmailAddress]
  public string Email { get; set; } = null!;
  [Required]
  public string Password { get; set; } = null!;
}
