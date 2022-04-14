using System.Collections.Generic;
using zone.Models;

namespace zone.Controllers
{
  internal class ProfilesService
  {
    private readonly ProfilesRepository _repo;

    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }
    internal List<Profile> GetAll()
    {
      return _repo.GetAll();
    }
    internal Profile GetById(string id)
    {
      return _repo.GetById(id);
    }
    internal List<FollowViewModel> GetMyFollowings(string id)
    {
      return _repo.GetMyFollowings(id);
    }
    internal List<FollowViewModel> GetMyFollowers(string id)
    {
      return _repo.GetMyFollowers(id);
    }
  }
}