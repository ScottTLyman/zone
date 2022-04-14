using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zone.Models;
using zone.Services;

namespace zone.Controllers
{
  [ApiController]
  [Authorize]
  [Route("api/[controller]")]
  public class FollowsController : ControllerBase
  {
    private readonly FollowsService _fs;

    public FollowsController(FollowsService fs)
    {
      _fs = fs;
    }
    // CREATE FOLLOW
    [HttpPost]
    public async Task<ActionResult<Follow>> Create([FromBody] Follow followData)
    {
      try
      {
        Account user = await HttpContext.GetUserInfoAsync<Account>();
        followData.FollowerId = user.Id;
        Follow created = _fs.Create(followData);
        return Ok(created);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Account user = await HttpContext.GetUserInfoAsync<Account>();
        _fs.Delete(id, user.Id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}