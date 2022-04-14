using System;

namespace zone.Models
{
  public class Profile : IDbItem<string>
  {
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; }
    public string Picture { get; set; }
  }
  public class FollowViewModel : Profile
  {
    public int FollowId { get; set; }
  }
}