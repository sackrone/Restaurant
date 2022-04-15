using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.Data.Entities
{
    public class TableEntity
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "Campo acepta minimo {1} carácteres.")]
        [Required(ErrorMessage = "Campo requerido.")]
        public string Name { get; set; }

        [Display(Name = "Disponible")]
        public bool Available { get; set; }
    }
}
