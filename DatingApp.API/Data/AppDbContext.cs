using System;
using DatingApp.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  public DbSet<AppUser> Users { get; set; }
  public DbSet<Photo> Photos { get; set; }
  public DbSet<Member> Members { get; set; }

}
