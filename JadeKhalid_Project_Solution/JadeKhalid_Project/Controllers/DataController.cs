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

        /*List<SfiHdiDto> myData = new List<SfiHdiDto>();


        public IEnumerable<SfiHdiDto> GetAllOrders()
        {
            foreach (Country country in myCollection.Countries)
            {
                SfiHdiDto myDataObject = new SfiHdiDto();
                myData.Add(myDataObject);
            }

            return myData;
        }*/
    }
}
