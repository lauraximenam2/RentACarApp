
using System;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
namespace RentACarRESTGen.Infraestructure.EN.RentACarREST
{
public partial class FacturaNH : FacturaEN {
public FacturaNH ()
{
}

public FacturaNH (FacturaEN dto)
{
        this.Id = dto.Id;


        this.Fecha = dto.Fecha;


        this.EsPagada = dto.EsPagada;


        this.EsAnulada = dto.EsAnulada;
}
}
}
