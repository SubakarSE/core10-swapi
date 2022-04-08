using Microsoft.AspNetCore.Mvc;
using core10_swapi.ModelBuilders;
using core10_swapi.Models;

namespace core10_swapi.Controllers
{
    [ApiController]
    public class SwapiController : ControllerBase
    {
        private readonly  ILogger<SwapiController> _logger;
        private  readonly ICharacterBiographyBuilder _builder;

        public SwapiController(ILogger<SwapiController> logger, ICharacterBiographyBuilder builder)
        {
            _logger = logger;
            _builder = builder;
        }
        [HttpGet]
        [Route("GetStarship")]
        public async Task<List<Starship>> GetStarshipForCharacter(string actor)
        {
            _logger.LogDebug($"[GetStarshipForCharacter] Get Call");
            Character actorInfo = null;
            List<Starship> lstStartshipInfo = new List<Starship>();
            try
            {
                actorInfo = await _builder.GetCharacterBiography<Character>(actor);
                if (actorInfo != null && actorInfo.count >0 && actorInfo.results != null && actorInfo.results.Count >0)
                {
                    foreach (var results in actorInfo.results)
                    {
                        
                        if (results != null && results.starships != null && results.starships.Count >0)
                        {   
                            foreach(var starshipUrl in results.starships)
                            {
                                Starship vhinfo = await _builder.GetStarShipDetails<Starship>(starshipUrl);
                                if(vhinfo != null)
                                {
                                    lstStartshipInfo.Add(vhinfo);
                                }
                            }

                        }
                        results.starshipinfo = lstStartshipInfo;
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetStarshipForCharacter] Exception");
                throw ex;
            }
            return lstStartshipInfo;

        }
        
    }
}
