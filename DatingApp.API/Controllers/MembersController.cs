using DatingApp.API.Data;
using DatingApp.API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers;

public class MembersController(AppDbContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
    {
        var users = await context.Users.ToListAsync();
        return Ok(users);
    }
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<AppUser>> GetMember(string id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null) return NotFound();

        return Ok(user);
    }
}

