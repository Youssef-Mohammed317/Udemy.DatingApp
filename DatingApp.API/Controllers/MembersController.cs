using System.Security.Claims;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using DatingApp.API.Entities;
using DatingApp.API.Extensions;
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
    [HttpPut]
    public async Task<ActionResult> UpdateMember(MemberUpdateDto memberUpdateDto)
    {
        var memberId = User.GetMemberId();


        var member = await memberRepo.GetMemberForUpdateAsync(memberId);

        if (member == null)
            return BadRequest("Could not get member");

        member.City = memberUpdateDto.City ?? member.City;
        member.Country = memberUpdateDto.Country ?? member.Country;
        member.DisplayName = memberUpdateDto.DisplayName ?? member.DisplayName;
        member.Description = memberUpdateDto.Description ?? member.Description;

        member.User.DisplayName = memberUpdateDto.DisplayName ?? member.User.DisplayName;

        memberRepo.Update(member);

        if (await memberRepo.SaveAllAsync())
        {
            return NoContent();
        }

        return BadRequest("Failed to update member");
    }

}

