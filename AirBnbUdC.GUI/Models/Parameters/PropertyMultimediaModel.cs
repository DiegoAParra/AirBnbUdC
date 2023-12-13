using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirBnbUdC.GUI.Models.Parameters
{
    public class PropertyMultimediaModel
    {
        [DisplayName("Multimedia Propiedad")]
        public int Id { get; set; }

        [DisplayName("Nombre (Númerico)")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public int MultimediaName { get; set; }

        [DisplayName("Link")]
        [Required(ErrorMessage = "El link es requerido")]
        [StringLength(50, ErrorMessage = "El link debe tener entre 1 y 50 caracteres", MinimumLength = 1)]
        public string MultimediaLink { get; set; }

        [Required]
        public PropertyModel Property { get; set; }

        public IEnumerable<PropertyModel> PropertyList { get; set; }

        [Required]
        public MultimediaTypeModel MultimediaType { get; set; }

        public IEnumerable<MultimediaTypeModel> MultimediaTypeList { get; set; }

    }
}