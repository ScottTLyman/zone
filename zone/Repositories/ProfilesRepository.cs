using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using zone.Models;

namespace zone.Controllers
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal List<Profile> GetAll()
    {
      string sql = @"
      SELECT *
      FROM accounts
      ";
      return _db.Query<Profile>(sql).ToList();
    }

    internal Profile GetById(string id)
    {
      string sql = @"
      SELECT *
      FROM accounts
      WHERE id = @id
      ";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }


  }
}