
using System;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.CP.RentACarREST;

namespace RentACarRESTGen.ApplicationCore.IRepository.RentACarREST
{
public partial interface IProveedorRepository
{
public void setSessionCP (GenericSessionCP session);

ProveedorEN ReadOIDDefault (int id
                            );

void ModifyDefault (ProveedorEN proveedor);

System.Collections.Generic.IList<ProveedorEN> ReadAllDefault (int first, int size);



int New_ (ProveedorEN proveedor);

void Modify (ProveedorEN proveedor);


void Destroy (int id
              );


void AsignarCoche (int p_Proveedor_OID, System.Collections.Generic.IList<int> p_coche_OIDs);
}
}
