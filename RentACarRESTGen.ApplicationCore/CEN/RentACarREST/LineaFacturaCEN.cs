

using System;
using System.Text;
using System.Collections.Generic;

using RentACarRESTGen.ApplicationCore.Exceptions;

using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.IRepository.RentACarREST;


namespace RentACarRESTGen.ApplicationCore.CEN.RentACarREST
{
/*
 *      Definition of the class LineaFacturaCEN
 *
 */
public partial class LineaFacturaCEN
{
private ILineaFacturaRepository _ILineaFacturaRepository;

public LineaFacturaCEN(ILineaFacturaRepository _ILineaFacturaRepository)
{
        this._ILineaFacturaRepository = _ILineaFacturaRepository;
}

public ILineaFacturaRepository get_ILineaFacturaRepository ()
{
        return this._ILineaFacturaRepository;
}

public int CrearLinea (int p_factura, int p_reserva, double p_precio)
{
        LineaFacturaEN lineaFacturaEN = null;
        int oid;

        //Initialized LineaFacturaEN
        lineaFacturaEN = new LineaFacturaEN ();

        if (p_factura != -1) {
                // El argumento p_factura -> Property factura es oid = false
                // Lista de oids numLinea
                lineaFacturaEN.Factura = new RentACarRESTGen.ApplicationCore.EN.RentACarREST.FacturaEN ();
                lineaFacturaEN.Factura.Id = p_factura;
        }


        if (p_reserva != -1) {
                // El argumento p_reserva -> Property reserva es oid = false
                // Lista de oids numLinea
                lineaFacturaEN.Reserva = new RentACarRESTGen.ApplicationCore.EN.RentACarREST.ReservaEN ();
                lineaFacturaEN.Reserva.Id = p_reserva;
        }

        lineaFacturaEN.Precio = p_precio;



        oid = _ILineaFacturaRepository.CrearLinea (lineaFacturaEN);
        return oid;
}
}
}
