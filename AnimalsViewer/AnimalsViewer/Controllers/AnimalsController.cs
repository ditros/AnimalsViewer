using System.Web.Mvc;
using AnimalsViewer.DbWorker;

namespace AnimalsViewer.Controllers
{
    public class AnimalsController : Controller
    {
        public ActionResult Index()
        {
            var animalsList = AnimalsDbWorker.GetAllAnimalsFromDb();

            return animalsList != null ? View(animalsList) : View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
