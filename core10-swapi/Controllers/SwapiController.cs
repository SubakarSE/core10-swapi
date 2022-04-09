using Microsoft.AspNetCore.Mvc;
using core10_swapi.ModelBuilders;
using core10_swapi.Models;
using System.Net.Http;
using System.Net;

namespace core10_swapi.Controllers
{
    [ApiController]
    public class SwapiController : ControllerBase
    {
        private readonly  ILogger<SwapiController> _logger;
        private  readonly ISwapiModelBuilder _builder;

        public SwapiController(ILogger<SwapiController> logger, ISwapiModelBuilder builder)
        {
            _logger = logger;
            _builder = builder;
        }


        [HttpGet]
        [Route("GetStarship")]
        public async Task<Result> GetStarshipForCharacter(string name)
        {
            _logger.LogDebug($"[GetStarshipForCharacter] Get Call");
            Character characterInfo = null;
            List<Starship> lstStartshipInfo = new List<Starship>();
            Result rst = null;

            try
            {
                characterInfo = await _builder.GetCharacterBiography<Character>(name);
                if (characterInfo != null && characterInfo.count > 0 && characterInfo.results != null && characterInfo.results.Count > 0)
                {
                    foreach (var results in characterInfo.results)
                    {

                        if (results != null && results.starships != null && results.starships.Count > 0)
                        {
                            foreach (var starshipUrl in results.starships)
                            {
                                Starship shinfo = await _builder.GetStarShipDetails<Starship>(starshipUrl);
                                if (shinfo != null)
                                {
                                    lstStartshipInfo.Add(shinfo);
                                }
                            }

                        }
                        results.starshipinfo = lstStartshipInfo;
                    }

                }
                rst = new Result(HttpStatusCode.OK, lstStartshipInfo);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetStarshipForCharacter] Exception");
                rst = new Result(HttpStatusCode.InternalServerError, "");
                return rst; ;
            }
            return rst;

        }

        [HttpGet]
        [Route("GetSpeciesClassification")]
        public async Task<Result> GetClassificationForEpisode(int episode)
        {
            _logger.LogDebug($"[GetClassificationForEpisode] Get Call");
            Film filmInfo = null;
            List<Species> lstSpeciesInfo = new List<Species>();
            Result rst = null;
            try
            {
                filmInfo = await _builder.GetFilmDetails<Film>();

                foreach (var data in filmInfo.results)
                {
                    if (data.episode_id == episode)
                    {
                        foreach (var speciesurl in data.species)
                        {
                            Species speciesinfo = await _builder.GetSpeciesDetails<Species>(speciesurl);
                            if (speciesinfo != null)
                            {
                                lstSpeciesInfo.Add(speciesinfo);
                            }
                        }

                    }

                }
                rst = new Result(HttpStatusCode.OK, lstSpeciesInfo);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetStarshipForCharacter] Exception");
                rst = new Result(HttpStatusCode.InternalServerError, "");
                return rst; ;
            }
            return rst;

        }

        [HttpGet]
        [Route("GetTotalPopulation")]
        public async Task<Result> GetTotalPopulation()
        {
            _logger.LogDebug($"[GetTotalPopulation] Get Call");
            Planet planetInfo = null;
            long population = 0;
            Result rst = null;


            try
            {
                planetInfo = await _builder.GetPlanetDetails<Planet>("");
                foreach (var data in planetInfo.results)
                {
                    if (data.population != "unknown")
                    {
                        population = population + Convert.ToInt64(data.population);
                    }
                }
                while (!string.IsNullOrEmpty(planetInfo.next))
                {
                    planetInfo = await _builder.GetPlanetDetails<Planet>(planetInfo.next);
                    foreach (var data in planetInfo.results)
                    {
                        if (data.population  != "unknown") {
                            population = population + Convert.ToInt64(data.population);
                        }
                    }

                }
              
                rst = new Result(HttpStatusCode.OK, population);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetTotalPopulation] Exception");
                rst = new Result(HttpStatusCode.InternalServerError, "");
                return rst; ;
            }
            return rst;

        }




    }
}
