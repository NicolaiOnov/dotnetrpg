using AutoMapper;
using DotNetRpgProject.Model;
using DotNetRpgProject.Model.Dto;
using DotNetRpgProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetRpgProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;

        public CharacterController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDto>> GetCharacter(int id)
        {
            return Ok(
                _mapper.Map<CharacterDto>(
                    await _characterService.GetCharacter(id)));
        }

        [HttpGet]
        public async Task<ActionResult<List<CharacterDto>>> GetCharacters()
        {
            var characters = await _characterService.GetAllCharacters();
            return Ok(characters.Select(
                c => _mapper.Map<CharacterDto>(c)));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> CreateCharacter(Character newCharacter)
        {
            await _characterService.AddCharacter(newCharacter);

            var characters = await _characterService.GetAllCharacters();

            return Ok(characters.Select(
                c => _mapper.Map<CharacterDto>(c)));
        }
    }
}
