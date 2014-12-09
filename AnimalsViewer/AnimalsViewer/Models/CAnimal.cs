using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;

namespace AnimalsViewer.Models
{
    public class CAnimal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Value \"{0}\" must contain {2} or more symblos.", MinimumLength = 2)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Animal type")]
        public string AnimalType { get; set; }

        private List<AnimalType> _animalTypes;

        public IEnumerable<SelectListItem> AnimalTypes
        {
            get { return new SelectList(_animalTypes, "Name", "Name"); }
        }

        [Required]
        [Display(Name = "Skin color")]
        public string SkinColor { get; set; }

        private List<SkinColor> _skinColors;

        public IEnumerable<SelectListItem> SkinColors
        {
            get { return new SelectList(_skinColors, "Name", "Name"); }
        }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        private List<Location> _locations;

        public IEnumerable<SelectListItem> Locations
        {
            get { return new SelectList(_locations, "Name", "Name"); }
        }

        [Required]
        [Display(Name = "Region")]
        public string Region { get; set; }

        public void GetSkinColorsFromDb()
        {
            using (var db = new AnimalsEntities())
            {
                _skinColors = db.SkinColor.ToList();
            }
        }

        public void GetAnimalTypesFromDb()
        {
            using (var db = new AnimalsEntities())
            {
                _animalTypes = db.AnimalType.ToList();
            }
        }

        public void GetLocationsFromDb()
        {
            using (var db = new AnimalsEntities())
            {
                _locations = db.Location.ToList();
            }
        }

        public void GetDataForComboBoxes()
        {
            GetAnimalTypesFromDb();
            GetLocationsFromDb();
            GetSkinColorsFromDb();
        }
    }
}