using System;
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

        public static bool AddAnimalToDb(CAnimal animal)
        {
            using (var db = new AnimalsEntities())
            {
                try
                {
                    var skinColorId = db.SkinColor.First(x => x.Name == animal.SkinColor).Id;
                    var animalTypeId = db.AnimalType.First(x => x.Name == animal.AnimalType).Id;
                    var locationId = db.Location.First(x => x.Name == animal.Location).Id;
                    var maxId = db.Animal.OrderByDescending(x => x.Id).First().Id;
                    maxId = maxId + 1;
                    db.Animal.Add(new Animal
                                      {Id = maxId, Name = animal.Name, AnimalTypeId = animalTypeId, LocationId = locationId, SkinColorId = skinColorId});

                    if (db.SaveChanges() > 0)
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        public static bool DeleteAnimalFromDb(int id)
        {
            using (var db = new AnimalsEntities())
            {
                try
                {
                    var animal = db.Animal.First(x => x.Id == id);
                    db.Animal.Remove(animal);

                    if (db.SaveChanges() > 0)
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }
    }
}