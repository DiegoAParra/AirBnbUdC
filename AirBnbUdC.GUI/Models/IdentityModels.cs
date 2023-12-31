﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AirBnbUdC.GUI.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que authenticationType debe coincidir con el valor definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar reclamaciones de usuario personalizadas aquí
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        object placeHolderVariable;
        public System.Data.Entity.DbSet<AirBnbUdC.GUI.Models.Parameters.CountryModel> CountryModels { get; set; }

        public System.Data.Entity.DbSet<AirBnbUdC.GUI.Models.Parameters.CityModel> CityModels { get; set; }

        public System.Data.Entity.DbSet<AirBnbUdC.GUI.Models.Parameters.PropertyOwnerModel> PropertyOwnerModels { get; set; }

        public System.Data.Entity.DbSet<AirBnbUdC.GUI.Models.Parameters.PropertyModel> PropertyModels { get; set; }

        public System.Data.Entity.DbSet<AirbnbUdC.Application.Contracts.DTO.Parameters.PropertyDTO> PropertyDTOes { get; set; }

        public System.Data.Entity.DbSet<AirBnbUdC.GUI.Models.Parameters.CustomerModel> CustomerModels { get; set; }

        public System.Data.Entity.DbSet<AirBnbUdC.GUI.Models.Parameters.MultimediaTypeModel> MultimediaTypeModels { get; set; }

        public System.Data.Entity.DbSet<AirBnbUdC.GUI.Models.Parameters.PropertyMultimediaModel> PropertyMultimediaModels { get; set; }

        public System.Data.Entity.DbSet<AirBnbUdC.GUI.Models.Parameters.HomePropertyModel> HomePropertyModels { get; set; }
    }
}