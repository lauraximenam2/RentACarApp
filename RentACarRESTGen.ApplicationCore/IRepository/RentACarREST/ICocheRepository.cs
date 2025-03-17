
using System;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.CP.RentACarREST;

namespace RentACarRESTGen.ApplicationCore.IRepository.RentACarREST
{
public partial interface ICocheRepository
{
public void setSessionCP (GenericSessionCP session);

CocheEN ReadOIDDefault (int numLicencia
                        );

void ModifyDefault (CocheEN coche);

System.Collections.Generic.IList<CocheEN> ReadAllDefault (int first, int size);



int CrearCoche (CocheEN coche);

void BorrarCoche (int numLicencia
                  );


void AsignarReserva (int p_Coche_OID, int p_reserva_OID);

void DesasignarReserva (int p_Coche_OID, int p_reserva_OID);



void Modificar (CocheEN coche);


System.Collections.Generic.IList<RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN> DameCochesDisponibles (int first, int size);
}
}
