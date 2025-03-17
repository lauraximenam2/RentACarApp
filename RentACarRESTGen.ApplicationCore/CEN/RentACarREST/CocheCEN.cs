

using System;
using System.Text;
using System.Collections.Generic;

using RentACarRESTGen.ApplicationCore.Exceptions;

using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.IRepository.RentACarREST;


namespace RentACarRESTGen.ApplicationCore.CEN.RentACarREST
{
/*
 *      Definition of the class CocheCEN
 *
 */
public partial class CocheCEN
{
private ICocheRepository _ICocheRepository;

public CocheCEN(ICocheRepository _ICocheRepository)
{
        this._ICocheRepository = _ICocheRepository;
}

public ICocheRepository get_ICocheRepository ()
{
        return this._ICocheRepository;
}

public int CrearCoche (RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.CategoriaCocheEnum p_categoria, RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.EstadoCocheEnum p_estado)
{
        CocheEN cocheEN = null;
        int oid;

        //Initialized CocheEN
        cocheEN = new CocheEN ();
        cocheEN.Categoria = p_categoria;

        cocheEN.Estado = p_estado;



        oid = _ICocheRepository.CrearCoche (cocheEN);
        return oid;
}

public void BorrarCoche (int numLicencia
                         )
{
        _ICocheRepository.BorrarCoche (numLicencia);
}

public void AsignarReserva (int p_Coche_OID, int p_reserva_OID)
{
        //Call to CocheRepository

        _ICocheRepository.AsignarReserva (p_Coche_OID, p_reserva_OID);
}
public void DesasignarReserva (int p_Coche_OID, int p_reserva_OID)
{
        //Call to CocheRepository

        _ICocheRepository.DesasignarReserva (p_Coche_OID, p_reserva_OID);
}
public void Modificar (int p_Coche_OID, RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.CategoriaCocheEnum p_categoria, RentACarRESTGen.ApplicationCore.Enumerated.RentACarREST.EstadoCocheEnum p_estado)
{
        CocheEN cocheEN = null;

        //Initialized CocheEN
        cocheEN = new CocheEN ();
        cocheEN.NumLicencia = p_Coche_OID;
        cocheEN.Categoria = p_categoria;
        cocheEN.Estado = p_estado;
        //Call to CocheRepository

        _ICocheRepository.Modificar (cocheEN);
}

public System.Collections.Generic.IList<RentACarRESTGen.ApplicationCore.EN.RentACarREST.CocheEN> DameCochesDisponibles (int first, int size)
{
        return _ICocheRepository.DameCochesDisponibles (first, size);
}
}
}
