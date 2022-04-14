using System.Data;
using Dapper;
using zone.Models;

namespace zone.Repositories
{
  public class FollowsRepository
  {
    private readonly IDbConnection _db;
    public FollowsRepository(IDbConnection db)
    {
      _db = db;
    }
    public Follow Create(Follow followData)
    {
      string sql = @"
            INSERT INTO follows
            (followingId, followerId)
            VALUES
            (@FollowingId, @FollowerId);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, followData);
      followData.Id = id;
      return followData;
    }
    public void Delete(int id)
    {
      string sql = "DELETE FROM follows WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
    internal Follow GetById(int id)
    {
      string sql = @"
      SELECT *
      FROM follows
      WHERE id = @id
      ";
      return _db.QueryFirstOrDefault<Follow>(sql, new { id });
    }
    internal List<FollowViewModel> GetMyFollowings(string id)
    {
      string sql = @"
      SELECT
      a.*
      f.id AS FollowId
      FROM follows f
      JOIN accounts a ON a.id = f.followingId
      WHERE f.followerId = @id
      ";
      return _db.Query<FollowViewModel>(sql, new { id }).ToList();
    }

    internal List<FollowViewModel> GetMyFollowers(string id)
    {
      string sql = @"
      SELECT
      a.*
      f.id AS FollowId
      FROM follows f
      JOIN accounts a ON a.id = f.followerId
      WHERE f.followingId = @id
      ";
      return _db.Query<FollowViewModel>(sql, new { id }).ToList();
    }
  }
}