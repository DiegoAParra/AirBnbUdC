
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace AirbnbUdc.Repository.Implementation.DataModel
{

using System;
    using System.Collections.Generic;
    
public partial class PropertyMultimedia
{

    public long Id { get; set; }

    public Nullable<int> MultimediaName { get; set; }

    public string MultimediaLink { get; set; }

    public long PropertyId { get; set; }

    public int MultimediaTypeId { get; set; }



    public virtual MultimediaType MultimediaType { get; set; }

    public virtual Property Property { get; set; }

}

}
