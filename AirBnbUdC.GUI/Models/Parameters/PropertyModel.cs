using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirBnbUdC.GUI.Models.Parameters
{
    public class PropertyModel
    {
        [DisplayName("Propiedad")]
        public int Id { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "La dirección es requerido")]
        [StringLength(50, ErrorMessage = "La dirección debe tener entre 1 y 50 caracteres", MinimumLength = 1)]
        public string PropertyAddress { get; set; }

        [Required]
        public CityModel City { get; set; }

        public IEnumerable<CityModel> CityList { get; set; }

        [DisplayName("Capacidad")]
        [Required(ErrorMessage = "La capacidad es requerido")]
        public int CustomerAmount { get; set; }

        [DisplayName("Precio")]
        [Required(ErrorMessage = "El precio es requerido")]
        public double Price { get; set; }

        [DisplayName("Latitud")]
        [Required(ErrorMessage = "La latitud es requerido")]
        [StringLength(50, ErrorMessage = "La latitud debe tener entre 1 y 50 caracteres", MinimumLength = 1)]
        public string Latitude { get; set; }

        [DisplayName("Longitud")]
        [Required(ErrorMessage = "La longitud es requerido")]
        [StringLength(50, ErrorMessage = "La longitud debe tener entre 1 y 50 caracteres", MinimumLength = 1)]
        public string Longitude { get; set; }

        [Required]
        public PropertyOwnerModel PropertyOwner { get; set; }

        public IEnumerable<PropertyOwnerModel> PropertyOwnerList { get; set; }

        [DisplayName("Checkin")]
        [Required(ErrorMessage = "El Checkin es requerido")]
        [StringLength(50, ErrorMessage = "El Checkin debe tener entre 1 y 50 caracteres", MinimumLength = 1)]
        public string CheckinData { get; set; }

        [DisplayName("Checkout")]
        [Required(ErrorMessage = "El Checkout es requerido")]
        [StringLength(50, ErrorMessage = "El Checkout debe tener entre 1 y 50 caracteres", MinimumLength = 1)]
        public string CheckoutData { get; set; }

        [DisplayName("Detalles")]
        [Required(ErrorMessage = "Los detalles es requerido")]
        [StringLength(50, ErrorMessage = "Los detalles debe tener entre 1 y 50 caracteres", MinimumLength = 1)]
        public string Details { get; set; }

        [DisplayName("Mascotas")]
        [Required(ErrorMessage = "Mascotas es requerido")]
        public bool Pets { get; set; }

        [DisplayName("Congelador")]
        [Required(ErrorMessage = "El congelador es requerido")]
        public bool Freezer { get; set; }

        [DisplayName("Lavanderia")]
        [Required(ErrorMessage = "La lavanderia es requerido")]
        public bool LaundryService { get; set; }
    }
}