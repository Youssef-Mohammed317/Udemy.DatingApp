using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using DatingApp.API.DTOs;
using DatingApp.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data;

public class Seed
{
  public static async Task SeedUsersAsync(AppDbContext context)
  {

    if (await context.Users.AnyAsync()) return;

    var memberData = await File.ReadAllTextAsync("Data/UserSeedData.json");
    var members = JsonSerializer.Deserialize<List<SeedUserDto>>(memberData);

    if (members == null)
    {
      Console.WriteLine("No members to seed");
      return;
    }

    foreach (var member in members)
    {
      using var hmac = new HMACSHA512();

      var user = new AppUser
      {
        Id = member.Id,
        Email = member.Email,
        DisplayName = member.DisplayName,
        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd")),
        PasswordSalt = hmac.Key,
        Member = new Member
        {
          Id = member.Id,
          City = member.City,
          Country = member.Country,
          DateOfBirth = member.DateOfBirth,
          Description = member.Description,
          Gender = member.Gender,
          ImageUrl = member.ImageUrl,
          DisplayName = member.DisplayName,
          Created = member.Created,
          LastActive = member.LastActive
        }
      };
      user.Member.Photos.Add(new Photo
      {
        Url = member.ImageUrl!,
        MemberId = member.Id
      });
      context.Users.Add(user);

    }
    await context.SaveChangesAsync();

  }

}
