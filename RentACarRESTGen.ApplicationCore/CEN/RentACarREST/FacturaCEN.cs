

using System;
using System.Text;
using System.Collections.Generic;

using RentACarRESTGen.ApplicationCore.Exceptions;

using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.IRepository.RentACarREST;


namespace RentACarRESTGen.ApplicationCore.CEN.RentACarREST
{
/*
 *      Definition of the class FacturaCEN
 *
 */
public partial class FacturaCEN
{
private IFacturaRepository _IFacturaRepository;

public FacturaCEN(IFacturaRepository _IFacturaRepository)
{
        this._IFacturaRepository = _IFacturaRepository;
}

public IFacturaRepository get_IFacturaRepository ()
{
        return this._IFacturaRepository;
}

public int CrearFactura (Nullable<DateTime> p_fecha, bool p_esPagada, bool p_esAnulada, string p_cliente)
{
        FacturaEN facturaEN = null;
        int oid;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();
        facturaEN.Fecha = p_fecha;

        facturaEN.EsPagada = p_esPagada;

        facturaEN.EsAnulada = p_esAnulada;


        if (p_cliente != null) {
                // El argumento p_cliente -> Property cliente es oid = false
                // Lista de oids id
                facturaEN.Cliente = new RentACarRESTGen.ApplicationCore.EN.RentACarREST.ClienteEN ();
                facturaEN.Cliente.DNI = p_cliente;
        }



        oid = _IFacturaRepository.CrearFactura (facturaEN);
        return oid;
}

public void Modificar (int p_Factura_OID, Nullable<DateTime> p_fecha, bool p_esPagada, bool p_esAnulada)
{
        FacturaEN facturaEN = null;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();
        facturaEN.Id = p_Factura_OID;
        facturaEN.Fecha = p_fecha;
        facturaEN.EsPagada = p_esPagada;
        facturaEN.EsAnulada = p_esAnulada;
        //Call to FacturaRepository

        _IFacturaRepository.Modificar (facturaEN);
}

        // Nuevo método para obtener facturas por cliente
        public IList<FacturaEN> ObtenerFacturasPorCliente(string clienteDNI)
        {
            if (string.IsNullOrEmpty(clienteDNI))
                throw new ModelException("El DNI del cliente no puede ser nulo o vacío");

            return _IFacturaRepository.ObtenerFacturasPorCliente(clienteDNI);
        }

        public FacturaEN ObtenerFacturaPorId(int id)
        {
            if (id <= 0)
                throw new ModelException("El ID de la factura debe ser mayor a 0");

            return _IFacturaRepository.ObtenerFacturaPorId(id);
        }
    }
}