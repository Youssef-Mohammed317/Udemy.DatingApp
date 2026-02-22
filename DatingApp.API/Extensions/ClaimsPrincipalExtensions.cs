using System;
using System.Security.Claims;

namespace DatingApp.API.Extensions;

public static class ClaimsPrincipalExtensions
{
  public static string GetMemberId(this ClaimsPrincipal user)
  {
    return user.FindFirst(ClaimTypes.NameIdentifier)?.Value
      ?? throw new Exception("Could not get member id");

  }
}
