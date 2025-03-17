
using System;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.CP.RentACarREST;

namespace RentACarRESTGen.ApplicationCore.IRepository.RentACarREST
{
public partial interface ILineaFacturaRepository
{
public void setSessionCP (GenericSessionCP session);

LineaFacturaEN ReadOIDDefault (int numLinea
                               );

void ModifyDefault (LineaFacturaEN lineaFactura);

System.Collections.Generic.IList<LineaFacturaEN> ReadAllDefault (int first, int size);



int CrearLinea (LineaFacturaEN lineaFactura);
}
}
