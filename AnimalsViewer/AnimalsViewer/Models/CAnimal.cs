using System.ComponentModel.DataAnnotations;

namespace AnimalsViewer.Models
{
    public class CAnimal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Значение \"{0}\" должно содержать не менее {2} символов.", MinimumLength = 2)]
        [Display(Name = "Название животного")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Вид животного")]
        public string AnimalType { get; set; }

        [Required]
        [Display(Name = "Цвет шкуры")]
        public string SkinColor { get; set; }

        [Required]
        [Display(Name = "Меcтоположение")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Регион")]
        public string Region { get; set; }
    }
}