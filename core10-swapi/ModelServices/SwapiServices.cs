using core10_swapi.Constants;
using core10_swapi.Helper;
using core10_swapi.Models;

namespace core10_swapi.ModelServices
{
    public class SwapiServices : ISwapiServices
    {
        private readonly ILogger<SwapiServices> _logger;

        public SwapiServices(ILogger<SwapiServices> logger)
        {
            
            _logger = logger;
        }
        public Task<Character> GetCharacterBiography<Character>(string name)
        {
            _logger.LogDebug($"[GetCharacterBiography] GetCharacterBiography");
            try
            {
                APIHelper helper = new APIHelper();
                Task<Character> actorInfo = helper.DataRequest<Character>(CommonConstants.HTTP_GET, null, ActorConstant.ACTOR_BIOGRAPHY_URL + name, string.Empty);
                return actorInfo;
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetCharacterBiography] GetCharacterBiography Exception : {Newtonsoft.Json.JsonConvert.SerializeObject(ex)}");
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
    }
}
