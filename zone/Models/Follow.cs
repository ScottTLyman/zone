using System;

namespace zone.Models
{
  public class Follow : IDbItem<int>
  {
    public int Id { get; set; }
    public string FollowingId { get; set; }
    public string FollowerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}