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
            var canimal = new CAnimal();
            canimal.GetDataForComboBoxes();

            return View(canimal);
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

        public ActionResult Delete(int id)
        {
            if (AnimalsDbWorker.DeleteAnimalFromDb(id))
            {
                ViewBag.AnimalCreationResult = "Животное успешно удалено";
            }
            else ViewBag.AnimalCreationResult = "Животное не удалено";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            var canimal = AnimalsDbWorker.GetAnimalById(id);
            canimal.GetDataForComboBoxes();

            return PartialView(canimal);
        }

        [HttpPost]
        public ActionResult Update(CAnimal model)
        {
            AnimalsDbWorker.UpdateAnimal(model);

            return RedirectToAction("Index");
        }
    }
}
