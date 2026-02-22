using DatingApp.API.Data;
using DatingApp.API.Entities;
using DatingApp.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers;

[Authorize]
public class MembersController(IMemberRepository memberRepo) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Member>>> GetMembers()
    {
        var users = await memberRepo.GetMembersAsync();
        return Ok(users);
    }
    [HttpGet("{id}")]

    public async Task<ActionResult<Member>> GetMember(string id)
    {
        var user = await memberRepo.GetMemberByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }
    [HttpGet("{id}/photos")]
    public async Task<ActionResult<IReadOnlyList<Photo>>> GetPhotosForMember(string id)
    {
        var photos = await memberRepo.GetPhotosForMemberAsync(id);
        return Ok(photos);
    }
}

