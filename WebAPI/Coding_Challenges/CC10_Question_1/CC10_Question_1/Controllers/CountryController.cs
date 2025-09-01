using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CC10_Question_1.Models;

namespace CC10_Question_1.Controllers
{
    [RoutePrefix("api")]
    public class CountryController : ApiController
    {
        static List<Country> countrylist = new List<Country>()
        {
            new Country{Id=1, CountryName= "India", Capital="New Delhi"},
            new Country{Id=2, CountryName= "USA", Capital="Washington DC"},
            new Country{Id=3, CountryName= "France", Capital="Paris"},
        };

        [HttpGet]
        [Route("All")]
        public IEnumerable<Country> Get()
        {
            return countrylist;
        }

        [HttpGet]
        [Route("Bymsg")]
        public HttpResponseMessage GetAllCountries()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, countrylist);
            return response;
        }

        [HttpGet]
        [Route("ById")]
        public IHttpActionResult GetCountryNameById(int Id)
        {
            string name = countrylist.Where(c => c.Id == Id).SingleOrDefault()?.CountryName;

            if (name == null)
            {
                return NotFound();
            }
            return Ok(name);
        }

        [HttpPost]
        [Route("AllPost")]
        public List<Country> PostAll([FromBody] Country country)
        {
            countrylist.Add(country);
            return countrylist;
        }

        [HttpPut]
        [Route("updcountry")]
        public Country Put(int id, [FromUri] string name, string capital)
        {
            var cList = countrylist[id - 1];
            cList.Id = id;
            cList.CountryName = name;
            cList.Capital = capital;
            return cList;
        }


        [HttpPut]
        [Route("put")]
        public IEnumerable<Country> Put(int id, [FromBody] Country c)
        {
            countrylist[id - 1] = c;
            return countrylist;
        }

        [HttpDelete]
        [Route("del")]
        public IEnumerable<Country> Delete(int id)
        {
            countrylist.RemoveAt(id - 1);
            return countrylist;
        }
    }
}