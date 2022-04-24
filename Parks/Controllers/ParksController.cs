using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksApi.Models;
using System.Linq;
using System;
using ParksApi.Infrastructure.BasicAuth;
using Microsoft.AspNetCore.Authorization;



namespace ParksApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParksApiContext _db;

    public ParksController(ParksApiContext db)
    {
      _db = db;
    }
    /// <summary>
    /// Pulls a list of all Parks based on certain search parameters including 'name', 'size', and/or 'country'
    /// </summary>
    // GET api/parks
    //http://localhost:5001/api/parks?name=Etosha
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string name, int size, string country)
    {
      var query = _db.Parks.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (size > 0)
      {
        query = query.Where(entry => entry.Size == size);
      }

      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }

      return await query.ToListAsync();
    }

    // GET: api/Parks/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      var park = await _db.Parks.FindAsync(id);

      if (park == null)
      {
          return NotFound();
      }
      return park;
    }

//https://localhost:5001/api/Parks/LargestPark
    [HttpGet("LargestPark")]
    public async Task<ActionResult<IEnumerable<Park>>> GetLargestPark()
    {
      var query = _db.Parks.AsQueryable();
      var largestPark = _db.Parks.Max(park => park.Size);
      query = query.Where(park => park.Size == largestPark);
      return await query.ToListAsync();
    }

   // https://localhost:5001/api/Parks/SortByCountry
    [HttpGet("SortByCountry")]
    public async Task<ActionResult<IEnumerable<Park>>> SortByCountry()
    {
      // returns a list of parks sorted by Country
      var query = _db.Parks.AsQueryable();
      query = query.OrderByDescending(park => park.Country);
      return await query.ToListAsync();
    }

    [HttpGet("MostParks")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Park>>> GetMostParks()
    {
      var listPark = await _db.Parks.ToListAsync();
      var groupedParks = listPark.GroupBy(park => park.Country);
      string highestCountry = "";
      var highestCount = 0;
      foreach (var countryGroup in groupedParks)
      {
        var counter = 0;
        foreach(Park park in countryGroup)
        {
          counter++;
        }

        if (counter >= highestCount)
        {
          highestCount = counter;
          highestCountry = countryGroup.Key;
        }
      }
      var returnPark = listPark.Where(park => park.Country == highestCountry).ToList();
      return (returnPark);
    }

    // POST api/Parks
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }

    // PUT: api/Parks/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }
      _db.Entry(park).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    // DELETE: api/Parks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      var park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }
      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }

  }
}