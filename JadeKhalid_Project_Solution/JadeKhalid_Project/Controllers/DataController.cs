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
        public IHttpActionResult GetIndicators()
        {
            Type objType = typeof(DataController.IndicatorDto);
            List<string> objTypeList = new List<string>();
            List<string> abbrIndicators = new List<string>();

            List<string> FullNameIndicators = new List<string>();
            FullNameIndicators.Add("Security Apparatus");
            FullNameIndicators.Add("Factionalized Elites");
            FullNameIndicators.Add("Group Grievance");
            FullNameIndicators.Add("Economy");
            FullNameIndicators.Add("Economic Inequality");
            FullNameIndicators.Add("Human Flight and Brain Drain");
            FullNameIndicators.Add("State Legitimacy");
            FullNameIndicators.Add("Public Services");
            FullNameIndicators.Add("Human Rights");
            FullNameIndicators.Add("Demographic Pressures");
            FullNameIndicators.Add("Refugees and IDPs");
            FullNameIndicators.Add("External Intervention");

            return Json(FullNameIndicators);
        }

        // Data Transfer Objects to make parsing data easier
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

        // Additional Classes for grouping data
        public class RelatedData
        {
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
}
