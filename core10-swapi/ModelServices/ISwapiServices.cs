using core10_swapi.Models;

namespace core10_swapi.ModelServices
{
    public interface ISwapiServices : IDisposable
    {
        public Task<Character> GetCharacterBiography<Character>(string name);
        public Task<Starship> GetStarshipDetails<Starship>(string url);

        public Task<Film> GetFilmDetails<Film>();
        public Task<Species> GetSpeciesDetails<Species>(string url);

        public Task<Planet> GetPlanetDetails<Planet>(string url);

    }
}
