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
        private  readonly ICharacterBiographyBuilder _builder;

        public SwapiController(ILogger<SwapiController> logger, ICharacterBiographyBuilder builder)
        {
            _logger = logger;
            _builder = builder;
        }
        [HttpGet]
        [Route("GetClassification")]
        public async Task<List<Species>> GetClassificationForEpisode(int episode)
        {
            _logger.LogDebug($"[GetClassificationForEpisode] Get Call");
            Film filmInfo = null;
            List<Species> lstSpeciesInfo = new List<Species>();
            try
            {
                filmInfo = await _builder.GetFilmDetails<Film>();
                
                foreach (var data in filmInfo.results)
                {
                    if(data.episode_id == episode)
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
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetStarshipForCharacter] Exception");
                throw ex;
            }
            return lstSpeciesInfo;

        }

        [HttpGet]
        [Route("GetStarship")]
        public async Task<List<Starship>> GetStarshipForCharacter(string name)
        {
            _logger.LogDebug($"[GetStarshipForCharacter] Get Call");
            Character characterInfo = null;
            List<Starship> lstStartshipInfo = new List<Starship>();
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
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetStarshipForCharacter] Exception");
                throw ex;
            }
            return lstStartshipInfo;

        }

        [HttpGet]
        [Route("GetTotalPopulation")]
        public async Task<Result> GetTotalPopulation()
        {
            _logger.LogDebug($"[GetTotalPopulation] Get Call");
            Planet planetInfo = null;
            long population = 0;
            Result rst = new Result();


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
                rst.result = population;
                rst.status = HttpStatusCode.OK;
                rst.message = "Sucess";
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"[GetTotalPopulation] Exception");
                throw ex;
            }
            return rst;

        }




    }
}
