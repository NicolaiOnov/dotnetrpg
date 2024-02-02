using AutoMapper;
using DotNetRpgProject.Model.Dto;
using DotNetRpgProject.Model.Entity;
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
        public async Task<ActionResult<IEnumerable<CharacterDto>>> CreateCharacter(CharacterDto newCharacter)
        {
            await _characterService.AddCharacter(_mapper.Map<Character>(newCharacter));

            var characters = await _characterService.GetAllCharacters();

            return Ok(characters.Select(
                c => _mapper.Map<CharacterDto>(c)));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> UpdateCharacter(int id, CharacterDto newCharacterDto)
        {
            var newCharacter = _mapper.Map<Character>(newCharacterDto);
            newCharacter.Id = id;

            await _characterService.UpdateCharacter(newCharacter);

            var updatedCharacter = await _characterService.GetCharacter(id);

            return Ok(_mapper.Map<CharacterDto>(updatedCharacter));
        }
    }
}
