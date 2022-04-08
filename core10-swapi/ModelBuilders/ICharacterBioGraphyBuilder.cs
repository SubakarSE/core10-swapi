namespace core10_swapi.ModelBuilders
{
    public interface ICharacterBiographyBuilder
    {
        public Task<Character> GetCharacterBiography<Character>(String actor);
        public Task<StarshipDetails> GetStarShipDetails<StarshipDetails>(string url);
    }
}
