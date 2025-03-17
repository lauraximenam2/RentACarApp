
using System;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.CP.RentACarREST;

namespace RentACarRESTGen.ApplicationCore.IRepository.RentACarREST
{
public partial interface IReservaRepository
{
public void setSessionCP (GenericSessionCP session);

ReservaEN ReadOIDDefault (int id
                          );

void ModifyDefault (ReservaEN reserva);

System.Collections.Generic.IList<ReservaEN> ReadAllDefault (int first, int size);



int CrearReserva (ReservaEN reserva);

void BorrarReserva (int id
                    );


void AsignarCoche (int p_Reserva_OID, string p_cliente_OID);
}
}
