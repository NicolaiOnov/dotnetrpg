using DotNetRpgProject.Model;

namespace DotNetRpgProject.Services
{
    public interface ICharacterService
    {
        Task<Character> GetCharacter(int id);
        Task <List<Character>> GetAllCharacters();
        Task AddCharacter(Character newCharacter);
    }
}
