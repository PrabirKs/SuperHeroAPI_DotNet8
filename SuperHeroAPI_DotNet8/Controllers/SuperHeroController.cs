using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Data;
using SuperHeroAPI_DotNet8.Entities;

namespace SuperHeroAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // for http respones like 200,400 etc
    public class SuperHeroController : ControllerBase
    {

        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _context.Superheroes.ToListAsync();

            return Ok(heroes);
        }
        [HttpGet("{id}")]
      //  [Route("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _context.Superheroes.FindAsync(id);
            if(hero is null)
            {
                return NotFound("id does not match");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult> AddHero(SuperHero hero)
        {
            _context.Superheroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Superheroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero updatedHero)
        {
            var hero = await _context.Superheroes.FindAsync(updatedHero.Id);

            if(hero is null)
            {
                return NotFound("hero not found with this id");
            }
            else
            {
                hero.Name = updatedHero.Name;
                hero.FirstName = updatedHero.FirstName;
                hero.LastName = updatedHero.LastName;   
                hero.Place = updatedHero.Place;

                await _context.SaveChangesAsync();

                return Ok(await _context.Superheroes.ToListAsync());
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = await _context.Superheroes.FindAsync(id);

            if (hero is null)
            {
                return NotFound("hero not found with this id");
            }
            else
            {
                _context.Superheroes.Remove(hero);
                await _context.SaveChangesAsync();

                return Ok(await _context.Superheroes.ToListAsync());
            }
        }
    }
}
