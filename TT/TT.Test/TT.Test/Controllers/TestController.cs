using System.Web.Mvc;
using TT.Test.Models;

namespace TT.Test.Controllers
{
    public class TestController : Controller
    {
        TestModels testModels;
        public TestController()
        {
            testModels = new TestModels();
        }
        //
        // GET: /Test/

        public ActionResult Index()
        {
            testModels.data = "show";
            return View(testModels);
        }

    }
}
