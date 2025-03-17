
using System;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
namespace RentACarRESTGen.Infraestructure.EN.RentACarREST
{
public partial class ClienteNH : ClienteEN {
public ClienteNH ()
{
}

public ClienteNH (ClienteEN dto)
{
        this.DNI = dto.DNI;


        this.Nombre = dto.Nombre;


        this.Direccion = dto.Direccion;


        this.Telefono = dto.Telefono;


        this.Pass = dto.Pass;
}
}
}
