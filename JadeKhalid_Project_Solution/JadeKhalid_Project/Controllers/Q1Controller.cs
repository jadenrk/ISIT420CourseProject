using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JadeKhalid_Project.Controllers
{
    public class Q1Controller : ApiController
    {
        /* User inputs a country. Receives their HDI rank, FSI rank, 
         * and one highest-valued indicator and one lowest-valued 
         * indicators? Or just all the indicators. */

        SfiHdiEntitiesConnection myCollection = new SfiHdiEntitiesConnection();
        List<CountryDto> myCountries = new List<CountryDto>();

        public IHttpActionResult GetCountries()
        {
            foreach (Country c in myCollection.Countries)
            {
                // get all countries
                CountryDto myCountry = new CountryDto(c.CountryID, c.countryName);
                myCountries.Add(myCountry);
                // cycle through to ensure there aren't any countries that don't have sfi or hdi info
            }

            return Json(myCountries);
        }

        // Rework this so that it returns sum total sales rather than a list of them.
        public IHttpActionResult GetDataByCountry(int id)
        {
            // get data for selected country

            // dummy return in the meantime
            string a = "something";
            return Json(a);
        }
    }
    public class CountryDto
    {
        public CountryDto(int pCountryID, string pCountryName)
        {
            dtoCountryID = pCountryID;
            dtoCountryName = pCountryName;
        }
        public int dtoCountryID { get; set; }
        public string dtoCountryName { get; set; }
        //public ICollection<HDI> dtoHdi { get; set; }
        //public ICollection<SFI> dtoSfi { get; set; }
    }
}
