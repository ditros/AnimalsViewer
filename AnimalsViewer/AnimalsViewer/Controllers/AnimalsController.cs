using System.Web.Mvc;
using AnimalsViewer.DbWorker;
using AnimalsViewer.Models;

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

        [HttpPost]
        public ActionResult Create(CAnimal animal)
        {
            if(AnimalsDbWorker.AddAnimalToDb(animal))
            {
                ViewBag.AnimalCreationResult = "Животное успешно добавлено";
            }
            else ViewBag.AnimalCreationResult = "Животное не добавлено";

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
