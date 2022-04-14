using System;
using zone.Models;
using zone.Repositories;

namespace zone.Services
{
  public class FollowsService
  {
    private readonly FollowsRepository _repo;

    public FollowsService(FollowsRepository repo)
    {
      _repo = repo;
    }
    private Follow GetById(int id)
    {
      Follow found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    // Get My Follows
    internal Follow Create(Follow followData)
    {
      Follow exists = _repo.GetMyFollows(followData.FollowingId);
      if (exists != null)
      {
        return exists;
      }
      return _repo.Create(followData);
    }
    internal void Delete(int followId, string userId)
    {
      Follow found = GetById(followId);
      if (found.FollowerId != userId)
      {
        throw new Exception("You cannot delete this");
      }
      _repo.Delete(followId);
    }
  }
}