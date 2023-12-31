﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirBnbUdC.GUI.Models.Parameters
{
    public class CustomerModel
    {
        [DisplayName("Cliente")]
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre debe tener entre 1 y 50 caracteres", MinimumLength = 1)]
        public string FirstName { get; set; }

        [DisplayName("Apellido")]
        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(50, ErrorMessage = "El apellido debe tener entre 1 y 50 caracteres", MinimumLength = 1)]
        public string FamilyName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "El email es requerido")]
        [StringLength(50, ErrorMessage = "El email debe tener entre 1 y 50 caracteres", MinimumLength = 1)]
        public string Email { get; set; }

        [DisplayName("Telefono")]
        [Required(ErrorMessage = "El telefono es requerido")]
        [StringLength(50, ErrorMessage = "El telefono debe tener entre 1 y 50 caracteres", MinimumLength = 1)]
        public string Cellphone { get; set; }

        [DisplayName("Foto")]
        [Required(ErrorMessage = "La foto es requerido")]
        public string Photo { get; set; }
    }
}