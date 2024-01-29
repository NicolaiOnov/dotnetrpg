using DotNetRpgProject.Model;

namespace DotNetRpgProject.Services
{
    public class CharacterService : ICharacterService
    {
        private static readonly List<Character> Characters = new()
        {
            new Character{Id = 0},
            new Character{Id = 1, Name = "Sam"} 
        };

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
            Characters.Add(newCharacter);
        }
    }
}
