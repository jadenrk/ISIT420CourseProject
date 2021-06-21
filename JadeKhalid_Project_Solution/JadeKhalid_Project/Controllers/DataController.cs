using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JadeKhalid_Project.Controllers
{
    public class DataController : ApiController
    {
        SfiHdiEntitiesConnection myCollection = new SfiHdiEntitiesConnection();

        public class CountryDto
        {
            public CountryDto(int pCountryID, string pCountryName)
            {
                dtoCountryID = pCountryID;
                dtoCountryName = pCountryName;
                // dtoHdi = pHdi;
                // dtoSfi = pSfi;
            }
            public int dtoCountryID { get; set; }
            public string dtoCountryName { get; set; }
            // public ICollection<HdiDto> dtoHdi { get; set; }
            // public ICollection<SfiDto> dtoSfi { get; set; }
        }
        public class HdiDto
        {
            public HdiDto(int pHdiID, int pCountryID, double pHdiScore)
            {
                dtoHdiID = pHdiID;
                dtoCountryID = pCountryID;
                dtoHdiScore = pHdiScore;
            }
            public int dtoHdiID { get; set; }
            public int dtoCountryID { get; set; }
            public double dtoHdiScore { get; set; }
        }
        public class SfiDto
        {
            public SfiDto(int pSfiID, int pCountryID, double pSfiTotal, int pIndicatorsID)
            {
                dtoSfiID = pSfiID;
                dtoCountryID = pCountryID;
                dtoSfiTotal = pSfiTotal;
                dtoIndicatorsID = pIndicatorsID;
            }
            public int dtoSfiID { get; set; }
            public int dtoCountryID { get; set; }
            public double dtoSfiTotal { get; set; }
            public int dtoIndicatorsID { get; set; }
        }
        public class IndicatorDto
        {
            public IndicatorDto(int pIndicatorsID, int pSfiID, double pSfiTotal, double pSfiSec, double pSfiFaction, 
                double pSfiGgriev, double pSfiEcon, double pSfiEcIneq, double pSfiHFlight, double pSfiSLegit, 
                double pSfiPub, double pSfiRights, double pSfiDem, double pSfiRef, double pSfiExtInt)
            {
                dtoIndicatorsID = pIndicatorsID;
                dtoSfiID = pSfiID;
                dtoSfiTotal = pSfiTotal;
                dtoSfiSec = pSfiSec;
                dtoSfiFaction = pSfiFaction;
                dtoSfiGgriev = pSfiGgriev;
                dtoSfiEcon = pSfiEcon;
                dtoSfiEcIneq = pSfiEcIneq;
                dtoSfiHFlight = pSfiHFlight;
                dtoSfiSLegit = pSfiSLegit;
                dtoSfiPub = pSfiPub;
                dtoSfiRights = pSfiRights;
                dtoSfiDem = pSfiDem;
                dtoSfiRef = pSfiRef;
                dtoSfiExtInt = pSfiExtInt;

            }
            public int dtoIndicatorsID { get; set; }
            public int dtoSfiID { get; set; }
            public double dtoSfiTotal { get; set; }
            public double dtoSfiSec { get; set; }
            public double dtoSfiFaction { get; set; }
            public double dtoSfiGgriev { get; set; }
            public double dtoSfiEcon { get; set; }
            public double dtoSfiEcIneq { get; set; }
            public double dtoSfiHFlight { get; set; }
            public double dtoSfiSLegit { get; set; }
            public double dtoSfiPub { get; set; }
            public double dtoSfiRights { get; set; }
            public double dtoSfiDem { get; set; }
            public double dtoSfiRef { get; set; }
            public double dtoSfiExtInt { get; set; }

        }
    }
}
