using AutoMapper;
using DotNetRpgProject.Model.Entity;

namespace DotNetRpgProject.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;

        private static readonly List<Character> Characters = new()
        {
            new Character{ Id = 0 },
            new Character{ Id = 1, Name = "Sam" } 
        };

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Character> GetCharacter(int id)
        {
            return Characters.SingleOrDefault(c => c.Id == id) 
                   ?? throw new Exception("CharacterDto not found");
        }

        public async Task<List<Character>> GetAllCharacters()
        {
            return Characters;
        }

        public async Task AddCharacter(Character newCharacter)
        {
            newCharacter.Id = Characters.Max(c => c.Id) + 1;
            Characters.Add(newCharacter);
        }

        public async Task UpdateCharacter(Character updatedCharacter)
        {
            var oldCharacter = Characters.Find(c => c.Id == updatedCharacter.Id) 
                               ?? throw new Exception("Character with provided ID was not found") ;
            _mapper.Map(updatedCharacter, oldCharacter);
        }
    }
}
