using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;

namespace AnimalsViewer.Models
{
    public class SearchModel
    {
        [Display(Name = "Animal type")]
        public string AnimalType { get; set; }

        private List<AnimalType> _animalTypes;

        public IEnumerable<SelectListItem> AnimalTypes
        {
            get { return new SelectList(_animalTypes, "Name", "Name"); }
        }

        [Display(Name = "Skin Color")]
        public string SkinColor { get; set; }

        private List<SkinColor> _skinColors;

        public IEnumerable<SelectListItem> SkinColors
        {
            get { return new SelectList(_skinColors, "Name", "Name"); }
        }

        [Display(Name = "Region")]
        public List<Region> Regions { get; set; }

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

        private void GetRegionsFromDb()
        {
            using (var db = new AnimalsEntities())
            {
                Regions = db.Region.ToList();
            }
        }

        public void GetDataForComboBoxes()
        {
            GetAnimalTypesFromDb();
            GetSkinColorsFromDb();
            GetRegionsFromDb();
        }
    }
}