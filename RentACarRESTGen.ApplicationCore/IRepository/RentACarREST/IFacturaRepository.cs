
using System;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.CP.RentACarREST;
using System.Collections.Generic;

namespace RentACarRESTGen.ApplicationCore.IRepository.RentACarREST
{
public partial interface IFacturaRepository
{
public void setSessionCP (GenericSessionCP session);

FacturaEN ReadOIDDefault (int id
                          );
FacturaEN ObtenerFacturaPorId(int id);

void ModifyDefault (FacturaEN factura);

System.Collections.Generic.IList<FacturaEN> ReadAllDefault (int first, int size);



int CrearFactura (FacturaEN factura);



void Modificar (FacturaEN factura);

 // Nuevo método para obtener las facturas de un cliente por DNI
 IList<FacturaEN> ObtenerFacturasPorCliente(string clienteDNI);
    }
}
