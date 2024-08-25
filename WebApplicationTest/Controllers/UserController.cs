using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationTest.Data;
using WebApplicationTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase

    {
        private readonly MyDbContext _dbContext;

        public UserController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            var heroes = await _dbContext.SuperHeroesGroup.ToListAsync();
            return Ok(heroes);
        }

        // GET api/<UserController> For One id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeroes(int id)
        {
            var hero = await _dbContext.SuperHeroesGroup.FindAsync(id);
            if (hero == null)
            {
                return NotFound("Hero not found");
            }
            return Ok(hero);
        }


        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> AddHeroes([FromBody] SuperHero hero)
        {
            _dbContext.SuperHeroesGroup.Add(hero);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.SuperHeroesGroup.ToListAsync());
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHeroe(SuperHero updateHero)
        {
            var dbHero = await _dbContext.SuperHeroesGroup.FindAsync(updateHero.Id);
            if (dbHero == null)
            
                return NotFound("Hero not found");
                dbHero.Id = updateHero.Id;
                dbHero.Name = updateHero.Name;
                dbHero.LastName = updateHero.LastName;
                dbHero.Description = updateHero.Description;

                await _dbContext.SaveChangesAsync();
    
            return Ok(await _dbContext.SuperHeroesGroup.ToListAsync());
        }

    // DELETE api/<UserController>/5
    [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> FeleteHero(SuperHero updateHero)
        {
            var dbHero = await _dbContext.SuperHeroesGroup.FindAsync(updateHero.Id);
            if (dbHero == null)

                return NotFound("Hero not found");
           _dbContext.SuperHeroesGroup.Remove(dbHero);

            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.SuperHeroesGroup.ToListAsync());
        }
    }
}
