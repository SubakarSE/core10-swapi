using core10_swapi.Constants;
using core10_swapi.Helper;
using core10_swapi.Models;

namespace core10_swapi.ModelServices
{
    public class SwapiServices : ISwapiServices
    {
        private readonly ILogger<SwapiServices> _logger;

        private bool disposedValue = false;

        public SwapiServices(ILogger<SwapiServices> logger)
        {
            
            _logger = logger;
        }

        

        public Task<Character> GetCharacterBiography<Character>(string name)
        {
            _logger.LogDebug($"[GetCharacterBiography] GetCharacterBiography");
            try
            {
                string url = CommonConstants.base_url + "people/?search=";
                APIHelper helper = new APIHelper();
                Task<Character> actorInfo = helper.DataRequest<Character>(CommonConstants.HTTP_GET, null, url + name, string.Empty);
                return actorInfo;
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetCharacterBiography] GetCharacterBiography Exception : {Newtonsoft.Json.JsonConvert.SerializeObject(ex)}");
                throw ex;
            }
        }

        public Task<Film> GetFilmDetails<Film>()
        {
            _logger.LogDebug($"[GetFilmDetails] GetFilmDetails");
            try
            {
                string url = CommonConstants.base_url + "films/";
                APIHelper helper = new APIHelper();
                Task<Film> filmInfo = helper.DataRequest<Film>(CommonConstants.HTTP_GET, null, url, string.Empty);
                
                return filmInfo;
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetFilmDetails] GetFilmDetails Exception : {Newtonsoft.Json.JsonConvert.SerializeObject(ex)}");
                throw ex;
            }
        }


        public Task<Planet> GetPlanetDetails<Planet>(string url)
        {
            _logger.LogDebug($"[GetPlanetDetails] GetPlanetDetails");
            try
            {
                if (string.IsNullOrEmpty(url)) {
                    url = CommonConstants.base_url + "planets/";
                }
                APIHelper helper = new APIHelper();
                Task<Planet> planetDetails = helper.DataRequest<Planet>(CommonConstants.HTTP_GET, null, url, string.Empty);
                return planetDetails;
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetPlanetDetails] GetPlanetDetails Exception : {Newtonsoft.Json.JsonConvert.SerializeObject(ex)}");
                throw ex;
            }
        }

        public Task<Species> GetSpeciesDetails<Species>(string url)
        {
            _logger.LogDebug($"[GetSpeciesDetails] GetSpeciesDetails");
            try
            {
                APIHelper helper = new APIHelper();
                Task<Species> speciesDetails = helper.DataRequest<Species>(CommonConstants.HTTP_GET, null, url, string.Empty);
                return speciesDetails;
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetSpeciesDetails] GetSpeciesDetails Exception : {Newtonsoft.Json.JsonConvert.SerializeObject(ex)}");
                throw ex;
            }
        }

        public Task<StarshipDetails> GetStarshipDetails<StarshipDetails>(string url)
        {
            _logger.LogDebug($"[GetStarshipDetails] GetStarshipDetails");
            try
            {
                APIHelper helper = new APIHelper();
                Task<StarshipDetails> vehicleDetails = helper.DataRequest<StarshipDetails>(CommonConstants.HTTP_GET, null, url, string.Empty);
                return vehicleDetails;
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetStarshipDetails] GetStarshipDetails Exception : {Newtonsoft.Json.JsonConvert.SerializeObject(ex)}");
                throw ex;
            }
        }

        

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Implement in MVP2
                }               
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
