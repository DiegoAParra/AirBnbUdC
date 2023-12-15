using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirBnbUdC.GUI.Models.Parameters
{
    public class PropertyMultimediaModel
    {
        [DisplayName("Multimedia")]
        public int Id { get; set; }

        [DisplayName("Identificador")]
        [Required(ErrorMessage = "El identificador es requerido")]
        public int MultimediaName { get; set; }

        [DisplayName("Link")]
        [Required(ErrorMessage = "El link es requerido")]
        public string MultimediaLink { get; set; }

        [Required]
        public PropertyModel Property { get; set; }

        public IEnumerable<PropertyModel> PropertyList { get; set; }

        [Required]
        public MultimediaTypeModel MultimediaType { get; set; }

        public IEnumerable<MultimediaTypeModel> MultimediaTypeList { get; set; }

    }
}