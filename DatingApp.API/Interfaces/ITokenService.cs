using System;
using DatingApp.API.Entities;

namespace DatingApp.API.Interfaces;

public interface ITokenService
{
  string CreateToken(AppUser user);
}
public interface IMemberRepository
{
  void Update(Member member);
  Task<bool> SaveAllAsync();
  Task<IReadOnlyList<Member>> GetMembersAsync();
  Task<Member?> GetMemberByIdAsync(string id);
  Task<IReadOnlyList<Photo>> GetPhotosForMemberAsync(string memberId);

}