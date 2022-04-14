using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using zone.Models;
using zone.Services;

namespace zone.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;
    private readonly FollowsService _fs;

    public ProfilesController(ProfilesService ps, FollowsService fs)
    {
      _ps = ps;
      _fs = fs;
    }
    [HttpGet]
    public ActionResult<List<Profile>> GetAll()
    {
      try
      {
        List<Profile> profiles = _ps.GetAll();
        return Ok(profiles);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Profile> GetById(string id)
    {
      try
      {
        Profile profile = _ps.GetById(id);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}