using Microsoft.AspNetCore.Mvc;

namespace RestaurantList.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

    }
}