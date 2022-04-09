using core10_swapi.Models;
using core10_swapi.ModelServices;

namespace core10_swapi.ModelBuilders
{
    public class CharacterGraphyBuilder : ICharacterBiographyBuilder
    {
        ISwapiServices _actorService;
        private readonly ILogger<CharacterGraphyBuilder> _logger;

        public CharacterGraphyBuilder(ISwapiServices actorService, ILogger<CharacterGraphyBuilder> logger)
        {
            _actorService = actorService;
            _logger = logger;
        }
        public Task<Character> GetCharacterBiography<Character>(string name)
        {
            _logger.LogDebug($"[GetCharacterBiography] GetCharacterBiography");
            try
            {
                Task<Character> actorInfo = _actorService.GetCharacterBiography<Character>(name);
                return actorInfo;

            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetCharacterBiography] GetCharacterBiography exception: {Newtonsoft.Json.JsonConvert.SerializeObject(ex)}");
                throw ex;
            }
            
        }

        public Task<StarshipDetails> GetStarShipDetails<StarshipDetails>(string url)
        {
            _logger.LogDebug($"[GetStarShipDetails] GetStarShipDetails");
            try
            {
                Task<StarshipDetails> actorInfo = _actorService.GetStarshipDetails<StarshipDetails>(url);
                return actorInfo;

            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetStarShipDetails] GetStarShipDetails exception: {Newtonsoft.Json.JsonConvert.SerializeObject(ex)}");
                throw ex;
            }
        }

        public Task<Film> GetFilmDetails<Film>()
        {
            _logger.LogDebug($"[GetFilmDetails] GetFilmDetails");
            try
            {
                Task<Film> filmInfo = _actorService.GetFilmDetails<Film>();
                return filmInfo;

            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetFilmDetails] GetFilmDetails exception: {Newtonsoft.Json.JsonConvert.SerializeObject(ex)}");
                throw ex;
            }
        }

        public Task<Species> GetSpeciesDetails<Species>(string url)
        {
            _logger.LogDebug($"[GetSpeciesDetails] GetSpeciesDetails");
            try
            {
                Task<Species> actorInfo = _actorService.GetSpeciesDetails<Species>(url);
                return actorInfo;

            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetSpeciesDetails] GetSpeciesDetails exception: {Newtonsoft.Json.JsonConvert.SerializeObject(ex)}");
                throw ex;
            }
        }

        public Task<Planet> GetPlanetDetails<Planet>(string url)
        {
            _logger.LogDebug($"[GetPlanetDetails] GetPlanetDetails");
            try
            {
                Task<Planet> planetInfo = _actorService.GetPlanetDetails<Planet>(url);
                return planetInfo;

            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetPlanetDetails] GetPlanetDetails exception: {Newtonsoft.Json.JsonConvert.SerializeObject(ex)}");
                throw ex;
            }
        }
    }
}
