

using System;
using System.Text;
using System.Collections.Generic;

using RentACarRESTGen.ApplicationCore.Exceptions;

using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.IRepository.RentACarREST;


namespace RentACarRESTGen.ApplicationCore.CEN.RentACarREST
{
/*
 *      Definition of the class ReservaCEN
 *
 */
public partial class ReservaCEN
{
private IReservaRepository _IReservaRepository;

public ReservaCEN(IReservaRepository _IReservaRepository)
{
        this._IReservaRepository = _IReservaRepository;
}

public IReservaRepository get_IReservaRepository ()
{
        return this._IReservaRepository;
}

public int CrearReserva (string p_cliente, Nullable<DateTime> p_inicio, Nullable<DateTime> p_final)
{
        ReservaEN reservaEN = null;
        int oid;

        //Initialized ReservaEN
        reservaEN = new ReservaEN ();

        if (p_cliente != null) {
                // El argumento p_cliente -> Property cliente es oid = false
                // Lista de oids id
                reservaEN.Cliente = new RentACarRESTGen.ApplicationCore.EN.RentACarREST.ClienteEN ();
                reservaEN.Cliente.DNI = p_cliente;
        }

        reservaEN.Inicio = p_inicio;

        reservaEN.Final = p_final;



        oid = _IReservaRepository.CrearReserva (reservaEN);
        return oid;
}

public void BorrarReserva (int id
                           )
{
        _IReservaRepository.BorrarReserva (id);
}

public void AsignarCoche (int p_Reserva_OID, string p_cliente_OID)
{
        //Call to ReservaRepository

        _IReservaRepository.AsignarCoche (p_Reserva_OID, p_cliente_OID);
}
}
}
