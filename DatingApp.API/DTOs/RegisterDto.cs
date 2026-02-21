using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs;

public class RegisterDto
{
  [Required]
  public string DisplayName { get; set; } = null!;
  [Required]
  [EmailAddress]
  public string Email { get; set; } = null!;
  [Required]
  [MinLength(4)]
  public string Password { get; set; } = null!;
}
public class loginDto
{
  [Required]
  [EmailAddress]
  public string Email { get; set; } = null!;
  [Required]
  public string Password { get; set; } = null!;
}
public class UserDto
{
  public required string Id { get; set; } = null!;
  public required string Email { get; set; } = null!;
  public required string DisplayName { get; set; } = null!;
  public string? ImageUrl { get; set; }
  public required string Token { get; set; } = null!;

}
