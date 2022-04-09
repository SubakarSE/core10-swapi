namespace core10_swapi.ModelBuilders
{
    public interface ICharacterBiographyBuilder
    {
        public Task<Character> GetCharacterBiography<Character>(String actor);
        public Task<StarshipDetails> GetStarShipDetails<StarshipDetails>(string url);

        public Task<Film> GetFilmDetails<Film>();
        public Task<Species> GetSpeciesDetails<Species>(string url);

        public Task<Planet> GetPlanetDetails<Planet>(string url);

    }
}
