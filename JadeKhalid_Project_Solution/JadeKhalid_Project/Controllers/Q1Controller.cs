using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace JadeKhalid_Project.Controllers
{
    public class Q1Controller : ApiController
    {
        /* User inputs a country. Receives their HDI rank, FSI rank, 
         * and one highest-valued indicator and one lowest-valued 
         * indicators? Or just all the indicators. */

        SfiHdiEntitiesConnection myCollection = new SfiHdiEntitiesConnection();
        List<DataController.SfiDto> mySfi = new List<DataController.SfiDto>();
        List<DataController.HdiDto> myHdi = new List<DataController.HdiDto>();
        List<DataController.CountryDto> myCountries = new List<DataController.CountryDto>();

        public IHttpActionResult GetCountries()
        {

            foreach (Country c in myCollection.Countries)
            {
                // get all countries
                DataController.CountryDto myCountry = new DataController.CountryDto(c.CountryID, c.countryName);
                foreach (SFI f in myCollection.SFIs)
                {
                    // cycle through to ensure there aren't any countries that don't have sfi or hdi info
                    if (f.countryID == c.CountryID)
                    {
                        myCountries.Add(myCountry);
                    }
                }
            }
            return Json(myCountries);
        }

        // Rework this so that it returns sum total sales rather than a list of them.
        public IHttpActionResult GetDataByCountry(int id)
        {
            int thisHdiID = 0;
            double thisHdiScore = 0;

            int thisSfiID = 0;
            double thisSfiTotal = 0;
            int thisIndicatorsID = 0;

            double thisSfiSec = 0;
            double thisSfiFaction = 0;
            double thisSfiGgriev = 0;
            double thisSfiEcon = 0;
            double thisSfiEcIneq = 0;
            double thisSfiHFlight = 0;
            double thisSfiSLegit = 0;
            double thisSfiPub = 0;
            double thisSfiRights = 0;
            double thisSfiDem = 0;
            double thisSfiRef = 0;
            double thisSfiExtInt = 0;

            foreach (HDI h in myCollection.HDIs)
            {
                if (h.countryID == id)
                {
                    thisHdiID = h.hdiID;
                    thisHdiScore = h.hdiScore;
                }
            }

            // get data for selected country
            foreach (SFI s in myCollection.SFIs)
            {
                if (s.countryID == id)
                {
                    thisSfiID = s.sfiID;
                    thisSfiTotal = s.sfiTotal;
                    thisIndicatorsID = s.indicatorsID;
                }
            }

            foreach (Indicator ind in myCollection.Indicators)
            {
                if (ind.indicatorsID == thisIndicatorsID)
                {
                    thisSfiSec = ind.sfiSec;
                    thisSfiFaction = ind.sfiFaction;
                    thisSfiGgriev = ind.sfiGgriev;
                    thisSfiEcon = ind.sfiEcon;
                    thisSfiEcIneq = ind.sfiEcIneq;
                    thisSfiHFlight = ind.sfihFlight;
                    thisSfiSLegit = ind.sfisLegit;
                    thisSfiPub = ind.sfiPub;
                    thisSfiRights = ind.sfiRights;
                    thisSfiDem = ind.sfiDem;
                    thisSfiRef = ind.sfiRef;
                    thisSfiExtInt = ind.sfiExtInt;
                }
            }

            RelatedData myResult = new RelatedData(thisHdiID, thisHdiScore, thisSfiID, thisSfiTotal, thisSfiSec, thisSfiFaction, thisSfiGgriev,
                 thisSfiEcon, thisSfiEcIneq, thisSfiHFlight, thisSfiSLegit, thisSfiPub, thisSfiRights, thisSfiDem, thisSfiRef,
                 thisSfiExtInt);

            return Json(myResult);
        }
    }

    public class RelatedData {
        public RelatedData(int rHdiID, double rHdiScore, int rSfiID, double rSfiTotal, double rSfiSec,
                double rSfiFaction, double rSfiGgriev, double rSfiEcon, double rSfiEcIneq, double rSfiHFlight,
                double rSfiSLegit, double rSfiPub, double rSfiRights, double rSfiDem, double rSfiRef, double rSfiExtInt)
        {
            myHdiRank = rHdiID;
            myHdiScore = rHdiScore;

            mySfiRank = rSfiID;
            mySfiScore = rSfiTotal;

            mySfiSec = rSfiSec;
            mySfiFaction = rSfiFaction;
            mySfiGgriev = rSfiGgriev;
            mySfiEcon = rSfiEcon;
            mySfiEcIneq = rSfiEcIneq;
            mySfiHFlight = rSfiHFlight;
            mySfiSLegit = rSfiSLegit;
            mySfiPub = rSfiPub;
            mySfiRights = rSfiRights;
            mySfiDem = rSfiDem;
            mySfiRef = rSfiRef;
            mySfiExtInt = rSfiExtInt;
        }
        public int myHdiRank { get; set; }
        public double myHdiScore { get; set; }

        public int mySfiRank { get; set; }
        public double mySfiScore { get; set; }

        public double mySfiSec { get; set; }
        public double mySfiFaction { get; set; }
        public double mySfiGgriev { get; set; }
        public double mySfiEcon { get; set; }
        public double mySfiEcIneq { get; set; }
        public double mySfiHFlight { get; set; }
        public double mySfiSLegit { get; set; }
        public double mySfiPub { get; set; }
        public double mySfiRights { get; set; }
        public double mySfiDem { get; set; }
        public double mySfiRef { get; set; }
        public double mySfiExtInt { get; set; }
    }

}
