

using System;
using System.Text;
using System.Collections.Generic;

using RentACarRESTGen.ApplicationCore.Exceptions;

using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.IRepository.RentACarREST;


namespace RentACarRESTGen.ApplicationCore.CEN.RentACarREST
{
/*
 *      Definition of the class ProveedorCEN
 *
 */
public partial class ProveedorCEN
{
private IProveedorRepository _IProveedorRepository;

public ProveedorCEN(IProveedorRepository _IProveedorRepository)
{
        this._IProveedorRepository = _IProveedorRepository;
}

public IProveedorRepository get_IProveedorRepository ()
{
        return this._IProveedorRepository;
}

public int New_ ()
{
        ProveedorEN proveedorEN = null;
        int oid;

        //Initialized ProveedorEN
        proveedorEN = new ProveedorEN ();


        oid = _IProveedorRepository.New_ (proveedorEN);
        return oid;
}

public void Modify (int p_Proveedor_OID)
{
        ProveedorEN proveedorEN = null;

        //Initialized ProveedorEN
        proveedorEN = new ProveedorEN ();
        proveedorEN.Id = p_Proveedor_OID;
        //Call to ProveedorRepository

        _IProveedorRepository.Modify (proveedorEN);
}

public void Destroy (int id
                     )
{
        _IProveedorRepository.Destroy (id);
}

public void AsignarCoche (int p_Proveedor_OID, System.Collections.Generic.IList<int> p_coche_OIDs)
{
        //Call to ProveedorRepository

        _IProveedorRepository.AsignarCoche (p_Proveedor_OID, p_coche_OIDs);
}
}
}
