using core10_swapi.Models;

namespace core10_swapi.ModelServices
{
    public interface ISwapiServices
    {
        public Task<Character> GetCharacterBiography<Character>(string name);
        public Task<StarshipDetails> GetStarshipDetails<StarshipDetails>(string url);
    }
}
