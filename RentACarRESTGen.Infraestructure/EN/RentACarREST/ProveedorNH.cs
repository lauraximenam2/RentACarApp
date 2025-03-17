
using System;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
namespace RentACarRESTGen.Infraestructure.EN.RentACarREST
{
public partial class ProveedorNH : ProveedorEN {
public ProveedorNH ()
{
}

public ProveedorNH (ProveedorEN dto)
{
        this.Id = dto.Id;
}
}
}
