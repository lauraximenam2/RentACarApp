
using System;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
namespace RentACarRESTGen.Infraestructure.EN.RentACarREST
{
public partial class CocheNH : CocheEN {
public CocheNH ()
{
}

public CocheNH (CocheEN dto)
{
        this.NumLicencia = dto.NumLicencia;


        this.Categoria = dto.Categoria;


        this.Estado = dto.Estado;
}
}
}
