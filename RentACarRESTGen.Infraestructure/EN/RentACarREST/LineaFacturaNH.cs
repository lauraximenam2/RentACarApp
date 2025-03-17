
using System;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
namespace RentACarRESTGen.Infraestructure.EN.RentACarREST
{
public partial class LineaFacturaNH : LineaFacturaEN {
public LineaFacturaNH ()
{
}

public LineaFacturaNH (LineaFacturaEN dto)
{
        this.NumLinea = dto.NumLinea;


        this.Precio = dto.Precio;
}
}
}
