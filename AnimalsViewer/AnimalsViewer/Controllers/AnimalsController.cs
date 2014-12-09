using System.Web.Mvc;
using AnimalsViewer.DbWorker;
using AnimalsViewer.Models;
using System.Linq;
using System.Collections.Generic;

namespace AnimalsViewer.Controllers
{
    public class AnimalsController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new AnimalsEntities())
            {
                var skinColors = new List<SkinColor>();
                foreach (var skinColor in db.SkinColor)
                {
                    skinColors.Add(new SkinColor { Id = skinColor.Id, Name = skinColor.Name });
                }
                ViewBag.SkinColorId = new SelectList(skinColors, "Id", "Name");

                var animalTypes = new List<AnimalType>();
                foreach (var animalType in db.AnimalType)
                {
                    animalTypes.Add(new AnimalType { Id = animalType.Id, Name = animalType.Name });
                }
                ViewBag.AnimalTypeId = new SelectList(animalTypes, "Id", "Name");

                var regions = new List<Region>();
                foreach (var region in db.Region)
                {
                    regions.Add(new Region { Id = region.Id, Name = region.Name });
                }
                ViewBag.Regions = regions;
            }
             
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

        public ActionResult Search(int? skinColorId, int? animalTypeId, int[] selectedRegions)
        {
           var animals = AnimalsDbWorker.FindAnimal(animalTypeId, skinColorId, selectedRegions);

           return PartialView(animals);
        }
    }
}
