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
                var animalsList = animals.Select(x => new CAnimal
                    {
                        Id = x.Id,
                        Name = x.Name,
                        AnimalType = x.AnimalType.Name,
                        SkinColor = x.SkinColor.Name,
                        Location = x.Location.Name,
                        Region = x.Location.Region.Name
                    }).ToList();

                return animalsList;
            }
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

        public static CAnimal GetAnimalById(int id)
        {
            using (var db = new AnimalsEntities())
            {
                try
                {
                    var animal = db.Animal.FirstOrDefault(x => x.Id == id);
                    var canimal = new CAnimal
                                        {
                                            Id = animal.Id,
                                            Name = animal.Name,
                                            AnimalType = animal.AnimalType.Name,
                                            SkinColor = animal.SkinColor.Name,
                                            Location = animal.Location.Name,
                                            Region = animal.Location.Region.Name
                                        };

                    return canimal;
                }
                catch
                {
                    return null;
                }
            }
        }

        public static bool UpdateAnimal(CAnimal canimal)
        {
            using (var db = new AnimalsEntities())
            {
                try
                {
                    var animal = db.Animal.FirstOrDefault(x => x.Id == canimal.Id);
                    if (animal.Name != canimal.Name) 
                    {
                        animal.Name = canimal.Name;
                    }

                    if (animal.SkinColor.Name != canimal.SkinColor) 
                    {
                        animal.SkinColorId = db.SkinColor.First(x => x.Name == canimal.SkinColor).Id;
                    }

                    if (animal.AnimalType.Name != canimal.AnimalType)
                    {
                        animal.AnimalTypeId = db.AnimalType.First(x => x.Name == canimal.AnimalType).Id;
                    }

                    if (animal.Location.Name != canimal.Location)
                    {
                        animal.LocationId = db.Location.First(x => x.Name == canimal.Location).Id;
                    }

                    db.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}