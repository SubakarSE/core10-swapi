using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core10_swapi.Models;

namespace core10_swapi_test.MockData
{
    public static class CharacterMockData
    {
        public static Task<Character> GetCharacterResponse()
        {
            var result = Task<Character>.FromResult<Character>(new Character()
            {
                results = new List<core10_swapi.Models.Biography>()
                {
                    new Biography()
                    {
                            name= "Luke Skywalker",
                            height = "172",
                            mass = "77",
                            hair_color = "blond",
                            skin_color = "fair",
                            eye_color = "blue",
                            birth_year = "19BBY",
                            gender = "male",
                            homeworld = "https://swapi.dev/api/planets/1/",
                            films = new List<string>() {
                                "https://swapi.dev/api/films/1/",
                                "https://swapi.dev/api/films/2/",
                                "https://swapi.dev/api/films/3/",
                                "https://swapi.dev/api/films/6/"
                            },
                            species = new List<object>() { },
                            vehicles = new List<string>() {
                                "https://swapi.dev/api/vehicles/14/",
                                "https://swapi.dev/api/vehicles/30/"
                            },
                            starships = new List<string>() {
                                "https://swapi.dev/api/starships/12/",
                                "https://swapi.dev/api/starships/22/"
                            },
                            created = DateTime.Parse("2014-12-09T13:50:51.644000Z"),
                            edited = DateTime.Parse("2014-12-20T21:17:56.891000Z"),
                            url = "https://swapi.dev/api/people/1/"
                    }
                 },
                count = 1
            }); ;
                return result;
              }  
       
    }
}
