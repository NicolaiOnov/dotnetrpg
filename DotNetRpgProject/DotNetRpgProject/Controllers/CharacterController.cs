using DotNetRpgProject.Model;
using DotNetRpgProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetRpgProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            return Ok(await _characterService.GetCharacter(id));
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetCharacters()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> CreateCharacter(Character newCharacter)
        {
            await _characterService.AddCharacter(newCharacter);
            return await _characterService.GetAllCharacters();
        }
    }
}
