using DotNetRpgProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace DotNetRpgProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : Controller
    {
        private static readonly List<Character> Characters = new()
        {
            new Character{ Id = 0 },
            new Character{ Id = 1, Name = "Sam" }
        };

        [HttpGet("{id}")]
        public ActionResult<Character> GetCharacter(int id)
        {
            return Ok(Characters.SingleOrDefault(c => c.Id == id));
        }

        [HttpGet]
        public ActionResult<List<Character>> GetCharacters()
        {
            return Ok(Characters);
        }

        [HttpPost]
        public ActionResult<List<Character>> CreateCharacter(Character newCharacter)
        {
            Characters.Add(newCharacter);
            return Characters;
        }
    }
}
