
using System;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.CP.RentACarREST;

namespace RentACarRESTGen.ApplicationCore.IRepository.RentACarREST
{
public partial interface IClienteRepository
{
public void setSessionCP (GenericSessionCP session);

ClienteEN ReadOIDDefault (string DNI
                          );

void ModifyDefault (ClienteEN cliente);

System.Collections.Generic.IList<ClienteEN> ReadAllDefault (int first, int size);



string CrearCliente (ClienteEN cliente);

void BorrarCliente (string DNI
                    );


void Modificar (ClienteEN cliente);


ClienteEN ReadOID (string DNI
                   );


System.Collections.Generic.IList<ClienteEN> ReadAll (int first, int size);
}
}
