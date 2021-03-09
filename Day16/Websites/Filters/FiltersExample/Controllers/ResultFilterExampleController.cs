using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersExample.Controllers
{
    public class ResultFilterExampleController : Controller
    {
        // GET: ResultFilterExample
        [OutputCache(Duration = 30, VaryByParam ="none")] //here a cache is stored in from the value which were stored from the last page visited---this is done for when the user if again visits will get the same value/credentials----VaryByParam ="none" means take cache same for all
        public string Index()
        {
            return DateTime.Now.ToString("T"); //when we run this then the time will be cashed for 30 sec---if we visit within 30 sec the it will show previous visit time---after 30 sec it will change
        }
        [OutputCache(Duration = 30, VaryByParam ="id")] //if we visit the page with different id then it will show the same time(cached data)---therefore to generate different cache of different pages we write VaryByParam ="id"
        public string Index2(int id= 0)
        {
            return DateTime.Now.ToString("T");
        }
    }
}