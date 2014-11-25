using System.Collections.Generic;
using System.Linq;
using AnimalsViewer.Models;

namespace AnimalsViewer.DbWorker
{
    public static class AnimalsDbWorker
    {
        public static List<CAnimal> GetAllAnimalsFromDb()
        {
            using (var db = new AnimalsEntities())
            {
                var animals = db.Animal.ToList();

                if(animals.Count > 0)
                {
                    var animalsList = new List<CAnimal>();

                    foreach (var animal in animals)
                    {
                        var canimal = new CAnimal
                                          {
                                              Id = animal.Id,
                                              AnimalType = animal.AnimalType.Name,
                                              Name = animal.Name,
                                              SkinColor = animal.SkinColor.Name,
                                              Location = animal.Location.Name,
                                              Region = animal.Location.Region.Name
                                          };
                        animalsList.Add(canimal);
                    }

                    return animalsList;
                }
            }

            return null;
        }
    }
}